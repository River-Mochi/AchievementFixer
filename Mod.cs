// Mod.cs

namespace AchievementFixer
{
    using System.Collections.Generic;          // Dictionary<string,string>, HashSet<string>
    using System.Reflection;                   // Only for version number
    using Colossal;                            // IDictionarySource
    using Colossal.IO.AssetDatabase;           // AssetDatabase
    using Colossal.Localization;               // LocalizationManager
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
        /// Read Version from .csproj (3-part).
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
        private static readonly HashSet<string> s_InstalledLocales = new(); // locales where banner override was successfully installed
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
            AddLocaleSource("en-US", new LocaleEN(settings));
            AddLocaleSource("fr-FR", new LocaleFR(settings));
            AddLocaleSource("de-DE", new LocaleDE(settings));
            AddLocaleSource("es-ES", new LocaleES(settings));
            AddLocaleSource("it-IT", new LocaleIT(settings));
            AddLocaleSource("ja-JP", new LocaleJA(settings));
            AddLocaleSource("ko-KR", new LocaleKO(settings));
            AddLocaleSource("vi-VN", new LocaleVI(settings));
            AddLocaleSource("pl-PL", new LocalePL(settings));
            AddLocaleSource("pt-BR", new LocalePT_BR(settings));
            AddLocaleSource("tr-TR", new LocaleTR(settings));
            AddLocaleSource("zh-HANS", new LocaleZH_CN(settings));
            AddLocaleSource("zh-HANT", new LocaleZH_HANT(settings));

            // Load saved settings + Options UI
            AssetDatabase.global.LoadSettings("AchievementFixer", settings, new Settings(this));
            settings.RegisterInOptionsUI();

            // Ensure AF system runs after the game's trigger during the main loop.
            updateSystem.UpdateAfter<AchievementFixerSystem, AchievementTriggerSystem>(SystemUpdatePhase.MainLoop);

            // Lazy per-locale banner override (install for current locale now)
            LocalizationManager? lm = GameManager.instance?.localizationManager;
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
            LocalizationManager? lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                lm.onActiveDictionaryChanged -= OnLocaleChanged;    // locale event unsubscribe
            }

            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();   // optional, tidy
                Settings = null;
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
                LocalizationManager? lm = GameManager.instance?.localizationManager;
                var active = lm?.activeLocaleId ?? string.Empty;

                if (!string.IsNullOrEmpty(active))
                {
                    EnsureWarningOverrideFor(active); // install once for newly active locale (or retry if previous attempt failed)
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
        /// catches any exception (e.g. from I18NEverywhere) and logs once.
        /// No permanent blacklist — a locale can be retried later.
        /// </summary>
        private static bool TryAddLocaleSource(string localeId, IDictionarySource source, string context)
        {
            if (string.IsNullOrEmpty(localeId))
            {
                return false;
            }

            LocalizationManager? lm = GameManager.instance?.localizationManager;
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
                // Catch and log so it doesn't become a global NRE from another mod.
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
            if (string.IsNullOrEmpty(localeId))
            {
                return;
            }

            // Only skip if it's KNOWN the locale was successfully installed before.
            if (s_InstalledLocales.Contains(localeId))
            {
                return;
            }

            const string kWarningKey = "Menu.ACHIEVEMENTS_WARNING_MODS";    // game key to override
            var bannerText = LocaleBannerText.For(localeId);

            var entries = new Dictionary<string, string>
            {
                [kWarningKey] = bannerText
            };

            if (TryAddLocaleSource(localeId, new LocaleOverrideSource(entries), "EnsureWarningOverrideFor"))
            {
                // Mark as installed only after a successful AddSource.
                s_InstalledLocales.Add(localeId);
            }
        }

        /// <summary>
        /// Re-assert the banner override for the currently active locale.
        /// Cheap, “last writer wins” nudge.
        /// </summary>
        internal static void ReapplyBannerForActiveLocale()
        {
            LocalizationManager? lm = GameManager.instance?.localizationManager;
            var active = lm?.activeLocaleId;
            if (lm == null || string.IsNullOrEmpty(active))
            {
                return;
            }

            const string kWarningKey = "Menu.ACHIEVEMENTS_WARNING_MODS"; // game key for banner
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
            LocalizationManager? lm = GameManager.instance?.localizationManager;
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

        /// <summary>
        /// Helper for registering this mod's locale dictionaries (Options UI text) into the game's
        /// LocalizationManager.AddSource via TryAddLocaleSource.
        /// </summary>
        private static void AddLocaleSource(string localeId, IDictionarySource source)
        {
            // Use the same safe wrapper for our own locales; if I18NEverywhere or
            // some other localization hook is fragile, we don't let it crash anything.
            TryAddLocaleSource(localeId, source, "AddLocaleSource");
        }
    }
}
