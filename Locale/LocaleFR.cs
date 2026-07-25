// <copyright file="LocaleFR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleFR.cs
namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// French locale (fr-FR)
    /// </summary>
    public class LocaleFR : IDictionarySource
    {
        private readonly AFSettings m_Setting;

        public LocaleFR(AFSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(AFSettings.AdvancedTab), "Avancé"    },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.NotesGroup),    "Notes"          },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.MainInfoGroup), "Informations"   },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.ButtonGroup),   "Liens de support" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowActions), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowDebug),   "DEBUG"  },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.MainNotes)),
                    "<• Les succès sont maintenant activés ;> accomplissez simplement les tâches requises pour les obtenir naturellement.\n\n" +
                    "Amusez-vous bien ! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.NameDisplay)),     "Nom d’affichage de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.VersionDisplay)),  "Numéro de version actuel." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenParadoxButton)),  "Ouvrir la page **Paradox** des mods de cet auteur." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenDiscordButton)),  "Ouvrir le **Discord** de modding CS2 dans votre navigateur." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "Wiki des succès" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)),  "Ouvrir le **wiki** des succès dans votre navigateur." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.SelectedAchievement)),   "Sélectionner un succès" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.SelectedAchievement)),    "Choisissez un succès sur lequel agir." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.UnlockSelectedAchievement)), "DÉVERROUILLER LA SÉLECTION" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.UnlockSelectedAchievement)),  "**Déverrouille et complète** le succès sélectionné." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ClearSelectedAchievement)),  "EFFACER LA SÉLECTION" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ClearSelectedAchievement)),   "Marque le succès sélectionné comme **non complété**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ClearSelectedAchievement)), "EFFACER / RÉINITIALISER ce succès.\n\nContinuer ?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "• Remarque : les succès sont <déjà activés> (par défaut) sans utiliser ces boutons Avancés.\n\n" +
                    "• Si cela vous intéresse, survolez un bouton pour voir les détails dans le panneau de droite."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "**FAITES ATTENTION** en utilisant le bouton [DEBUG: TOUT RÉINITIALISER]. Si vous l’utilisez par erreur, vous pouvez récupérer les succès complétés avec le bouton [Déverrouiller la sélection]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAchievements)), "DEBUG - TOUT RÉINITIALISER" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "**AVERTISSEMENT** : réinitialise **tous** les succès. Utile pour les tests.\n" +
                    "Si vous l’utilisez par erreur, vous pouvez les récupérer avec le bouton [Déverrouiller la sélection].\n" +
                    "<[Tout réinitialiser]> pour repartir de zéro et les débloquer à nouveau pour le plaisir."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "Avertissement : RÉINITIALISER / EFFACER tous les succès vers l’état NON complété. Continuer ?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}

