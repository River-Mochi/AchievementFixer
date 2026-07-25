// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

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
        private readonly AFSettings m_Setting;

        public LocalePL(AFSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(AFSettings.MainTab),     "Główne" },
                { m_Setting.GetOptionTabLocaleID(AFSettings.AdvancedTab), "Zaawansowane" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.NotesGroup),    "Notatki" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.MainInfoGroup), "Informacje" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.ButtonGroup),   "Linki wsparcia" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowActions), "Akcje" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.MainNotes)),
                    "<• Osiągnięcia są już włączone;> po prostu graj i spełniaj wymagania, a odblokują się naturalnie.\n\n" +
                    "Miłej zabawy! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.NameDisplay)),     "Wyświetlana nazwa tego modu." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.VersionDisplay)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.VersionDisplay)),  "Aktualny numer wersji modu." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenParadoxButton)),  "Otwiera w przeglądarce stronę Paradox z modami autora." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenDiscordButton)),  "Otwiera w przeglądarce Discord poświęcony modowaniu CS2." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "Wiki osiągnięć" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)),  "Otwiera w przeglądarce wiki z osiągnięciami." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.SelectedAchievement)),   "Wybierz osiągnięcie" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.SelectedAchievement)),    "Wybierz osiągnięcie, na którym chcesz wykonać operację." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.UnlockSelectedAchievement)), "ODBLOKUJ WYBRANE" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.UnlockSelectedAchievement)),  "**Odblokowuje i zalicza** wybrane osiągnięcie." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ClearSelectedAchievement)),  "WYCZYŚĆ WYBRANE" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ClearSelectedAchievement)),   "Oznacza wybrane osiągnięcie jako **niezrealizowane**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ClearSelectedAchievement)), "Wyczyścić / zresetować to osiągnięcie?\n\nKontynuować?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "• Uwaga: osiągnięcia są <już włączone> domyślnie, bez używania tych przycisków w zakładce Zaawansowane.\n\n" +
                    "• Jeśli chcesz, najedź kursorem na dowolny przycisk, aby zobaczyć szczegóły w panelu po prawej."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "Zachowaj **ostrożność** przy używaniu przycisku [DEBUG: ZRESETUJ WSZYSTKO]. " +
                    "Jeśli klikniesz go przez pomyłkę, możesz przywrócić ukończone osiągnięcia przyciskiem [ODBLOKUJ WYBRANE]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAchievements)), "DEBUG - ZRESETUJ WSZYSTKO" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "**OSTRZEŻENIE**: czyści / resetuje WSZYSTKIE osiągnięcia. Przydatne do testów i debugowania.\n" +
                    "Jeśli zrobisz to przypadkowo, możesz przywrócić osiągnięcia przyciskiem [ODBLOKUJ WYBRANE].\n" +
                    "[Zresetuj wszystko], aby zacząć od nowa i ponownie zdobywać osiągnięcia dla zabawy."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "Ostrzeżenie: wszystkie osiągnięcia zostaną zresetowane do stanu **niezrealizowane**. Kontynuować?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}

