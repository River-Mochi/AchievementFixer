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
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Główne" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Zaawansowane" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notatki" },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Informacje" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Linki wsparcia" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Akcje" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• Osiągnięcia są już włączone;> po prostu graj i spełniaj wymagania, a odblokują się naturalnie.\n\n" +
                    "Miłej zabawy! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Wyświetlana nazwa tego modu." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Aktualny numer wersji modu." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)),  "Otwiera w przeglądarce stronę Paradox z modami autora." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),  "Otwiera w przeglądarce Discord poświęcony modowaniu CS2." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki osiągnięć" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "Otwiera w przeglądarce wiki z osiągnięciami." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Wybierz osiągnięcie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Wybierz osiągnięcie, na którym chcesz wykonać operację." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "ODBLOKUJ WYBRANE" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Odblokowuje i zalicza** wybrane osiągnięcie." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "WYCZYŚĆ WYBRANE" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Oznacza wybrane osiągnięcie jako **niezrealizowane**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "Wyczyścić / zresetować to osiągnięcie?\n\nKontynuować?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• Uwaga: osiągnięcia są <już włączone> domyślnie, bez używania tych przycisków w zakładce Zaawansowane.\n\n" +
                    "• Jeśli chcesz, najedź kursorem na dowolny przycisk, aby zobaczyć szczegóły w panelu po prawej."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "Zachowaj **ostrożność** przy używaniu przycisku [DEBUG: ZRESETUJ WSZYSTKO]. " +
                    "Jeśli klikniesz go przez pomyłkę, możesz przywrócić ukończone osiągnięcia przyciskiem [ODBLOKUJ WYBRANE]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: ZRESETUJ WSZYSTKO" }, // Button label
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**OSTRZEŻENIE**: czyści / resetuje WSZYSTKIE osiągnięcia. Przydatne do testów i debugowania.\n" +
                    "Jeśli zrobisz to przypadkowo, możesz przywrócić osiągnięcia przyciskiem [ODBLOKUJ WYBRANE]."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "Ostrzeżenie: wszystkie osiągnięcia zostaną zresetowane do stanu **niezrealizowane**. Kontynuować?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
