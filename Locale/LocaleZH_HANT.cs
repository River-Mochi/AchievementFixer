using System.Collections.Generic;
using Colossal;
using Colossal.IO.AssetDatabase;
using UnityEngine;

namespace AchievementFixer
{
    /// <summary>
    /// Traditional Chinese locale (zh-HANT)
    /// </summary>
    public class LocaleZH_HANT : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleZH_HANT(Settings setting) { m_Setting = setting; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "主頁" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "進階" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "資訊" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "連結" },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "備註" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "此模組的顯示名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "目前模組版本。" },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "成就維基" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),   "在瀏覽器開啟成就維基。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)),           "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),           "在瀏覽器開啟 CS2 Modding Discord。" },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "備註：\n" +
                    "• 成就已啟用—照正常玩法完成條件就好。\n\n" +
                    "玩得開心！:)\n\n" +
                    "• 有些成就需等到 DLC 發售後才會出現（例如 Bridges & Ports）。" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "選擇成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "選擇要操作的成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "解鎖所選" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "將所選成就**解鎖並設為完成**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "清除所選" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "把所選成就標記為**未完成**。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)),"清除／重設此成就。\n\n要繼續嗎？" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• 不用按進階頁面任何按鈕，模組預設就會啟用成就。\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**請小心** 使用【DEBUG：全部重設】。若誤按，可用【解鎖所選】補回完成的成就。" },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG：全部重設" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**警告**：清除／重設所有成就，供除錯或測試用。\n" +
                    "若誤按，可用【解鎖所選】把想要的成就補回來。" },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "警告：將所有成就重設為未完成。要繼續嗎？" },
            };
        }

        public void Unload() { }
    }
}
