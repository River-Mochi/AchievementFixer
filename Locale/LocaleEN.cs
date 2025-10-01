using System.Collections.Generic;
using Colossal;
using Colossal.IO.AssetDatabase;
using UnityEngine;

namespace AchievementFixer
{
    /// <summary>
    /// English locale (en-US)
    /// </summary>
    public class LocaleEN : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleEN(Settings setting) { m_Setting = setting; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Main"     },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Advanced" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Info"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Links"  },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notes"  },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"   },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod"     },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Display name of this mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Current mod version." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Achievements Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Open the achievements wiki in your browser." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)), "Open the CS2 modding Discord in your browser." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "Notes:\n" +
                    "• Achievements are enabled now - just do the required tasks to naturally complete achievements.\n\n" +
                    "Enjoy! :)\n\n" +
                    "• Some achievements are not available until DLCs are release (e.g. Bridges & Ports DLC)." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Select achievement" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Choose an achievement to operate on." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "UNLOCK SELECTED" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Unlocks & Completes** the selected achievement." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "CLEAR SELECTED" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Marks the selected achievement as **not completed**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "CLEAR / RESET this achievement.\n\nContinue?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• This mod already enables achievements (default) without using any buttons in Advanced tab.\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**BE CAREFUL** using the [DEBUG: RESET ALL] button. If you accidentally use it, you can recover completed achievements with the [UNLOCK SELECTED] button." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: RESET ALL" }, //Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**WARNING**: clears/resets ALL achievements. Useful to debug or for testers.\n" +
                    "If you accidentally use this, you can get achievements back by using the [UNLOCK SELECTED] button." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "Warning Warning: RESET/CLEAR all achievements to a NOT complete status. Continue?" },
            };
        }

        public void Unload() { }
    }
}
