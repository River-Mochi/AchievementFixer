using System.Collections.Generic;
using Colossal;
using Colossal.IO.AssetDatabase.Internal;

namespace AchievementFixer
{
    /// <summary>
    /// Portuguese (Brazil) locale (pt-BR)
    /// </summary>
    public class LocalePT_BR : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocalePT_BR(Settings setting) { m_Setting = setting; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Principal" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Avançado"  },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Informações" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Links"       },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notas"       },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Ações"  },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"  },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Nome de exibição deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Versão atual do mod." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki de conquistas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "Abrir o wiki de conquistas no navegador." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)),          "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),           "Abrir o Discord de modding de CS2 no navegador." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "Notas:\n" +
                    "• As conquistas já estão ativas — basta cumprir os requisitos para desbloquear naturalmente.\n\n" +
                    "Divirta-se! :)\n\n" +
                    "• Algumas conquistas só ficam disponíveis quando os DLCs forem lançados (ex.: Bridges & Ports).\n" +
                    "• Às vezes, mesmo após cumprir os requisitos, a conquista só aparece depois de reiniciar o jogo." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Selecionar conquista" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Escolha a conquista para operar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "DESBLOQUEAR SELECIONADA" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "Marca a conquista selecionada como **desbloqueada e concluída**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "REDEFINIR SELECIONADA" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Marca a conquista selecionada como **não concluída**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)),"REDEFINIR esta conquista.\n\nContinuar?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• Este mod já ativa as conquistas por padrão — sem usar os botões da guia Avançado.\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**CUIDADO** com [DEBUG: REDEFINIR TUDO]. Se usar por engano, você pode recuperar com [DESBLOQUEAR SELECIONADA]." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: REDEFINIR TUDO" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**AVISO**: redefine **TODAS** as conquistas. Útil para testes.\n" +
                    "Se fizer por engano, recupere com [DESBLOQUEAR SELECIONADA]." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "Aviso: REDEFINIR todas as conquistas para **não concluídas**. Continuar?" },
            };
        }

        public void Unload() { }
    }
}
