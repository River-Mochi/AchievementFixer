using System.Collections.Generic;
using Colossal;

namespace AchievementFixer
{
    /// <summary>
    /// Simplified Chinese locale (zh-HANS)
    /// </summary>
    public class LocaleZH_CN : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleZH_CN(Settings setting) { m_Setting = setting; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "主要" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "高级" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "信息"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "链接"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "备注"   },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "操作"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "此模组的显示名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "当前模组版本。" },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "成就百科" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),
                  "在浏览器中打开成就百科。" },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "说明：\n" +
                    "• 现在已启用成就——只需按正常方式完成所需任务即可获得。\n" +
                    "• 祝玩得开心！:)\n\n" +
                    "• Steam 会列出 6 个成就，需等到 “Bridges & Ports” DLC 发售后才可用。" },

                { m_Setting.GetOptionDescLocaleID(nameof(Settings.MainNotes)),
                    "注意：有时在满足条件后，成就可能需要重启游戏才会显示。" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "选择成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "选择要操作的成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "解锁所选" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**解锁并完成**所选成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "清除所选" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "将所选成就标记为**未完成**。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "清除/重置此成就。\n\n是否继续？" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• 本模组已（默认）启用成就，无需使用“高级”选项卡中的按钮。\n" +
                  "• 如果想更快生效，可尝试使用【解锁所选】。" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "使用【RESET ALL】请**谨慎**。若误操作，可通过【解锁所选】恢复已完成的成就。" },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "调试： 全部重置" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**警告**：将重置所有成就。适用于调试/测试。\n" +
                    "若误操作，可通过【解锁所选】恢复。" },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "警告：把所有成就重置为**未完成**状态。是否继续？" },
            };
        }

        public void Unload() { }
    }
}
