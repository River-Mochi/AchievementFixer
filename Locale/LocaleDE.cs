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
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Allgemein" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Erweitert" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Info"     },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Support-Links"    },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Hinweise" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Aktionen" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"    },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Anzeigename dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Aktuelle Mod-Version." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Erfolge-Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "Öffnet das Erfolge-Wiki im Browser." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)),          "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),           "Öffnet den CS2-Modding-Discord im Browser." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "Hinweise:\n" +
                    "• Erfolge sind jetzt aktiviert – erledige einfach die Aufgaben, um sie ganz normal freizuschalten.\n\n" +
                    "Viel Spaß! :)\n\n" +
                    "• Manche Erfolge sind erst verfügbar, wenn DLCs veröffentlicht wurden (z. B. Bridges & Ports).\n" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Erfolg auswählen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Wähle einen Erfolg für die Aktion." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "AUSGEWÄHLTEN FREISCHALTEN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "Markiert den ausgewählten Erfolg als **freigeschaltet & abgeschlossen**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "AUSGEWÄHLTEN ZURÜCKSETZEN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Setzt den ausgewählten Erfolg auf **nicht abgeschlossen**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)),"Diesen Erfolg ZURÜCKSETZEN.\n\nFortfahren?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• Diese Mod aktiviert Erfolge bereits standardmäßig – ohne die Schaltflächen im Tab „Erweitert“.\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**VORSICHT** bei [DEBUG: ALLE ZURÜCKSETZEN]. Wenn du ihn versehentlich drückst, kannst du Erfolge mit [AUSGEWÄHLTEN FREISCHALTEN] wiederherstellen." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: ALLE ZURÜCKSETZEN" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**WARNUNG**: setzt **ALLE** Erfolge zurück. Nützlich für Tests.\n" +
                    "Wenn du das aus Versehen machst, kannst du sie mit [AUSGEWÄHLTEN FREISCHALTEN] zurückholen." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "Achtung: ALLE Erfolge auf **nicht abgeschlossen** setzen. Fortfahren?" },
            };
        }

        public void Unload()
        {
        }
    }
}
