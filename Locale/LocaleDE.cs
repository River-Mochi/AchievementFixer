// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

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
        private readonly AFSettings m_Setting;

        public LocaleDE(AFSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(AFSettings.MainTab),     "Haupt"    },
                { m_Setting.GetOptionTabLocaleID(AFSettings.AdvancedTab), "Erweitert" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.NotesGroup),    "Hinweise"   },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.MainInfoGroup), "Info"       },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.ButtonGroup),   "Support-Links" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowActions), "Aktionen" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowDebug),   "DEBUG"    },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.MainNotes)),
                    "<• Erfolge sind jetzt aktiviert;> erledigen Sie einfach die erforderlichen Aufgaben, um sie auf natürliche Weise freizuschalten.\n\n" +
                    "Viel Spaß! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.NameDisplay)),     "Anzeigename dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.VersionDisplay)),  "Aktuelle Versionsnummer." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenParadoxButton)),  "Öffnet die **Paradox**-Seite mit den Mods dieses Autors." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenDiscordButton)),  "Öffnet den CS2-Modding-**Discord** im Browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "Erfolge-Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)),  "Öffnet das **Erfolge-Wiki** im Browser." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.SelectedAchievement)),   "Erfolg auswählen" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.SelectedAchievement)),    "Wählen Sie einen Erfolg, auf den Sie wirken möchten." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.UnlockSelectedAchievement)), "AUSGEWÄHLTEN FREISCHALTEN" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.UnlockSelectedAchievement)),  "**Schaltet den ausgewählten Erfolg frei und markiert ihn als abgeschlossen.**" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ClearSelectedAchievement)),  "AUSGEWÄHLTEN ZURÜCKSETZEN" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ClearSelectedAchievement)),   "Markiert den ausgewählten Erfolg als **nicht abgeschlossen**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ClearSelectedAchievement)), "Diesen Erfolg zurücksetzen.\n\nFortfahren?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "• Hinweis: Erfolge sind <bereits aktiviert> (Standard), ohne diese Erweitert-Schaltflächen zu verwenden.\n\n" +
                    "• Wenn Sie möchten, fahren Sie mit der Maus über eine Schaltfläche, um Details im rechten Seitenbereich zu sehen."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "**VORSICHT** bei der Verwendung der Schaltfläche [DEBUG: ALLES ZURÜCKSETZEN]. Wenn Sie sie versehentlich verwenden, können Sie abgeschlossene Erfolge mit der Schaltfläche [Ausgewählten freischalten] wiederherstellen."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAchievements)), "DEBUG - ALLES ZURÜCKSETZEN" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "**WARNUNG**: Setzt **alle** Erfolge zurück. Nützlich für Tests.\n" +
                    "Wenn Sie dies versehentlich tun, können Sie sie mit der Schaltfläche [Ausgewählten freischalten] wiederherstellen.\n" +
                    "<[Alles zurücksetzen]>, um neu anzufangen und die Erfolge zum Spaß erneut freizuschalten."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAdvisory)),
                    "[Alles zurücksetzen], um neu anzufangen und die Erfolge zum Spaß erneut freizuschalten."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "Warnung: ALLE Erfolge auf den Status NICHT abgeschlossen zurücksetzen. Fortfahren?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}

