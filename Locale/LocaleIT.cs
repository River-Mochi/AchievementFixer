using System.Collections.Generic;
using Colossal;

namespace AchievementFixer
{
    /// <summary>
    /// Italian locale (it-IT)
    /// </summary>
    public class LocaleIT : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleIT(Settings setting) { m_Setting = setting; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Principale" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Avanzate"   },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Informazioni" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Collegamenti" },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Note"         },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Azioni" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Nome visualizzato di questa mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Versione attuale della mod." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki degli obiettivi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),
                  "Apre nel browser la wiki degli obiettivi." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "Note:\n" +
                    "• Gli obiettivi sono ora abilitati: completa naturalmente le attività richieste.\n" +
                    "• Buon divertimento! :)\n\n" +
                    "• Su Steam sono elencati 6 obiettivi non disponibili fino all’uscita del DLC \"Bridges & Ports\"." },

                { m_Setting.GetOptionDescLocaleID(nameof(Settings.MainNotes)),
                    "Nota: a volte, dopo aver soddisfatto i requisiti, l’obiettivo potrebbe non comparire finché non riavvii il gioco." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Seleziona obiettivo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Scegli un obiettivo su cui operare." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "Sblocca selezionato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Sblocca e completa** l’obiettivo selezionato." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "Azzera selezionato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Imposta l’obiettivo selezionato su **non completato**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "AZZERA / RESETTA questo obiettivo.\n\nContinuare?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• Questa mod abilita già gli obiettivi (predefinito) senza usare i pulsanti nella scheda Avanzate.\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**FAI ATTENZIONE** con il pulsante [DEBUG:  RESET TUTTO]. Se lo premi per errore, puoi ripristinare gli obiettivi con [Sblocca selezionato]." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG:  RESET TUTTO" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**ATTENZIONE**: azzera TUTTI gli obiettivi. Utile per test/debug.\n" +
                    "Se lo esegui per errore, puoi recuperarli con [Sblocca selezionato]." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "Avviso: RESETTA/AZZERA tutti gli obiettivi allo stato **non completato**. Continuare?" },
            };
        }

        public void Unload() { }
    }
}
