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
        private readonly Settings m_Setting;

        public LocaleZH_CN(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "主界面" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "高级" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "说明" },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "信息" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "支持链接" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• 成就是已启用状态;> 只要按正常方式完成要求，成就就会自然解锁。\n\n" +
                    "玩得开心！:)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "此模组在菜单中显示的名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "当前模组版本号。" },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)),  "在浏览器中打开此作者的 Paradox 模组页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),  "在浏览器中打开 CS2 Mod 制作 Discord 服务器。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "成就 Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "在浏览器中打开成就 Wiki。" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "选择成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "选择要操作的成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "解锁所选成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "立即**解锁并完成**所选成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "清除所选成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "将所选成就标记为**未完成**。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "清除 / 重置此成就。\n\n是否继续？" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• 提示：在不使用这些高级按钮的情况下，成就已经处于<已启用>（默认）状态。\n\n" +
                    "• 如果想了解细节，将鼠标悬停在任意按钮上，右侧面板会显示说明。"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "使用 [DEBUG: 重置全部] 按钮时请务必**小心**。如果误点，仍可通过 [解锁所选成就] 按钮恢复已完成的成就。"
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: 重置全部" }, // Button label
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**警告**：清除/重置所有成就，适用于测试或调试。\n" +
                    "如果不小心点击了，可以通过 [解锁所选成就] 按钮恢复成就。"
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "警告：所有成就将被重置为**未完成**状态。是否继续？"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
