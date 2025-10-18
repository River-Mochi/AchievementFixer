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
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "主"   },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "高级" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "信息" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "支持链接" },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "说明" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "调试" },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "此模组的显示名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "当前模组版本。" },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "成就Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "在浏览器中打开成就Wiki。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)),          "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),           "在浏览器中打开CS2模组Discord。" },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "说明：\n" +
                    "• 成就已启用——按要求完成即可自然解锁。\n\n" +
                    "玩得开心！ :)\n\n" +
                    "• 部分成就需等到DLC发布后才可用（如 Bridges & Ports）。" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "选择成就" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "选择要操作的成就。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "解锁所选" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "将所选成就标记为**已解锁并完成**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "重置所选" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "将所选成就标记为**未完成**。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)),"将重置此成就。\n\n继续？" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• 此模组默认已启用成就——无需使用“高级”选项卡中的按钮。\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**注意**：使用 [DEBUG：全部重置] 时请谨慎。若误操作，可用 [解锁所选] 恢复。" },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG：全部重置" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**警告**：清除/重置**所有**成就。用于测试。\n" +
                    "如误操作，可用 [解锁所选] 恢复。" },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "警告：将**所有**成就重置为**未完成**。是否继续？" },
            };
        }

        public void Unload()
        {
        }
    }
}
