using System.Collections.Generic;
using Colossal;

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
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Links"        },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notas"        },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Ações"  },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"  },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod"      },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Nome exibido deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Versão"   },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Versão atual do mod." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki de conquistas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),
                  "Abre o wiki de conquistas no seu navegador." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "Notas:\n" +
                    "• As conquistas estão ativadas — basta cumprir as tarefas necessárias para obtê-las naturalmente.\n" +
                    "• Divirta-se! :)\n\n" +
                    "• A Steam lista 6 conquistas que só ficarão disponíveis quando o DLC “Bridges & Ports” for lançado." },

                { m_Setting.GetOptionDescLocaleID(nameof(Settings.MainNotes)),
                    "Observação: às vezes, depois de concluir os requisitos, a conquista só aparece após reiniciar o jogo." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Selecionar conquista" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Escolha uma conquista para operar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "Desbloquear selecionado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Desbloqueia e conclui** a conquista selecionada." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "Limpar selecionado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Marca a conquista selecionada como **não concluída**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "LIMPAR / REDEFINIR esta conquista.\n\nContinuar?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• Este mod já ativa as conquistas (padrão) sem usar botões na guia Avançado.\n" +
                  "• Se quiser mais rápido, experimente o botão [Desbloquear selecionado]." },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**CUIDADO** ao usar o botão [Depuração:  REDEFINIR TUDO]. Se você usá-lo por engano, pode recuperar conquistas com [Desbloquear selecionado]." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "Depuração:  REDEFINIR TUDO" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**AVISO**: redefine TODAS as conquistas. Útil para depuração/testes.\n" +
                    "Se usar por engano, você pode restaurá-las com [Desbloquear selecionado]." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "Aviso: REDEFINIR/LIMPAR todas as conquistas para o estado **não concluído**. Continuar?" },
            };
        }

        public void Unload() { }
    }
}
