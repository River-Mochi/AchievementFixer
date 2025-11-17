// LocalePL.cs
namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Polish locale (pl-PL)
    /// </summary>
    public class LocalePL : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocalePL(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Główne"     },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Zaawansowane" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Informacje"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Linki wsparcia" },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notatki"  },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Akcje" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"   },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod"     },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Nazwa wyświetlana tego moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Aktualna wersja moda." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki Osiągnięć" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Otwórz wiki osiągnięć w swojej przeglądarki." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)), "Otwórz Discord CS2 modding w swojej przeglądarki." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "• Osiągnięcia są teraz włączone - po prostu wykonaj wymagane zadania, aby naturalnie je ukończyć.\n\n" +
                    "Miłej zabawy! :)\n" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Wybierz osiągnięcie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Wybierz osiągnięcie, którym chcesz operować." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "ODBLOCKUJ WYBRANE" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Odblokowuje i kończy** wybrane osiągnięcie." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "WYCZYŚĆ WYBRANE" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Oznacza wybrane osiągnięcie jako **nieukończone**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "WYCZYŚĆ / RESETUJ to osiągnięcie.\n\nKontynuować?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• Ten mod już włącza osiągnięcia (domyślnie) bez użycia jakichkolwiek przycisków w zakładce Zaawansowane.\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**UWAŻAJ** używając przycisku [DEBUG: RESETUJ WSZYSTKO]. Jeśli przypadkowo go użyjesz, możesz odzyskać ukończone osiągnięcia za pomocą przycisku [Odblokuj wybrane]." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: RESETUJ WSZYSTKO" }, //Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**OSTRZEŻENIE**: czyści/resetuje WSZYSTKIE osiągnięcia. Użyteczne do debugowania lub dla testerów.\n" +
                    "Jeśli przypadkowo to użyjesz, możesz odzyskać osiągnięcia używając przycisku [Odblokuj wybrane]." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "Ostrzeżenie: RESETUJ/WYCZYŚĆ wszystkie osiągnięcia do stanu NIEukończone. Kontynuować?" },
            };
        }

        public void Unload()
        {
        }
    }
}
