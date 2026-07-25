// <copyright file="LocalePT_PT.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocalePT_PT.cs
namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Portuguese Portugal locale (pt-PT)
    /// </summary>
    public class LocalePT_PT : IDictionarySource
    {
        private readonly AFSettings m_Setting;

        public LocalePT_PT(AFSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(AFSettings.AdvancedTab), "Avançado"  },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.NotesGroup),    "Notas"  },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.MainInfoGroup), "Info"   },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.ButtonGroup),   "Links de apoio" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowActions), "Ações" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.MainNotes)),
                    "<• As conquistas já estão ativadas;> faz apenas as tarefas necessárias para as completar normalmente.\n\n" +
                    "Diverte-te! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.NameDisplay)),     "Nome apresentado deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.VersionDisplay)),  "Número da versão atual." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenParadoxButton)), "Abre a página **Paradox** dos mods deste autor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenDiscordButton)), "Abre o **Discord** de modding do CS2 no navegador." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "Wiki de conquistas" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "Abre a **Wiki** das conquistas no navegador." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.SelectedAchievement)),   "Escolher conquista" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.SelectedAchievement)),    "Escolhe uma conquista para usar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.UnlockSelectedAchievement)), "DESBLOQUEAR ESCOLHIDA" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.UnlockSelectedAchievement)),  "**Desbloqueia e completa** a conquista escolhida." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ClearSelectedAchievement)),  "LIMPAR ESCOLHIDA" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ClearSelectedAchievement)),   "Marca a conquista escolhida como **não concluída**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ClearSelectedAchievement)), "LIMPAR / REPOR esta conquista.\n\nContinuar?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "• Nota: as conquistas já estão <ativadas> por defeito, sem usar estes botões avançados.\n\n" +
                    "• Se quiseres, passa o rato sobre qualquer botão para ver detalhes no painel da direita."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "**CUIDADO** ao usar o botão [DEBUG: RESET ALL]. Se o usares por engano, podes recuperar conquistas concluídas com o botão [Unlock Selected]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAchievements)), "DEBUG - REPOR TUDO" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "**AVISO**: limpa/repõe TODAS as conquistas. Útil para debug ou testes.\n" +
                    "Se usares isto por engano, podes recuperar as conquistas com o botão [Unlock Selected].\n" +
                    "<[Repor tudo]> para recomeçar e voltar a desbloquear as conquistas por diversão."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAdvisory)),
                    "[Repor tudo] para recomeçar e voltar a desbloquear as conquistas por diversão."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "AVISO: REPOR/LIMPAR todas as conquistas para estado NÃO concluído. Continuar?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}

