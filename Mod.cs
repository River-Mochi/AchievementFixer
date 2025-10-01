// Mod.cs

using System.Collections.Generic;      // Dictionary<string,string> for locale override
using Colossal;                        // IDictionarySource
using Colossal.IO.AssetDatabase;       // AssetDatabase
using Colossal.Logging;                // ILog, LogManager
using Game;                            // UpdateSystem, SystemUpdatePhase
using Game.Achievements;               // AchievementTriggerSystem
using Game.Modding;                    // IMod
using Game.SceneFlow;                  // GameManager

namespace AchievementFixer
{
    public sealed class Mod : IMod
    {
        public static readonly ILog Log =
            LogManager.GetLogger("AchievementFixer").SetShowsErrorsInUI(false);

        public static Settings? Settings { get; private set; }

        // Single source for metadata name/version
        public const string Name = "Achievement Fixer";
        public const string VersionShort = "1.0.0";

        private static bool s_BannerLogged;
        private static bool s_Reapplying;

        // Supported locales (also used to install banner overrides)
        private static readonly string[] s_LocaleIds =
        {
            "en-US","fr-FR","de-DE","es-ES","it-IT","ja-JP","ko-KR","pt-BR","zh-HANS","zh-HANT","vi-VN",
        };

        public void OnLoad(UpdateSystem updateSystem)
        {
            // Meta banner once only
            Log.Info(nameof(OnLoad));
            if (!s_BannerLogged)
            {
                Log.Info($"{Name} {VersionShort}");
                s_BannerLogged = true;
            }

            // Settings object
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
            AddLocale("pt-BR", new LocalePT_BR(settings));
            AddLocale("zh-HANS", new LocaleZH_CN(settings));
            AddLocale("zh-HANT", new LocaleZH_HANT(settings));

            // Load saved settings + Options UI
            AssetDatabase.global.LoadSettings("AchievementFixer", settings, new Settings(this));
            settings.RegisterInOptionsUI();

            // Install banner override for all locales (last source wins)
            TryInstallWarningOverrideSource();

            // Fixer needs to run after achievement trigger system
            updateSystem.UpdateAfter<AchievementFixerSystem, AchievementTriggerSystem>(SystemUpdatePhase.MainLoop);

            // Subscribe to language changes
            var lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                Log.Info($"[Locale] Active: {lm.activeLocaleId}");
                lm.onActiveDictionaryChanged -= OnLocaleChanged;    // de-dupe in case already subscribed
                lm.onActiveDictionaryChanged += OnLocaleChanged;    // subscribe to fix mid-session changes
                Log.Info("[Locale] Subscribed to onActiveDictionaryChanged.");
            }
        }

        public void OnDispose()
        {
            Log.Info(nameof(OnDispose));

            var lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                lm.onActiveDictionaryChanged -= OnLocaleChanged;    // unsubscribe
            }

            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }
        }

        private static void AddLocale(string localeId, IDictionarySource source)
        {
            var lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                Log.Warn($"LocalizationManager null; cannot add locale '{localeId}' (skipped).");
                return;
            }
            lm.AddSource(localeId, source);
        }

        /// <summary>
        /// Install per-locale override for the built-in “achievements disabled because of mods” banner.
        /// </summary>
        private static void TryInstallWarningOverrideSource()
        {
            var lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                Log.Warn("No LocalizationManager; cannot add warning override.");
                return;
            }

            const string key = "Menu.ACHIEVEMENTS_WARNING_MODS";    // game key to override

            // Add to every supported locale (covers mid-session changes; last source wins)
            foreach (var localeId in s_LocaleIds)
            {
                var text = LocaleBannerText.For(localeId);
                var entries = new Dictionary<string, string> { [key] = text };
                lm.AddSource(localeId, new LocaleOverrideSource(entries));
            }

            Log.Info("OnLoad: Installed override for 'Achievements disabled...' (all locales).");
        }

        /// <summary>
        /// When active locale changes mid-session, re-assert banner override + rebuild Options UI.
        /// </summary>
        private void OnLocaleChanged()
        {
            var lm = GameManager.instance?.localizationManager;
            var active = lm?.activeLocaleId ?? "(unknown)";
            Log.Info($"[Locale] Dictionary change (active locale = {active})");

            if (s_Reapplying) return; // avoid re-entrancy storms
            s_Reapplying = true;
            try
            {
                // Re-assert custom banner in the active locale; last one wins
                if (lm != null && active != "(unknown)")
                {
                    const string key = "Menu.ACHIEVEMENTS_WARNING_MODS";
                    var text = LocaleBannerText.For(active);
                    lm.AddSource(active, new LocaleOverrideSource(new Dictionary<string, string> { [key] = text }));
                }

                // Rebuild Options UI
                var settings = Settings;
                if (settings != null)
                {
                    var keep = settings.SelectedAchievement ?? string.Empty;
                    settings.UnregisterInOptionsUI();
                    settings.RegisterInOptionsUI();
                    settings.SelectedAchievement = keep;
                    Log.Info($"[Locale] Options UI rebuilt (active = {active})");
                }
            }
            finally
            {
                s_Reapplying = false;
            }
        }
    }
}
