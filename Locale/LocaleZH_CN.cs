// <copyright file="LocaleZH_CN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleZH_CN.cs

namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Simplified Chinese locale (zh-HANS)
    /// </summary>
    public class LocaleZH_CN : IDictionarySource
    {
        private readonly AFSettings m_Setting;

        public LocaleZH_CN(AFSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(AFSettings.MainTab),     "主界面" },
                { m_Setting.GetOptionTabLocaleID(AFSettings.AdvancedTab), "高级" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.NotesGroup),    "说明" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.MainInfoGroup), "信息" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.ButtonGroup),   "支持链接" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowActions), "操作" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.MainNotes)),
                    "<• 成就是已启用状态;> 只要按正常方式完成要求，成就就会自然解锁。\n\n" +
                    "玩得开心！:)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.NameDisplay)),    "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.NameDisplay)),     "此模组在菜单中显示的名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.VersionDisplay)),  "当前模组版本号。" },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenParadoxButton)),  "在浏览器中打开此作者的 Paradox 模组页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenDiscordButton)),  "在浏览器中打开 CS2 Mod 制作 Discord 服务器。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "成就 Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)),  "在浏览器中打开成就 Wiki。" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.SelectedAchievement)),   "选择成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.SelectedAchievement)),    "选择要操作的成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.UnlockSelectedAchievement)), "解锁所选成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.UnlockSelectedAchievement)),  "立即**解锁并完成**所选成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ClearSelectedAchievement)),  "清除所选成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ClearSelectedAchievement)),   "将所选成就标记为**未完成**。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ClearSelectedAchievement)), "清除 / 重置此成就。\n\n是否继续？" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "• 提示：在不使用这些高级按钮的情况下，成就已经处于<已启用>（默认）状态。\n\n" +
                    "• 如果想了解细节，将鼠标悬停在任意按钮上，右侧面板会显示说明。"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "使用 [DEBUG: 重置全部] 按钮时请务必**小心**。如果误点，仍可通过 [解锁所选成就] 按钮恢复已完成的成就。"
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAchievements)), "DEBUG - 重置全部" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "**警告**：清除/重置所有成就，适用于测试或调试。\n" +
                    "如果不小心点击了，可以通过 [解锁所选成就] 按钮恢复成就。\n" +
                    "[重置全部] 后可从头开始，再玩一次解锁成就。"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAdvisory)),
                    "• <[重置全部]>成就，从头开始再解锁一次。"
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "警告：所有成就将被重置为**未完成**状态。是否继续？"
                },
            };
        }

        public void Unload()
        {
        }
    }
}

