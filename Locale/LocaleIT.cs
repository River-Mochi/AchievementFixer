// <copyright file="LocaleIT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleIT.cs
namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Italian locale (it-IT)
    /// </summary>
    public class LocaleIT : IDictionarySource
    {
        private readonly AFSettings m_Setting;

        public LocaleIT(AFSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(AFSettings.MainTab),     "Principale" },
                { m_Setting.GetOptionTabLocaleID(AFSettings.AdvancedTab), "Avanzato"   },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.NotesGroup),    "Note"           },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.MainInfoGroup), "Informazioni"   },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.ButtonGroup),   "Link di supporto" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowActions), "Azioni" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowDebug),   "DEBUG"  },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.MainNotes)),
                    "<• Gli obiettivi sono ora abilitati;> è sufficiente completare le attività richieste per ottenerli in modo naturale.\n\n" +
                    "Buon divertimento! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.NameDisplay)),     "Nome visualizzato di questa mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.VersionDisplay)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.VersionDisplay)),  "Numero di versione corrente." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenParadoxButton)),  "Apri la pagina **Paradox** con le mod di questo autore." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenDiscordButton)),  "Apri il **Discord** di modding di CS2 nel browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "Wiki degli obiettivi" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)),  "Apri la **wiki** degli obiettivi nel browser." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.SelectedAchievement)),   "Seleziona obiettivo" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.SelectedAchievement)),    "Scegli un obiettivo su cui operare." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.UnlockSelectedAchievement)), "SBLOCCA SELEZIONATO" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.UnlockSelectedAchievement)),  "**Sblocca e completa** l’obiettivo selezionato." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ClearSelectedAchievement)),  "AZZERA SELEZIONATO" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ClearSelectedAchievement)),   "Segna l’obiettivo selezionato come **non completato**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ClearSelectedAchievement)), "AZZERA / REIMPOSTA questo obiettivo.\n\nContinuare?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "• Nota: gli obiettivi sono <già abilitati> (predefinito) senza usare questi pulsanti Avanzati.\n\n" +
                    "• Se ti interessa, passa il mouse su un pulsante per vedere i dettagli nel pannello a destra."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "**FAI ATTENZIONE** quando usi il pulsante [DEBUG: AZZERA TUTTO]. Se lo usi per errore, puoi ripristinare gli obiettivi completati con il pulsante [Sblocca selezionato]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAchievements)), "DEBUG - AZZERA TUTTO" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "**ATTENZIONE**: azzera **tutti** gli obiettivi. Utile per i test.\n" +
                    "Se lo usi per errore, puoi ripristinarli con il pulsante [Sblocca selezionato].\n" +
                    "<[Azzera tutto]> per ricominciare e sbloccarli di nuovo per divertimento."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAdvisory)),
                    "[Azzera tutto] gli obiettivi per ricominciare e sbloccarli di nuovo per divertimento."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "Avviso: AZZERARE / CANCELLARE tutti gli obiettivi allo stato NON completato. Continuare?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}

