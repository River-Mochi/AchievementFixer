using System.Collections.Generic;
using Colossal;

namespace AchievementFixer
{
    /// <summary>
    /// Korean locale (ko-KR)
    /// </summary>
    public class LocaleKO : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleKO(Settings setting) { m_Setting = setting; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "메인" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "고급" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "정보" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "링크" },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "노트" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "작업"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "이 모드의 표시 이름입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "현재 모드 버전." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "업적 위키" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),
                  "브라우저에서 업적 위키를 엽니다." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "메모:\n" +
                    "• 업적이 활성화되었습니다. 필요한 작업을 자연스럽게 완료하면 됩니다.\n" +
                    "• 즐기세요! :)\n\n" +
                    "• Steam에는 ‘Bridges & Ports’ DLC 출시 전까지 사용할 수 없는 업적 6개가 표시됩니다." },

                { m_Setting.GetOptionDescLocaleID(nameof(Settings.MainNotes)),
                    "참고: 조건을 모두 충족해도 게임을 재시작해야 업적이 표시되는 경우가 있습니다." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "업적 선택" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "작업할 업적을 선택하세요." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "선택 항목 해제" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "선택한 업적을 **해제하고 완료 처리**합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "선택 항목 초기화" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "선택한 업적을 **미완료**로 표시합니다." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "이 업적을 지우고/초기화합니다.\n\n계속할까요?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• 이 모드는 이미 (기본값으로) 업적을 활성화합니다. 고급 탭의 버튼을 사용할 필요가 없습니다.\n" +
                  "• 더 빠르게 반영하려면 [선택 항목 해제] 버튼을 사용해 보세요." },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "[RESET ALL] 버튼 사용 시 **주의**하세요. 실수로 누른 경우 [선택 항목 해제]로 복구할 수 있습니다." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "디버그: 전체 초기화" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**경고**: 모든 업적을 초기화합니다. 디버그/테스트용으로만 사용하세요.\n" +
                    "실수로 초기화한 경우 [선택 항목 해제]로 복구할 수 있습니다." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "경고: 모든 업적을 **미완료** 상태로 초기화합니다. 계속할까요?" },
            };
        }

        public void Unload() { }
    }
}
