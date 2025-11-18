// LocaleKO.cs
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
                { m_Setting.GetSettingsLocaleID(), Mod.ModName },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "기본" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "고급" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "노트" },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "정보" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "지원 링크" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "작업" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• 업적은 이미 활성화되어 있습니다;> 필요한 조건을 채우면서 자연스럽게 달성하면 됩니다.\n\n" +
                    "즐거운 시간 되세요! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "이 모드의 표시 이름입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "현재 모드 버전입니다." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)),  "브라우저에서 이 제작자의 Paradox 모드 페이지를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),  "브라우저에서 CS2 모딩 Discord를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "업적 위키" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "브라우저에서 업적 위키를 엽니다." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "업적 선택" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "작업할 업적을 선택하세요." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "선택한 업적 해제" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "선택한 업적을**해제하고 완료된 상태**로 표시합니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "선택한 업적 초기화" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "선택한 업적을 **미완료** 상태로 표시합니다." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "이 업적을 초기화합니다.\n\n계속하시겠습니까?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• 참고: 이 고급 탭의 버튼을 사용하지 않아도 업적은 기본적으로 <이미 활성화됨> 상태입니다.\n\n" +
                    "• 궁금하다면 아무 버튼 위에 마우스를 올려 오른쪽 패널의 설명을 확인하세요."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "[DEBUG: 전체 초기화] 버튼을 사용할 때는 **주의**하세요. 실수로 눌렀더라도 [선택한 업적 해제] 버튼으로 완료된 업적을 다시 되돌릴 수 있습니다."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: 전체 초기화" }, // Button label
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**경고**: 모든 업적을 초기화/삭제합니다. 테스트나 디버그용으로 유용합니다.\n" +
                    "실수로 사용해도 [선택한 업적 해제] 버튼으로 업적을 복구할 수 있습니다."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "경고: 모든 업적을 **미완료** 상태로 초기화합니다. 계속하시겠습니까?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
