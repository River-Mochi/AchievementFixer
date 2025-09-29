using Colossal.Localization;  // LocalizationManager
using Game.SceneFlow;        // GameManager

namespace AchievementFixer
{
    /// <summary>
    /// Get achievement display names via game's localization dictionary
    /// If a key is missing, return the raw internal name.
    /// </summary>
    internal static class AchievementDisplay
    {
        public static string Get(string internalName)
        {
            if (string.IsNullOrWhiteSpace(internalName))
                return string.Empty;

            var lm = GameManager.instance?.localizationManager as LocalizationManager;
            var dict = lm?.activeDictionary;
            if (dict != null && dict.TryGetValue($"Achievements.TITLE[{internalName}]", out var value) && !string.IsNullOrWhiteSpace(value))
                return value;  // localized, spaced, correct casing, punctuation

            // Not found in dictionary → show raw ID to see misses during testing
            return internalName;
        }
    }
}
