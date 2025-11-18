// LocaleZH_HANT.cs

namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Traditional Chinese locale (zh-HANT)
    /// </summary>
    public class LocaleZH_HANT : IDictionarySource
    {
        private readonly Settings m_Setting;

        public LocaleZH_HANT(Settings setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.ModName },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "主頁" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "進階" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "說明" },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "資訊" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "支援連結" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• 成就目前已啟用;> 只要照常完成條件，成就就會自然解鎖。\n\n" +
                    "玩得開心！:)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "此模組在選單中顯示的名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "目前的模組版本號。" },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)),  "在瀏覽器中開啟此作者的 Paradox 模組頁面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),  "在瀏覽器中開啟 CS2 模組製作 Discord 伺服器。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "成就 Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "在瀏覽器中開啟成就 Wiki。" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "選擇成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "選擇要操作的成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "解鎖所選成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "立即**解鎖並完成**所選成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "清除所選成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "將所選成就標記為**未完成**。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "清除 / 重設此成就。\n\n是否繼續？" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• 提示：不用按這些進階按鈕，成就就已經是<預設啟用>狀態。\n\n" +
                    "• 若想查看詳細說明，將滑鼠移到任何按鈕上，右側面板會顯示解說。"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "使用 [DEBUG: 重設全部] 按鈕時請務必**小心**。若不小心按下，也可以用 [解鎖所選成就] 按鈕把已完成的成就找回來。"
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: 重設全部" }, // Button label
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**警告**：清除／重設所有成就，適合用來測試或除錯。\n" +
                    "如果誤觸，可以利用 [解鎖所選成就] 按鈕恢復成就。"
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "警告：所有成就將被重設為**未完成**狀態。是否繼續？"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
