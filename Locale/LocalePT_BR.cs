// LocalePT_BR.cs

namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Brazilian Portuguese locale (pt-BR)
    /// </summary>
    public class LocalePT_BR : IDictionarySource
    {
        private readonly Settings m_Setting;

        public LocalePT_BR(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Principal" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Avançado" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notas" },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Informações" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Links de suporte" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Ações" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• As conquistas já estão ativadas;> é só cumprir os requisitos normalmente para concluí-las.\n\n" +
                    "Divirta-se! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Nome exibido deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Número de versão atual do mod." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)),  "Abre no navegador a página da Paradox com os mods deste autor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),  "Abre no navegador o Discord de modding de CS2." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki de conquistas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "Abre no navegador a wiki de conquistas." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Selecionar conquista" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Escolha a conquista que deseja modificar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "DESBLOQUEAR SELECIONADA" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Desbloqueia e conclui** imediatamente a conquista selecionada." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "LIMPAR SELECIONADA" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Marca a conquista selecionada como **não concluída**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "Limpar / redefinir esta conquista.\n\nContinuar?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• Observação: as conquistas já estão <ativadas> por padrão, sem precisar usar esses botões da aba Avançado.\n\n" +
                    "• Se quiser detalhes, passe o mouse sobre qualquer botão para ver a descrição no painel à direita."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "Tenha **cuidado** ao usar o botão [DEBUG: REDEFINIR TUDO]. " +
                    "Se clicar por engano, você pode recuperar conquistas concluídas usando o botão [DESBLOQUEAR SELECIONADA]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: REDEFINIR TUDO" }, // Button label
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**AVISO**: limpa / redefine TODAS as conquistas. Útil para testes e depuração.\n" +
                    "Se fizer isso por engano, você pode restaurar conquistas usando [DESBLOQUEAR SELECIONADA]."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "Aviso: todas as conquistas serão redefinidas para o estado **não concluída**. Continuar?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
