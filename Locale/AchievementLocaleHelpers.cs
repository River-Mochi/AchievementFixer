// AchievementLocaleHelpers.cs
namespace AchievementFixer
{
    using System.Collections.Generic;   // Dictionary
    using Colossal;                     // IDictionarySource
    using Colossal.Localization;        // LocalizationManager, LocalizationDictionary
    using Game.SceneFlow;               // GameManager

    /// <summary>
    /// Returns a localized achievement title; falls back to internalName.
    /// Used for the dropdown list in Advanced tab.
    /// </summary>
    internal static class AchievementDisplay
    {
        public static string Get(string internalName)
        {
            if (string.IsNullOrWhiteSpace(internalName))
            {
                return string.Empty;
            }

            LocalizationManager? localizationManager = GameManager.instance?.localizationManager;
            LocalizationDictionary? dict = localizationManager?.activeDictionary;
            if (dict == null)
            {
                // No dictionary yet; show raw ID.
                return internalName;
            }

            var key = $"Achievements.TITLE[{internalName}]";
            if (dict.TryGetValue(key, out var localized) && !string.IsNullOrWhiteSpace(localized))
            {
                // friendly title (spaced, correct casing, punctuation)
                return localized;
            }

            // Fallback: show raw ID to see misses during testing
            return internalName;
        }
    }

    /// <summary>
    /// Tiny dictionary-backed source for overriding one or more locale keys.
    /// Used for the achievements banner.
    /// </summary>
    internal sealed class LocaleOverrideSource : IDictionarySource
    {
        private readonly Dictionary<string, string> m_Entries;

        public LocaleOverrideSource(Dictionary<string, string> entries)
        {
            m_Entries = entries;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return m_Entries;
        }

        public void Unload()
        {
        }
    }

    /// <summary>
    /// Per-locale banner text for the "achievements disabled" toast override.
    /// </summary>
    internal static class LocaleBannerText
    {
        private static readonly Dictionary<string, string> s_Text = new Dictionary<string, string>
        {
            ["en-US"] = "Achievements enabled by Achievement Fixer.",
            ["de-DE"] = "Erfolge aktiviert durch Achievement Fixer.",
            ["es-ES"] = "Logros activados por Achievement Fixer.",
            ["fr-FR"] = "Succès activés par Achievement Fixer.",
            ["it-IT"] = "Obiettivi attivati da Achievement Fixer.",
            ["ja-JP"] = "実績は Achievement Fixer によって有効化されています。",
            ["ko-KR"] = "업적이 Achievement Fixer에 의해 활성화되었습니다.",
            ["pt-BR"] = "Conquistas ativadas por Achievement Fixer.",
            ["pl-PL"] = "Osiągnięcia włączone przez Achievement Fixer.",
            ["vi-VN"] = "Thành tựu được bật bởi Achievement Fixer.",
            ["zh-HANS"] = "成就已由 Achievement Fixer 启用。",
            ["zh-HANT"] = "成就已由 Achievement Fixer 啟用。"
        };

        public static string For(string localeId)
        {
            if (s_Text.TryGetValue(localeId, out var text))
            {
                return text;
            }

            // Fallback to English
            return s_Text["en-US"];
        }
    }
}
