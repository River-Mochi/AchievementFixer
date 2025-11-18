// LocaleDE.cs
namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// German locale (de-DE)
    /// </summary>
    public class LocaleDE : IDictionarySource
    {
        private readonly Settings m_Setting;

        public LocaleDE(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Haupt"    },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Erweitert" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Hinweise"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Info"       },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Support-Links" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Aktionen" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"    },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• Erfolge sind jetzt aktiviert;> erledigen Sie einfach die erforderlichen Aufgaben, um sie auf natürliche Weise freizuschalten.\n\n" +
                    "Viel Spaß! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Anzeigename dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Aktuelle Versionsnummer." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)),  "Öffnet die **Paradox**-Seite mit den Mods dieses Autors." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),  "Öffnet den CS2-Modding-**Discord** im Browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Erfolge-Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "Öffnet das **Erfolge-Wiki** im Browser." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Erfolg auswählen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Wählen Sie einen Erfolg, auf den Sie wirken möchten." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "AUSGEWÄHLTEN FREISCHALTEN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Schaltet den ausgewählten Erfolg frei und markiert ihn als abgeschlossen.**" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "AUSGEWÄHLTEN ZURÜCKSETZEN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Markiert den ausgewählten Erfolg als **nicht abgeschlossen**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "Diesen Erfolg zurücksetzen.\n\nFortfahren?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• Hinweis: Erfolge sind <bereits aktiviert> (Standard), ohne diese Erweitert-Schaltflächen zu verwenden.\n\n" +
                    "• Wenn Sie möchten, fahren Sie mit der Maus über eine Schaltfläche, um Details im rechten Seitenbereich zu sehen."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**VORSICHT** bei der Verwendung der Schaltfläche [DEBUG: ALLES ZURÜCKSETZEN]. Wenn Sie sie versehentlich verwenden, können Sie abgeschlossene Erfolge mit der Schaltfläche [Ausgewählten freischalten] wiederherstellen."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: ALLES ZURÜCKSETZEN" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**WARNUNG**: Setzt **alle** Erfolge zurück. Nützlich für Tests.\n" +
                    "Wenn Sie dies versehentlich tun, können Sie sie mit der Schaltfläche [Ausgewählten freischalten] wiederherstellen."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "Warnung: ALLE Erfolge auf den Status NICHT abgeschlossen zurücksetzen. Fortfahren?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
