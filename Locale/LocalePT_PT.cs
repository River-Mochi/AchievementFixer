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
        private readonly Settings m_Setting;

        public LocalePT_PT(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Avançado"  },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notas"  },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Info"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Links de apoio" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Ações" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• As conquistas já estão ativadas;> faz apenas as tarefas necessárias para as completar normalmente.\n\n" +
                    "Diverte-te! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Nome apresentado deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Número da versão atual." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)), "Abre a página **Paradox** dos mods deste autor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)), "Abre o **Discord** de modding do CS2 no navegador." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki de conquistas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Abre a **Wiki** das conquistas no navegador." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Escolher conquista" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Escolhe uma conquista para usar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "DESBLOQUEAR ESCOLHIDA" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Desbloqueia e completa** a conquista escolhida." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "LIMPAR ESCOLHIDA" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Marca a conquista escolhida como **não concluída**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "LIMPAR / REPOR esta conquista.\n\nContinuar?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• Nota: as conquistas já estão <ativadas> por defeito, sem usar estes botões avançados.\n\n" +
                    "• Se quiseres, passa o rato sobre qualquer botão para ver detalhes no painel da direita."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**CUIDADO** ao usar o botão [DEBUG: RESET ALL]. Se o usares por engano, podes recuperar conquistas concluídas com o botão [Unlock Selected]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: REPOR TUDO" }, // Button label
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**AVISO**: limpa/repõe TODAS as conquistas. Útil para debug ou testes.\n" +
                    "Se usares isto por engano, podes recuperar as conquistas com o botão [Unlock Selected]."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "Aviso Aviso: REPOR/LIMPAR todas as conquistas para estado NÃO concluído. Continuar?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
