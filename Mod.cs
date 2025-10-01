using System.Collections.Generic;      // Dictionary<string,string> for local override
using Colossal;                        // IDictionarySource
using Colossal.IO.AssetDatabase;       // AssetDatabase
using Colossal.Logging;                // ILog, LogManager
using Game;                            // UpdateSystem
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

        // Add common locale variants
        private static readonly string[] s_LocaleIds =
        {
            "en-US","fr-FR","de-DE","es-ES","it-IT","ja-JP","ko-KR","pt-BR","zh-HANS","vi-VN",
        };

        public void OnLoad(UpdateSystem updateSystem)
        {
            // Log meta banner once only
            Log.Info(nameof(OnLoad));
            if (!s_BannerLogged)
            {
                Log.Info($"{Name} {VersionShort}");
                s_BannerLogged = true;
            }

            var settings = new Settings(this);
            Settings = settings;

            // Locales (register BEFORE Options UI)
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

            // Load any saved settings
            AssetDatabase.global.LoadSettings("AchievementFixer", settings, new Settings(this));

            // Options UI
            settings.RegisterInOptionsUI();

            // Hide Achievement warning about mods
            TryInstallWarningOverrideSource();

            // Keep enabled: run after achievement trigger system
            updateSystem.UpdateAfter<AchievementFixerSystem, AchievementTriggerSystem>(SystemUpdatePhase.MainLoop);

            var lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                Log.Info($"[Locale] Active: {lm.activeLocaleId}");  // Log active locale
                lm.onActiveDictionaryChanged -= OnLocaleChanged;    // de-dupe in case already subscribed
                lm.onActiveDictionaryChanged += OnLocaleChanged;    // subscribe
                Log.Info("[Locale] Subscribed to onActiveDictionaryChanged.");  // to fix dropdown list refresh
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
        /// Suppress in-game "achievements disabled" banner
        /// </summary>
        private static void TryInstallWarningOverrideSource()
        {
            var lm = GameManager.instance?.localizationManager;
            if (lm == null) { Log.Warn("No LocalizationManager; cannot add warning override."); return; }

            const string key = "Menu.ACHIEVEMENTS_WARNING_MODS";    // Locale key to override
            const string text = "Achievements enabled by Achievement Fixer."; // Custom text or use "" to hide

            var entries = new Dictionary<string, string> { [key] = text };

            // Add to every supported locale (last source wins; covers mid-session language changes)
            foreach (var localeId in s_LocaleIds)
                lm.AddSource(localeId, new LocaleOverrideSource(entries));

            Log.Info("Installed override for 'Achievements disabled because of mods.'");
        }

        // Rebuild Options UI when active language changes so dropdown
        // is re-populated from the new dictionary
        private void OnLocaleChanged()
        {
            try
            {
                var settings = Settings;
                if (settings == null) return;

                // Non-null value for restore
                var keep = settings.SelectedAchievement ?? string.Empty;

                settings.UnregisterInOptionsUI();
                settings.RegisterInOptionsUI();

                settings.SelectedAchievement = keep; // non-null now
                Log.Info($"[Locale] Options UI rebuilt");
            }
            catch (System.Exception ex)
            {
                Log.Warn($"[Locale] Rebuild after locale change failed: {ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}
