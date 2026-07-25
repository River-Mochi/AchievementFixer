// <copyright file="LocaleZH_HANT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

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
        private readonly AFSettings m_Setting;

        public LocaleZH_HANT(AFSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(AFSettings.MainTab),     "主頁" },
                { m_Setting.GetOptionTabLocaleID(AFSettings.AdvancedTab), "進階" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.NotesGroup),    "說明" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.MainInfoGroup), "資訊" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.ButtonGroup),   "支援連結" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowActions), "操作" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.MainNotes)),
                    "<• 成就目前已啟用;> 只要照常完成條件，成就就會自然解鎖。\n\n" +
                    "玩得開心！:)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.NameDisplay)),    "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.NameDisplay)),     "此模組在選單中顯示的名稱。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.VersionDisplay)),  "目前的模組版本號。" },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenParadoxButton)),  "在瀏覽器中開啟此作者的 Paradox 模組頁面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenDiscordButton)),  "在瀏覽器中開啟 CS2 模組製作 Discord 伺服器。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "成就 Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)),  "在瀏覽器中開啟成就 Wiki。" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.SelectedAchievement)),   "選擇成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.SelectedAchievement)),    "選擇要操作的成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.UnlockSelectedAchievement)), "解鎖所選成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.UnlockSelectedAchievement)),  "立即**解鎖並完成**所選成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ClearSelectedAchievement)),  "清除所選成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ClearSelectedAchievement)),   "將所選成就標記為**未完成**。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ClearSelectedAchievement)), "清除 / 重設此成就。\n\n是否繼續？" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "• 提示：不用按這些進階按鈕，成就就已經是<預設啟用>狀態。\n\n" +
                    "• 若想查看詳細說明，將滑鼠移到任何按鈕上，右側面板會顯示解說。"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "使用 [DEBUG: 重設全部] 按鈕時請務必**小心**。若不小心按下，也可以用 [解鎖所選成就] 按鈕把已完成的成就找回來。"
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAchievements)), "DEBUG - 重設全部" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "**警告**：清除／重設所有成就，適合用來測試或除錯。\n" +
                    "如果誤觸，可以利用 [解鎖所選成就] 按鈕恢復成就。\n" +
                    "[重設全部] 後可重新開始，再玩一次解鎖成就。"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAdvisory)),
                    "• <[重設全部]>成就，重新開始再解鎖一次。"
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "警告：所有成就將被重設為**未完成**狀態。是否繼續？"
                },
            };
        }

        public void Unload()
        {
        }
    }
}

