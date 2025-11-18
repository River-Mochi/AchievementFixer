// LocaleJA.cs
namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Japanese locale (ja-JP)
    /// </summary>
    public class LocaleJA : IDictionarySource
    {
        private readonly Settings m_Setting;

        public LocaleJA(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "メイン" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "詳細" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "メモ" },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "情報" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "サポートリンク" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "操作" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• 実績はすでに有効になっています;> 必要な条件を満たしていけば自然に解除されます。\n\n" +
                    "楽しんでください！ :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "この Mod の表示名です。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "現在のバージョン番号です。" },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)), "この作者の Mod 用 Paradox ページをブラウザで開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)), "CS2 モッディング用 Discord をブラウザで開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "実績 Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "実績に関する Wiki をブラウザで開きます。" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "実績を選択" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "操作する実績を選んでください。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "選択した実績を解除" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "選択した実績を**解除して達成済み**にします。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "選択した実績をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "選択した実績を**未達成**としてマークします。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "この実績をリセットします。\n\n続行しますか？" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• 注意: これらの詳細ボタンを使わなくても、実績はデフォルトで<すでに有効>です。\n\n" +
                    "• 興味があれば、ボタンにカーソルを合わせると右側のパネルに詳細が表示されます。"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "[DEBUG: すべてリセット] ボタンを使うときは **注意** してください。誤って押してしまっても、[選択した実績を解除] ボタンで達成済みの実績を戻すことができます。"
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: すべてリセット" }, // Button label
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**警告**: すべての実績をクリア／リセットします。テストやデバッグ用途向けです。\n" +
                    "誤って実行した場合は、[選択した実績を解除] ボタンで実績を戻すことができます。"
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "警告: すべての実績を **未達成** 状態にリセットします。続行しますか？"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
