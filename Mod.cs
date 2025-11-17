// Mod.cs


namespace AchievementFixer
{
    using System.Reflection;                   // Only for version number
    using System.Collections.Generic;          // Dictionary<string,string>, HashSet<string>
    using Colossal;                            // IDictionarySource
    using Colossal.IO.AssetDatabase;           // AssetDatabase
    using Colossal.Logging;                    // ILog, LogManager
    using Game;                                // UpdateSystem, SystemUpdatePhase
    using Game.Achievements;                   // AchievementTriggerSystem (phase anchor)
    using Game.Modding;                        // IMod
    using Game.SceneFlow;                      // GameManager

    public sealed class Mod : IMod
    {
        // ---- PUBLIC CONSTANTS / METADATA ----
        public const string ModName = "Achievement Fixer";
        public const string ModId = "AchievementFixer";
        public const string ModTag = "[AF]";

        /// <summary>
        /// Read &lt;Version&gt; from .csproj (3-part).
        /// </summary>
        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        // ----- Logger & public properties -----
        public static readonly ILog s_Log =
            LogManager.GetLogger("AchievementFixer").SetShowsErrorsInUI(false);

        public static Settings? Settings
        {
            get; private set;
        }

        // ----- Private state -----
        private static readonly HashSet<string> s_InstalledLocales = new(); // prevent duplicate installs
        private static readonly HashSet<string> s_FailedLocales = new();    // locales that blew up AddSource
        private static bool s_BannerLogged;
        private static bool s_Reapplying;

        // ----- IMod -----
        public void OnLoad(UpdateSystem updateSystem)
        {
            // metadata banner (once)
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                s_Log.Info($"{ModName} {ModTag} v{ModVersion} OnLoad");
            }

            // Settings object (must exist before locales so labels resolve)
            var settings = new Settings(this);
            Settings = settings;

            // Register locales BEFORE Options UI
            AddLocale("en-US", new LocaleEN(settings));
            AddLocale("fr-FR", new LocaleFR(settings));
            AddLocale("de-DE", new LocaleDE(settings));
            AddLocale("es-ES", new LocaleES(settings));
            AddLocale("it-IT", new LocaleIT(settings));
            AddLocale("ja-JP", new LocaleJA(settings));
            AddLocale("ko-KR", new LocaleKO(settings));
            AddLocale("vi-VN", new LocaleVI(settings));
            AddLocale("pl-PL", new LocalePL(settings));
            AddLocale("pt-BR", new LocalePT_BR(settings));
            AddLocale("zh-HANS", new LocaleZH_CN(settings));
            AddLocale("zh-HANT", new LocaleZH_HANT(settings));

            // Load saved settings + Options UI
            AssetDatabase.global.LoadSettings("AchievementFixer", settings, new Settings(this));
            settings.RegisterInOptionsUI();

            // Ensure our system runs after the game's trigger during the main loop.
            updateSystem.UpdateAfter<AchievementFixerSystem, AchievementTriggerSystem>(SystemUpdatePhase.MainLoop);

            // Lazy per-locale banner override (install for current locale now)
            var lm = GameManager.instance?.localizationManager;
            var activeId = lm?.activeLocaleId;
            if (!string.IsNullOrEmpty(activeId))
            {
                EnsureWarningOverrideFor(activeId!);
            }

            // Subscribe once for future locale switches
            if (lm != null)
            {
                lm.onActiveDictionaryChanged -= OnLocaleChanged; // avoid double subscription
                lm.onActiveDictionaryChanged += OnLocaleChanged;
            }
        }

        public void OnDispose()
        {
            var lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                lm.onActiveDictionaryChanged -= OnLocaleChanged;
            }

            s_Log.Info("OnDispose");
        }

        // ----- Event handlers -----
        private void OnLocaleChanged()
        {
            if (s_Reapplying)
            {
                return; // debounce re-entrancy
            }

            s_Reapplying = true;
            try
            {
                var lm = GameManager.instance?.localizationManager;
                var active = lm?.activeLocaleId ?? string.Empty;

                if (!string.IsNullOrEmpty(active))
                {
                    EnsureWarningOverrideFor(active); // install once for newly active locale
                }

                // Keep Options UI consistent
                Settings?.RegisterInOptionsUI();
            }
            finally
            {
                s_Reapplying = false;
            }
        }

        // ----- Private helpers -----

        /// <summary>
        /// Central wrapper around LocalizationManager.AddSource that
        /// - skips locales that already failed,
        /// - catches any exception (e.g. from I18NEverywhere) and logs once.
        /// </summary>
        private static bool TryAddLocaleSource(string localeId, IDictionarySource source, string context)
        {
            if (string.IsNullOrEmpty(localeId))
            {
                return false;
            }

            if (s_FailedLocales.Contains(localeId))
            {
                // If locale broken for AddSource; avoid spamming errors.
                return false;
            }

            var lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                s_Log.Warn($"{context}: No LocalizationManager; cannot add source for locale '{localeId}'.");
                return false;
            }

            try
            {
                lm.AddSource(localeId, source);
                return true;
            }
            catch (System.Exception ex)
            {
                // This is where I18NEverywhere mod was throwing. Catch it so it doesn't become a global NRE.
                s_FailedLocales.Add(localeId);
                s_Log.Warn($"{context}: AddSource for locale '{localeId}' failed: {ex.GetType().Name}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Install per-locale override for the built-in “achievements disabled by mods” banner.
        /// Done once per locale; last source wins.
        /// </summary>
        private static void EnsureWarningOverrideFor(string localeId)
        {
            // Only once per locale (if it previously failed, TryAddLocaleSource will early-out)
            if (!s_InstalledLocales.Add(localeId))
            {
                return;
            }

            const string kWarningKey = "Menu.ACHIEVEMENTS_WARNING_MODS";    // game key to override
            var bannerText = LocaleBannerText.For(localeId);

            var entries = new Dictionary<string, string>
            {
                [kWarningKey] = bannerText
            };

            TryAddLocaleSource(localeId, new LocaleOverrideSource(entries), "EnsureWarningOverrideFor");
        }

        /// <summary>
        /// Re-assert the banner for the currently active locale.
        /// Cheap, “last writer wins” nudge — used by the system at intervals.
        /// </summary>
        internal static void ReapplyBannerForActiveLocale()
        {
            var lm = GameManager.instance?.localizationManager;
            var active = lm?.activeLocaleId;
            if (lm == null || string.IsNullOrEmpty(active))
            {
                return;
            }

            const string kWarningKey = "Menu.ACHIEVEMENTS_WARNING_MODS";
            var text = LocaleBannerText.For(active!);
            var entries = new Dictionary<string, string>
            {
                [kWarningKey] = text
            };

            // Intentionally no dedupe: overwrite if something else replaced it.
            TryAddLocaleSource(active!, new LocaleOverrideSource(entries), "ReapplyBannerForActiveLocale");
        }

        /// <summary>
        /// Final banner re-apply once per assert window.
        /// </summary>
        internal static void ReapplyBannerForActiveLocaleFinal()
        {
            var lm = GameManager.instance?.localizationManager;
            var active = lm?.activeLocaleId;
            if (lm == null || string.IsNullOrEmpty(active))
            {
                return;
            }

            const string kWarningKey = "Menu.ACHIEVEMENTS_WARNING_MODS";
            var text = LocaleBannerText.For(active!);
            var entries = new Dictionary<string, string>
            {
                [kWarningKey] = text
            };

            if (TryAddLocaleSource(active!, new LocaleOverrideSource(entries), "ReapplyBannerForActiveLocaleFinal"))
            {
                // Single Release log at the final apply.
                s_Log.Info($"[Banner] Final re-apply for locale '{active}': \"{text}\"");
            }
        }

        private static void AddLocale(string localeId, IDictionarySource source)
        {
            // Use the same safe wrapper for your own locales; if I18NEverywhere or
            // some other localization hook is fragile, we don't let it crash anything.
            TryAddLocaleSource(localeId, source, "AddLocale");
        }
    }
}
