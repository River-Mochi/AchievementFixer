using Colossal.Localization;  // LocalizationManager
using Game.SceneFlow;        // GameManager

namespace AchievementFixer
{
    /// <summary>
    /// Returns a localized achievement title
    /// If a key is missing, return the raw internalName.
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

            // Fallback: show raw ID to see misses during testing
            return internalName;
        }
    }
}
