// Settings.cs
namespace AchievementFixer
{
    using System;                     // Exception handling (try/catch)
    using System.Linq;                // LINQ (Select, OrderBy, ToArray)
    using Colossal.IO.AssetDatabase;  // [FileLocation]
    using Colossal.PSI.Common;        // PlatformManager, AchievementId
    using Game.Modding;               // IMod, ModSetting
    using Game.Settings;              // SettingsUI
    using Game.UI.Widgets;            // DropdownItem<T>
    using UnityEngine;                // Application.OpenURL

    [FileLocation("ModsSettings/AchievementFixer/AchievementFixer")]
    [SettingsUIGroupOrder(
        NotesGroup, MainInfoGroup, ButtonGroup,
        AdvRowActions, AdvRowDebug
    )]
    [SettingsUIShowGroupName(
        NotesGroup,       // show NOTES on Main tab
        ButtonGroup,      // show SUPPORT LINKS on Main tab
        AdvRowDebug       // show DEBUG on Advanced tab
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

        // ---- Constants ----
        private const string UrlParadox = "https://mods.paradoxplaza.com/uploaded?orderBy=desc&sortBy=best&time=alltime";
        private const string UrlDiscord = "https://discord.gg/HTav7ARPs2";
        private const string UrlAchievementsWiki = "https://cs2.paradoxwikis.com/Achievements";

        public Settings(IMod mod) : base(mod) { }

        // ---- Main Meta ----
        [SettingsUISection(MainTab, MainInfoGroup)]
        public string NameDisplay => Mod.ModName;

        [SettingsUISection(MainTab, MainInfoGroup)]
        public string VersionDisplay => Mod.ModVersion;

        // Main - Paradox button
        [SettingsUIButtonGroup(ButtonGroup)]
        [SettingsUIButton]
        [SettingsUISection(MainTab, ButtonGroup)]
        public bool OpenParadoxButton
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    Application.OpenURL(UrlParadox);
                }
                catch (Exception ex)
                {
                    Mod.s_Log.Warn($"Failed to open Paradox: {ex.Message}");
                }
            }
        }

        // Main - Discord button
        [SettingsUIButtonGroup(ButtonGroup)]
        [SettingsUIButton]
        [SettingsUISection(MainTab, ButtonGroup)]
        public bool OpenDiscordButton
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    Application.OpenURL(UrlDiscord);
                }
                catch (Exception ex)
                {
                    Mod.s_Log.Warn($"Failed to open Discord: {ex.Message}");
                }
            }
        }

        // Main - Wiki button
        [SettingsUIButtonGroup(ButtonGroup)]
        [SettingsUIButton]
        [SettingsUISection(MainTab, ButtonGroup)]
        public bool OpenAchievementsWikiButton
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    Application.OpenURL(UrlAchievementsWiki);
                }
                catch (Exception ex)
                {
                    Mod.s_Log.Warn($"Failed to open wiki: {ex.Message}");
                }
            }
        }

        // Main Tab: Notes (multiline; content by Locale)
        [SettingsUIMultilineText]
        [SettingsUISection(MainTab, NotesGroup)]
        public string MainNotes => string.Empty;

        // ---- Advanced tab: Actions row ----

        // Dropdown: Select achievement (value = internal Name)
        [SettingsUISection(AdvancedTab, AdvRowActions)]
        [SettingsUIDropdown(typeof(Settings), nameof(GetAchievementChoices))]
        public string SelectedAchievement { get; set; } = "";

        // UNLOCK SELECTED
        [SettingsUIButton]
        [SettingsUIButtonGroup(AdvRowActions)]
        [SettingsUISection(AdvancedTab, AdvRowActions)]
        public bool UnlockSelectedAchievement
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    if (!TryGetAchievementId(SelectedAchievement, out AchievementId id))
                    {
                        Mod.s_Log.Warn($"Unlock: could not resolve '{SelectedAchievement}'.");
                        return;
                    }

                    PlatformManager pm = PlatformManager.instance;
                    if (pm == null)
                    {
                        Mod.s_Log.Warn("Unlock: PlatformManager.instance is null.");
                        return;
                    }

#if DEBUG
                    Mod.s_Log.Info($"[UI] UnlockSelected → before call; achievementsEnabled={pm.achievementsEnabled}");
#endif
                    pm.UnlockAchievement(id);
#if DEBUG
                    Mod.s_Log.Info($"[UI] UnlockSelected → after call; achievementsEnabled={pm.achievementsEnabled}");
#endif

                    // Post-check
                    var ok = pm.GetAchievement(id, out IAchievement? a) && a.achieved;
                    Mod.s_Log.Info($"UnlockSelected: \"{AchievementDisplay.Get(SelectedAchievement)}\" → {(ok ? "Enabled" : "No change")}");
                }
                catch (Exception ex)
                {
                    Mod.s_Log.Warn($"UnlockSelected failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // CLEAR SELECTED
        [SettingsUIButton]
        [SettingsUIButtonGroup(AdvRowActions)]
        [SettingsUIConfirmation]
        [SettingsUISection(AdvancedTab, AdvRowActions)]
        public bool ClearSelectedAchievement
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    if (!TryGetAchievementId(SelectedAchievement, out AchievementId id))
                    {
                        Mod.s_Log.Warn($"Clear: could not resolve '{SelectedAchievement}'.");
                        return;
                    }

                    PlatformManager pm = PlatformManager.instance;
                    if (pm == null)
                    {
                        Mod.s_Log.Warn("Clear: PlatformManager.instance is null.");
                        return;
                    }

#if DEBUG
                    Mod.s_Log.Info($"[UI] ClearSelected → before call; achievementsEnabled={pm.achievementsEnabled}");
#endif
                    pm.ClearAchievement(id);
#if DEBUG
                    Mod.s_Log.Info($"[UI] ClearSelected → after call; achievementsEnabled={pm.achievementsEnabled}");
#endif

                    // Post-check & single friendly line
                    var cleared = pm.GetAchievement(id, out IAchievement? a) && !a.achieved;
                    Mod.s_Log.Info($"ClearSelected: \"{AchievementDisplay.Get(SelectedAchievement)}\" → {(cleared ? "Disabled" : "No change")}");
                }
                catch (Exception ex)
                {
                    Mod.s_Log.Warn($"ClearSelected failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // Advisory text under the two buttons
        [SettingsUIMultilineText]
        [SettingsUISection(AdvancedTab, AdvRowActions)]
        public string AdvancedAdvisory => string.Empty;

        // ---- Advanced tab: DEBUG row ----

        // DEBUG: RESET ALL
        [SettingsUIButton]
        [SettingsUIConfirmation]    // Yes/No Modal
        [SettingsUIButtonGroup(AdvRowDebug)]
        [SettingsUISection(AdvancedTab, AdvRowDebug)]
        public bool ResetAllAchievements
        {
            set
            {
                if (!value)
                {
                    return;
                }

                try
                {
                    PlatformManager pm = PlatformManager.instance;
                    if (pm == null)
                    {
                        Mod.s_Log.Warn("ResetAllAchievements: PlatformManager.instance is null.");
                        return;
                    }

#if DEBUG
                    Mod.s_Log.Info($"[UI] ResetAll → about to call ResetAchievements; achievementsEnabled={pm.achievementsEnabled}");
#endif

                    pm.ResetAchievements();
#if DEBUG
                    Mod.s_Log.Info($"[UI] ResetAll → call returned; achievementsEnabled={pm.achievementsEnabled}");
#endif

                    Mod.s_Log.Info("Requested Reset of ALL platform achievements.");
                }
                catch (Exception ex)
                {
                    Mod.s_Log.Warn($"ResetAllAchievements failed: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }

        // ---- Helpers ----

        /// <summary> Dropdown: value = internalName, display = friendly name.</summary>
        public static DropdownItem<string>[] GetAchievementChoices()
        {
            PlatformManager pm = PlatformManager.instance;
            if (pm == null)
            {
                return Array.Empty<DropdownItem<string>>();
            }

            System.Collections.Generic.IEnumerable<string> ids = pm.EnumerateAchievements()
                .Select(a => a.internalName ?? a.id.ToString());

            IOrderedEnumerable<string> ordered = ids.OrderBy(id => AchievementDisplay.Get(id),
                                      StringComparer.CurrentCultureIgnoreCase);

            return ordered
                .Select(id => new DropdownItem<string>
                {
                    value = id,
                    displayName = AchievementDisplay.Get(id)
                })
                .ToArray();
        }

        private static bool TryGetAchievementId(string selectedValue, out AchievementId id)
        {
            id = default;
            PlatformManager pm = PlatformManager.instance;
            if (pm == null)
            {
                return false;
            }

            foreach (IAchievement? a in pm.EnumerateAchievements())
            {
                // Primary: match by internalName (dropdown value)
                if (!string.IsNullOrEmpty(a.internalName) &&
                    string.Equals(a.internalName, selectedValue, StringComparison.OrdinalIgnoreCase))
                {
                    id = a.id;
                    return true;
                }

                // Fallback: allow selecting by a.id.ToString()
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
