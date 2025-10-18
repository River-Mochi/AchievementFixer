namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;
    /// <summary>
    /// Korean locale (ko-KR)
    /// </summary>
    public class LocaleKO : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleKO(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "기본" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "고급" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "정보" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),  "지원 링크" },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "노트" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "작업"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "이 모드의 표시 이름." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "현재 모드 버전." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "업적 위키" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "브라우저에서 업적 위키 열기." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)),          "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),           "브라우저에서 CS2 모딩 Discord 열기." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "노트:\n" +
                    "• 업적은 이미 활성화됨 — 필요한 작업을 하면 자연스럽게 달성됩니다.\n\n" +
                    "즐거운 시간 되세요! :)\n\n" +
                    "• 일부 업적은 DLC 출시 후에만 이용 가능합니다(예: Bridges & Ports)." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "업적 선택" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "작업할 업적을 선택하세요." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "선택 업적 해제" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "선택한 업적을 **해제 및 완료**로 표시합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "선택 업적 초기화" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "선택한 업적을 **미완료**로 표시합니다." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)),"이 업적을 초기화합니다.\n\n계속할까요?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• 이 모드는 기본으로 업적을 활성화합니다 — 고급 탭의 버튼은 필요 없습니다.\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**주의**: [DEBUG: 전체 초기화] 사용 시 주의. 실수했다면 [선택 업적 해제]로 복구할 수 있습니다." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: 전체 초기화" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**경고**: **모든** 업적을 초기화합니다. 테스트용.\n" +
                    "실수했다면 [선택 업적 해제]로 복구하세요." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "경고: 모든 업적을 **미완료** 상태로 초기화합니다. 계속할까요?" },
            };
        }

        public void Unload()
        {
        }
    }
}
