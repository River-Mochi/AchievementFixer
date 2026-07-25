// <copyright file="LocalePT_BR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

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
        private readonly AFSettings m_Setting;

        public LocalePT_BR(AFSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(AFSettings.MainTab),     "Principal" },
                { m_Setting.GetOptionTabLocaleID(AFSettings.AdvancedTab), "Avançado" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.NotesGroup),    "Notas" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.MainInfoGroup), "Informações" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.ButtonGroup),   "Links de suporte" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowActions), "Ações" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.MainNotes)),
                    "<• As conquistas já estão ativadas;> é só cumprir os requisitos normalmente para concluí-las.\n\n" +
                    "Divirta-se! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.NameDisplay)),     "Nome exibido deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.VersionDisplay)),  "Número de versão atual do mod." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenParadoxButton)),  "Abre no navegador a página da Paradox com os mods deste autor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenDiscordButton)),  "Abre no navegador o Discord de modding de CS2." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "Wiki de conquistas" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)),  "Abre no navegador a wiki de conquistas." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.SelectedAchievement)),   "Selecionar conquista" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.SelectedAchievement)),    "Escolha a conquista que deseja modificar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.UnlockSelectedAchievement)), "DESBLOQUEAR SELECIONADA" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.UnlockSelectedAchievement)),  "**Desbloqueia e conclui** imediatamente a conquista selecionada." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ClearSelectedAchievement)),  "LIMPAR SELECIONADA" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ClearSelectedAchievement)),   "Marca a conquista selecionada como **não concluída**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ClearSelectedAchievement)), "Limpar / redefinir esta conquista.\n\nContinuar?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "• Observação: as conquistas já estão <ativadas> por padrão, sem precisar usar esses botões da aba Avançado.\n\n" +
                    "• Se quiser detalhes, passe o mouse sobre qualquer botão para ver a descrição no painel à direita."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "Tenha **cuidado** ao usar o botão [DEBUG: REDEFINIR TUDO]. " +
                    "Se clicar por engano, você pode recuperar conquistas concluídas usando o botão [DESBLOQUEAR SELECIONADA]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAchievements)), "DEBUG - REDEFINIR TUDO" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "**AVISO**: limpa / redefine TODAS as conquistas. Útil para testes e depuração.\n" +
                    "Se fizer isso por engano, você pode restaurar conquistas usando [DESBLOQUEAR SELECIONADA].\n" +
                    "[Redefinir tudo] para recomeçar e desbloquear tudo de novo por diversão."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "Aviso: todas as conquistas serão redefinidas para o estado **não concluída**. Continuar?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}

