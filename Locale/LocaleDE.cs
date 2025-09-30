using System.Collections.Generic;
using Colossal;

namespace AchievementFixer
{
    /// <summary>
    /// German locale (de-DE)
    /// </summary>
    public class LocaleDE : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleDE(Settings setting) { m_Setting = setting; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Allgemein" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Erweitert" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Info"     },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Links"    },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Hinweise" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Aktionen" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"    },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod"       },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Anzeigename dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Version"   },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Aktuelle Mod-Version." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Achievements-Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),
                  "Öffnet das Achievements-Wiki im Browser." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "Notizen:\n" +
                    "• Erfolge sind jetzt aktiviert – erledige einfach die erforderlichen Aufgaben, um sie natürlich freizuschalten.\n" +
                    "• Viel Spaß! :)\n\n" +
                    "• Steam listet 6 Erfolge auf, die erst mit dem DLC „Bridges & Ports“ verfügbar sind." },

                { m_Setting.GetOptionDescLocaleID(nameof(Settings.MainNotes)),
                    "Hinweis: Manchmal erscheint ein Erfolg erst nach einem Neustart des Spiels, obwohl die Voraussetzungen erfüllt sind." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Erfolg auswählen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Wähle einen Erfolg, auf den du eine Aktion anwenden möchtest." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "Ausgewählten freischalten" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Schaltet frei & schließt ab** den ausgewählten Erfolg." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "Ausgewählten zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Markiert den ausgewählten Erfolg als **nicht abgeschlossen**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "DIESEN Erfolg LÖSCHEN/ZURÜCKSETZEN.\n\nFortfahren?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• Dieses Mod aktiviert Erfolge bereits (Standard), ohne dass du die Schaltflächen im Reiter „Erweitert“ verwenden musst.\n" +
                  "• Wenn du es schneller willst, probiere die Schaltfläche [Ausgewählten freischalten]." },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**VORSICHT** bei der Schaltfläche [RESET ALL]. Falls du sie versehentlich verwendest, kannst du Erfolge mit [Ausgewählten freischalten] wiederherstellen." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG:  ALLES ZURÜCKSETZEN" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**WARNUNG**: setzt ALLE Erfolge zurück. Nützlich zum Testen/Debuggen.\n" +
                    "Falls du das versehentlich nutzt, kannst du Erfolge mit [Ausgewählten freischalten] wiederherstellen." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "Warnung: ALLE Erfolge auf **nicht abgeschlossen** zurücksetzen. Fortfahren?" },
            };
        }

        public void Unload() { }
    }
}
