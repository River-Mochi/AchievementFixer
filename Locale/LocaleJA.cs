using System.Collections.Generic;
using Colossal;

namespace AchievementFixer
{
    /// <summary>
    /// Japanese locale (ja-JP)
    /// </summary>
    public class LocaleJA : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleJA(Settings setting) { m_Setting = setting; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "メイン" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "詳細"   },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "情報"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "リンク" },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "注意事項" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "操作"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "この Mod の表示名です。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "現在の Mod バージョン。" },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "実績 Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),
                  "ブラウザーで実績 Wiki を開きます。" },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "メモ:\n" +
                    "• 実績は現在有効です。必要なタスクを自然に達成してください。\n" +
                    "• 楽しんでください！ :)\n\n" +
                    "• Steam には、DLC「Bridges & Ports」発売まで利用できない実績が 6 個表示されます。" },

                { m_Setting.GetOptionDescLocaleID(nameof(Settings.MainNotes)),
                    "注意: すべての条件を満たしても、ゲームを再起動するまで実績が表示されない場合があります。" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "実績を選択" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "操作する実績を選択してください。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "選択した実績を解除" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "選択した実績を**解除して達成済みにします**。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "選択した実績をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "選択した実績を**未達成**としてマークします。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "この実績をクリア／リセットします。\n\n続行しますか？" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• この Mod は（既定で）実績を有効化します。［詳細］タブのボタンを使用する必要はありません。\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "［デバッグ： すべてリセット］の使用には**注意**してください。誤って実行した場合は、［選択した実績を解除］で回復できます。" },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "デバッグ： すべてリセット" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**警告**：すべての実績をリセットします。デバッグ／テスト用途向け。\n" +
                    "誤って実行した場合は、［選択した実績を解除］で実績を取り戻せます。" },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "警告：すべての実績を**未達成**状態にリセットします。続行しますか？" },
            };
        }

        public void Unload() { }
    }
}
