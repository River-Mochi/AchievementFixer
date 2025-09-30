using System.Collections.Generic;
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
        public static readonly ILog log =
            LogManager.GetLogger("AchievementFixer").SetShowsErrorsInUI(false);

        public static Settings? Settings { get; private set; }

        // Single source for metadata name/version
        public const string Name = "Achievement Fixer";
        public const string VersionShort = "1.0.0";

        private static bool s_BannerLogged;

        // Add common locale variants
        internal static readonly string[] s_LocaleIds =
        {
            "en-US","fr-FR","de-DE","es-ES","it-IT","ja-JP","ko-KR","vi-VN","pt-BR","zh-HANS",
        };

        public void OnLoad(UpdateSystem updateSystem)
        {
            log.Info(nameof(OnLoad));
            if (!s_BannerLogged)
            {
                log.Info($"{Name} {VersionShort}");
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

            // Hide Achievement warning @ mods strings
            TryInstallWarningOverrideSource();

            // Keep enabled: run after achievement trigger system
            updateSystem.UpdateAfter<AchievementFixerSystem, AchievementTriggerSystem>(SystemUpdatePhase.MainLoop);

            var lm = GameManager.instance?.localizationManager;
            if (lm != null)
            {
                log.Info($"[Locale] Active: {lm.activeLocaleId}");  // log active locale
                lm.onActiveDictionaryChanged -= OnLocaleChanged;    // de-dupe in case already subscribed
                lm.onActiveDictionaryChanged += OnLocaleChanged;    // subscribe
                log.Info("[Locale] Subscribed to onActiveDictionaryChanged.");  // to fix dropdown list refresh
            }
        }

        public void OnDispose()
        {
            log.Info(nameof(OnDispose));

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
            if (lm != null) lm.AddSource(localeId, source);
            else log.Warn($"LocalizationManager null; cannot add locale '{localeId}'.");
        }

        /// <summary>
        /// Inject tiny locale map so game's banner key resolves to our text
        /// Map menu and Achievements panel no longer show "achievements disabled"
        /// </summary>
        private static void TryInstallWarningOverrideSource()
        {
            var lm = GameManager.instance?.localizationManager;
            if (lm == null) { Mod.log.Warn("No LocalizationManager; cannot add warning override."); return; }


            const string key = "Menu.ACHIEVEMENTS_WARNING_MODS";              // key for string
            const string text = "Achievements Enabled by Achievement Fixer."; // or "" to fully hide

            var entries = new Dictionary<string, string> { [key] = text };

            var active = lm.activeLocaleId;
            if (!string.IsNullOrEmpty(active))
                lm.AddSource(active, new MemoryLocalizationSource(entries));    // call AddSource AFTER game sources so 'last source wins'

            // Override to other supported locales when there is a mid-session language change
            foreach (var localeId in s_LocaleIds)
                lm.AddSource(localeId, new MemoryLocalizationSource(entries));
            Mod.log.Info("Installed override for 'Achievements disabled because of mods.'");
        }

        // Rebuild Options UI when active language changes so dropdown
        // is re-populated from the new dictionary
        private void OnLocaleChanged()
        {
            try
            {
                if (Settings == null) return; // nothing to do

                // keep what was selected
                var keep = Settings?.SelectedAchievement;

                Settings.UnregisterInOptionsUI();
                Settings.RegisterInOptionsUI();

                Settings.SelectedAchievement = keep; // restore
                log.Info($"[Locale] Options UI rebuilt; restored selection: '{keep}'.");
            }
            catch (System.Exception ex)
            {
                log.Warn($"[Locale] Rebuild after locale change failed: {ex.GetType().Name}: {ex.Message}");
            }
        }
    }
    /// <summary> In-memory localization source </summary>
    // Helper - override banner localization key map
    internal sealed class MemoryLocalizationSource : IDictionarySource
    {
        private readonly Dictionary<string, string> m_Entries;
        public MemoryLocalizationSource(Dictionary<string, string> entries) { m_Entries = entries; }
        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts) => m_Entries;
        public void Unload() { }
    }
}
