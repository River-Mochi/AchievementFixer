// Mod.cs
namespace AchievementFixer
{
    using System.Collections.Generic;          // Dictionary<string,string>
    using Colossal;                            // IDictionarySource
    using Colossal.IO.AssetDatabase;           // AssetDatabase
    using Colossal.Logging;                    // ILog, LogManager
    using Game;                                // UpdateSystem, SystemUpdatePhase
    using Game.Achievements;                   // AchievementTriggerSystem (phase anchor)
    using Game.Modding;                        // IMod
    using Game.SceneFlow;                      // GameManager

    public sealed class Mod : IMod
    {
        // ----- Public constants / metadata -----
        public const string Name = "Achievement Fixer";
        public const string VersionShort = "1.0.3";

        // ----- Logger & public properties -----
        public static readonly ILog Log =
            LogManager.GetLogger("AchievementFixer").SetShowsErrorsInUI(false);

        public static Settings? Settings
        {
            get; private set;
        }

        // ----- Private state -----
        private static readonly HashSet<string> s_InstalledLocales = new(); // prevent duplicate installs
        private static bool s_BannerLogged;
        private static bool s_Reapplying;

        // ----- DEBUG helper (no attributes; no ambiguity) -----
#if DEBUG
        private static void DebugLog(string message) => Log.Info(message);
#else
        private static void DebugLog(string message)
        {
        }
#endif

        // ----- IMod -----
        public void OnLoad(UpdateSystem updateSystem)
        {
            // metadata banner (once)
            Log.Info($"Achievement Fixer v{VersionShort} OnLoad");

            if (!s_BannerLogged)
                s_BannerLogged = true;

            // Settings object (must exist before locales so labels resolve)
            var settings = new Settings(this);
            Settings = settings;

            // Register locales BEFORE register Options UI
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
            Colossal.Localization.LocalizationManager? lm = GameManager.instance?.localizationManager;
            var activeId = lm?.activeLocaleId;
            if (!string.IsNullOrEmpty(activeId))
                EnsureWarningOverrideFor(activeId!);

            // Subscribe once for future locale switches
            if (lm != null)
            {
                lm.onActiveDictionaryChanged -= OnLocaleChanged; // avoid double subscription
                lm.onActiveDictionaryChanged += OnLocaleChanged;
            }
        }

        public void OnDispose()
        {
            Colossal.Localization.LocalizationManager? lm = GameManager.instance?.localizationManager;
            if (lm != null)
                lm.onActiveDictionaryChanged -= OnLocaleChanged;

            Log.Info("OnDispose");
        }

        // ----- Event handlers -----
        private void OnLocaleChanged()
        {
            if (s_Reapplying)
                return; // debounce re-entrancy
            s_Reapplying = true;
            try
            {
                Colossal.Localization.LocalizationManager? lm = GameManager.instance?.localizationManager;
                var active = lm?.activeLocaleId ?? string.Empty;

                if (!string.IsNullOrEmpty(active))
                    EnsureWarningOverrideFor(active); // install once for newly active locale

                // Keep Options UI consistent
                Settings?.RegisterInOptionsUI();

                DebugLog($"[Locale] changed → {active}");
            }
            finally
            {
                s_Reapplying = false;
            }
        }

        // ----- Private helpers -----

        /// <summary>
        /// Install per-locale override for the built-in “achievements disabled by mods” banner.
        /// Done once per locale; readable step-by-step (no giant one-liner).
        /// </summary>
        private static void EnsureWarningOverrideFor(string localeId)
        {
            Colossal.Localization.LocalizationManager? lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                Log.Warn("No LocalizationManager; cannot add warning override.");
                return;
            }

            // Only once per locale
            if (!s_InstalledLocales.Add(localeId))
                return;

            const string kWarningKey = "Menu.ACHIEVEMENTS_WARNING_MODS";    // game key to override

            var bannerText = GetBannerTextFor(localeId);

            var entries = new Dictionary<string, string>
            {
                [kWarningKey] = bannerText
            };

            var source = new LocaleOverrideSource(entries);
            lm.AddSource(localeId, source);

            // DEBUG-only to keep Release quiet.
            DebugLog($"Banner enabled override for locale: {localeId}");
        }

        /// <summary>
        /// Localized one-liner banner text, delegated to the centralized table.
        /// </summary>
        private static string GetBannerTextFor(string localeId) => LocaleBannerText.For(localeId);

        private static void AddLocale(string localeId, IDictionarySource source)
        {
            Colossal.Localization.LocalizationManager? lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                Log.Warn("No LocalizationManager; cannot add locale source.");
                return;
            }
            lm.AddSource(localeId, source);
        }
    }
}
