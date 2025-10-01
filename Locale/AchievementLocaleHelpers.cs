using System.Collections.Generic;   // Dictionary
using Colossal;                     // IDictionarySource
using Colossal.Localization;        // LocalizationManager
using Game.SceneFlow;               // GameManager

namespace AchievementFixer
{
    /// <summary>
    /// Returns a localized achievement title; falls back to internalName.
    /// </summary>
    internal static class AchievementDisplay
    {
        public static string Get(string internalName)
        {
            if (string.IsNullOrWhiteSpace(internalName))
                return string.Empty;

            var lm = GameManager.instance?.localizationManager as LocalizationManager;
            var dict = lm?.activeDictionary;
            var key = $"Achievements.TITLE[{internalName}]";

            if (dict != null &&
                dict.TryGetValue(key, out var localized) &&
                !string.IsNullOrWhiteSpace(localized))
            {
                return localized;  // friendly title (spaced, correct casing, punctuation)
            }

            return internalName;  // Fallback: show raw ID to see misses during testing
        }
    }

    /// <summary>Tiny dictionary-backed source for overriding specific locale keys.</summary>
    // Helper - override banner localization key map
    internal sealed class LocaleOverrideSource : IDictionarySource
    {
        private readonly Dictionary<string, string> m_Entries;
        public LocaleOverrideSource(Dictionary<string, string> entries) => m_Entries = entries;

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts) => m_Entries;

        public void Unload() { }
    }

}
