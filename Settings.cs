using System;
using System.Collections.Generic;
using System.Linq;
using Colossal.IO.AssetDatabase;  // [FileLocation]
using Colossal.PSI.Common;        // PlatformManager, AchievementId
using Game.Modding;
using Game.Settings;
using Game.UI.Widgets;            // DropdownItem<T>
using UnityEngine;

namespace AchievementFixer
{
    [FileLocation("ModsSettings/AchievementFixer/AchievementFixer")]    // location of persistent settings
    [SettingsUIGroupOrder(
        MainInfoGroup, ButtonGroup, NotesGroup,
        AdvRowActions, AdvRowDebug
    )]
    [SettingsUIShowGroupName(
        NotesGroup,     // show NOTES on Main tab
        AdvRowDebug     // show DEBUG on Advanced tab
    )]

    public class Settings : ModSetting
    {
        // ---- Tabs ----
        public const string MainTab = "Main";
        public const string AdvancedTab = "Advanced";

        // ---- Main Tab Groups ----
        public const string MainInfoGroup = "Info";
        public const string ButtonGroup = "Links";
        public const string NotesGroup = "Notes";

        // ---- Advanced Tab Groups ----
        public const string AdvRowActions = "Actions";
        public const string AdvRowDebug = "Debug";

        private const string UrlAchievementsWiki = "https://cs2.paradoxwikis.com/Achievements";

        public Settings(IMod mod) : base(mod) { }

        // ---- Main Meta ----
        [SettingsUISection(MainTab, MainInfoGroup)]
        public string NameDisplay => Mod.Name;

        [SettingsUISection(MainTab, MainInfoGroup)]
        public string VersionDisplay => Mod.VersionShort;

        // Main Wiki button
        [SettingsUIButtonGroup(ButtonGroup)]
        [SettingsUIButton]
        [SettingsUISection(MainTab, ButtonGroup)]
        public bool OpenAchievementsWikiButton
        {
            set
            {
                if (!value) return;
                try { Application.OpenURL(UrlAchievementsWiki); }
                catch (Exception ex) { Mod.Log.Warn($"Failed to open wiki: {ex.Message}"); }
            }
        }

        // Main Tab: Notes (multiline; content by Locale)
        [SettingsUIMultilineText]
        [SettingsUISection(MainTab, NotesGroup)]
        public string MainNotes => string.Empty;

        // Advanced tab: dropdown & Unlock + Clear in same row
        [SettingsUISection(AdvancedTab, AdvRowActions)]
        [SettingsUIDropdown(typeof(Settings), nameof(GetAchievementChoices))]
        public string SelectedAchievement { get; set; } = "";

        //Unlock Selected
        [SettingsUIButton]
        [SettingsUIButtonGroup(AdvRowActions)]
        [SettingsUISection(AdvancedTab, AdvRowActions)]
        public bool UnlockSelectedAchievement
        {
            set
            {
                if (!value) return;
                try
                {
                    if (!TryGetAchievementId(SelectedAchievement, out var id))
                    {
                        Mod.Log.Warn($"UnlockSelectedAchievement: could not resolve '{SelectedAchievement}'.");
                        return;
                    }

                    var pm = PlatformManager.instance;
                    if (pm == null)
                    {
                        Mod.Log.Warn("UnlockSelectedAchievement: PlatformManager.instance is null.");
                        return;
                    }

                    pm.UnlockAchievement(id);
                    Mod.Log.Info($"Requested UNLOCK of achievement: {SelectedAchievement} ({id}).");
                }
                catch (Exception ex)
                {
                    Mod.Log.Warn($"UnlockSelectedAchievement failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // Clear Selected (single)
        [SettingsUIButtonGroup(AdvRowActions)]
        [SettingsUIButton]
        [SettingsUIConfirmation] // Yes/No modal
        [SettingsUISection(AdvancedTab, AdvRowActions)]
        public bool ClearSelectedAchievement
        {
            set
            {
                if (!value) return; // user clicked "No"
                try
                {
                    if (!TryGetAchievementId(SelectedAchievement, out var id))
                    {
                        Mod.Log.Warn($"ClearSelectedAchievement: could not resolve '{SelectedAchievement}'.");
                        return;
                    }

                    var pm = PlatformManager.instance;
                    if (pm == null)
                    {
                        Mod.Log.Warn("ClearSelectedAchievement: PlatformManager.instance is null.");
                        return;
                    }

                    pm.ClearAchievement(id);
                    Mod.Log.Info($"Requested CLEAR (reset) of single achievement: {SelectedAchievement} ({id}).");
                }
                catch (Exception ex)
                {
                    Mod.Log.Warn($"ClearSelectedAchievement failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // Advanced: text under the two buttons
        [SettingsUIMultilineText]
        [SettingsUISection(AdvancedTab, AdvRowActions)]
        public string AdvancedAdvisory => string.Empty;

        // Advanced: DEBUG section (RESET All)
        [SettingsUIButton]
        [SettingsUIConfirmation]    // Yes/No Modal
        [SettingsUIButtonGroup(AdvRowDebug)]
        [SettingsUISection(AdvancedTab, AdvRowDebug)]
        public bool ResetAllAchievements
        {
            set
            {
                if (!value) return;
                try
                {
                    var pm = PlatformManager.instance;
                    if (pm == null)
                    {
                        Mod.Log.Warn("ResetAllAchievements: PlatformManager.instance is null.");
                        return;
                    }

                    pm.ResetAchievements();
                    Mod.Log.Info("Requested Reset of ALL platform achievements.");
                }
                catch (Exception ex)
                {
                    Mod.Log.Warn($"ResetAllAchievements failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // ---- Helpers ----

        /// <summary> Dropdown: value = internalName, display = friendly name.</summary>
        public static DropdownItem<string>[] GetAchievementChoices()
        {
            var pm = PlatformManager.instance;
            if (pm == null) return Array.Empty<DropdownItem<string>>();

            // Get stable ids first (internalName or fallback to id string)
            var ids = pm.EnumerateAchievements()
                        .Select(a => a.internalName ?? a.id.ToString());

            // Order by the visible, localized title (what players see)
            var ordered = ids.OrderBy(id => AchievementDisplay.Get(id), StringComparer.OrdinalIgnoreCase);

            // Build the dropdown items
            return ordered
                .Select(id => new DropdownItem<string> { value = id, displayName = AchievementDisplay.Get(id) })
                .ToArray();
        }

        private static bool TryGetAchievementId(string selectedValue, out AchievementId id)
        {
            id = default;
            var pm = PlatformManager.instance;
            if (pm == null) return false;

            foreach (var a in pm.EnumerateAchievements())
            {
                // Primary: match by internalName (dropdown stores in value)
                if (!string.IsNullOrEmpty(a.internalName) &&
                    string.Equals(a.internalName, selectedValue, StringComparison.OrdinalIgnoreCase))
                {
                    id = a.id;
                    return true;
                }

                // Fallback: allow selecting by a.id.ToString() just in case
                if (string.Equals(a.id.ToString(), selectedValue, StringComparison.OrdinalIgnoreCase))
                {
                    id = a.id;
                    return true;
                }
            }
            return false;
        }

        public override void SetDefaults()
        {
            SelectedAchievement = "";
        }
    }
}
