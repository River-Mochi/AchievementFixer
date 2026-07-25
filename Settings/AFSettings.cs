// <copyright file="AFSettings.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// AFSettings.cs
namespace AchievementFixer
{
    using System;                     // Exception handling (try/catch)
    using System.Linq;                // LINQ (Select, OrderBy, ToArray)
    using Colossal.IO.AssetDatabase;  // [FileLocation]
    using Colossal.PSI.Common;        // PlatformManager, AchievementId
    using CS2Shared.RiverMochi;        // LogUtils
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
    public sealed class AFSettings : ModSetting
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
        private const string UrlParadox =
            "https://mods.paradoxplaza.com/authors/River-mochi/cities_skylines_2?games=cities_skylines_2&orderBy=desc&sortBy=best&time=alltime";
        private const string UrlDiscord = "https://discord.gg/gwXgvtyhjc";
        private const string UrlAchievementsWiki = "https://cs2.paradoxwikis.com/Achievements";

        public AFSettings(IMod mod) : base(mod)
        {
        }

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
                    LogUtils.Warn("Failed to open Paradox.", ex);
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
                    LogUtils.Warn("Failed to open Discord.", ex);
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
                    LogUtils.Warn("Failed to open wiki.", ex);
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
        [SettingsUIDropdown(typeof(AFSettings), nameof(GetAchievementChoices))]
        public string SelectedAchievement { get; set; } = string.Empty;

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
                        LogUtils.Warn($"Unlock: could not resolve '{SelectedAchievement}'.");
                        return;
                    }

                    PlatformManager pm = PlatformManager.instance;
                    if (pm == null)
                    {
                        LogUtils.Warn("Unlock: PlatformManager.instance is null.");
                        return;
                    }

#if DEBUG
                    LogUtils.Info(
                        $"[UI] UnlockSelected → before call; achievementsEnabled={pm.achievementsEnabled}");
#endif
                    pm.UnlockAchievement(id);
#if DEBUG
                    LogUtils.Info(
                        $"[UI] UnlockSelected → after call; achievementsEnabled={pm.achievementsEnabled}");
#endif

                    // Post-check
                    bool ok = pm.GetAchievement(id, out IAchievement? a) && a.achieved;
                    LogUtils.Info(
                        $"UnlockSelected: \"{AchievementDisplay.Get(SelectedAchievement)}\" → " +
                        $"{(ok ? "Enabled" : "No change")}");
                }
                catch (Exception ex)
                {
                    LogUtils.Warn("UnlockSelected failed.", ex);
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
                        LogUtils.Warn($"Clear: could not resolve '{SelectedAchievement}'.");
                        return;
                    }

                    PlatformManager pm = PlatformManager.instance;
                    if (pm == null)
                    {
                        LogUtils.Warn("Clear: PlatformManager.instance is null.");
                        return;
                    }

#if DEBUG
                    LogUtils.Info(
                        $"[UI] ClearSelected → before call; achievementsEnabled={pm.achievementsEnabled}");
#endif
                    pm.ClearAchievement(id);
#if DEBUG
                    LogUtils.Info(
                        $"[UI] ClearSelected → after call; achievementsEnabled={pm.achievementsEnabled}");
#endif

                    // Post-check & single friendly line
                    bool cleared = pm.GetAchievement(id, out IAchievement? a) && !a.achieved;
                    LogUtils.Info(
                        $"ClearSelected: \"{AchievementDisplay.Get(SelectedAchievement)}\" → " +
                        $"{(cleared ? "Disabled" : "No change")}");
                }
                catch (Exception ex)
                {
                    LogUtils.Warn("ClearSelected failed.", ex);
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
                        LogUtils.Warn("ResetAllAchievements: PlatformManager.instance is null.");
                        return;
                    }

#if DEBUG
                    LogUtils.Info(
                        $"[UI] ResetAll → about to call ResetAchievements; achievementsEnabled={pm.achievementsEnabled}");
#endif

                    pm.ResetAchievements();
#if DEBUG
                    LogUtils.Info(
                        $"[UI] ResetAll → call returned; achievementsEnabled={pm.achievementsEnabled}");
#endif

                    LogUtils.Info("Requested Reset of ALL platform achievements.");
                }
                catch (Exception ex)
                {
                    LogUtils.Warn("ResetAllAchievements failed.", ex);
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

            return pm.EnumerateAchievements()
                .Select(a => a.internalName ?? a.id.ToString())
                .OrderBy(
                    id => AchievementDisplay.Get(id),
                    StringComparer.CurrentCultureIgnoreCase)
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
                    string.Equals(
                        a.internalName,
                        selectedValue,
                        StringComparison.OrdinalIgnoreCase))
                {
                    id = a.id;
                    return true;
                }

                // Fallback: allow selecting by a.id.ToString()
                if (string.Equals(
                    a.id.ToString(),
                    selectedValue,
                    StringComparison.OrdinalIgnoreCase))
                {
                    id = a.id;
                    return true;
                }
            }

            return false;
        }

        public override void SetDefaults()
        {
            SelectedAchievement = string.Empty;
        }
    }
}
