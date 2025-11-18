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
        private readonly Settings m_Setting;

        public LocaleIT(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Principale" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Avanzato"   },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Note"           },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Informazioni"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Link di supporto" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Azioni" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"  },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• Gli obiettivi sono ora abilitati;> è sufficiente completare le attività richieste per ottenerli in modo naturale.\n\n" +
                    "Buon divertimento! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Nome visualizzato di questa mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Versione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Numero di versione corrente." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)),  "Apri la pagina **Paradox** con le mod di questo autore." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),  "Apri il **Discord** di modding di CS2 nel browser." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki degli obiettivi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "Apri la **wiki** degli obiettivi nel browser." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Seleziona obiettivo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Scegli un obiettivo su cui operare." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "SBLOCCA SELEZIONATO" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Sblocca e completa** l’obiettivo selezionato." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "AZZERA SELEZIONATO" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Segna l’obiettivo selezionato come **non completato**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "AZZERA / REIMPOSTA questo obiettivo.\n\nContinuare?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• Nota: gli obiettivi sono <già abilitati> (predefinito) senza usare questi pulsanti Avanzati.\n\n" +
                    "• Se ti interessa, passa il mouse su un pulsante per vedere i dettagli nel pannello a destra."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**FAI ATTENZIONE** quando usi il pulsante [DEBUG: AZZERA TUTTO]. Se lo usi per errore, puoi ripristinare gli obiettivi completati con il pulsante [Sblocca selezionato]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: AZZERA TUTTO" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**ATTENZIONE**: azzera **tutti** gli obiettivi. Utile per i test.\n" +
                    "Se lo usi per errore, puoi ripristinarli con il pulsante [Sblocca selezionato]."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "Avviso: AZZERARE / CANCELLARE tutti gli obiettivi allo stato NON completato. Continuare?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
