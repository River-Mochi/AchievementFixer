using System.Collections.Generic;
using Colossal;

namespace AchievementFixer
{
    /// <summary>
    /// French locale (fr-FR)
    /// </summary>
    public class LocaleFR : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleFR(Settings setting) { m_Setting = setting; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Général" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Avancé"  },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Infos"  },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Liens"  },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notes"  },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"   },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod"      },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Nom affiché de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Version"  },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Version actuelle du mod." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki des succès" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),
                  "Ouvre le wiki des succès dans votre navigateur." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "Notes :\n" +
                    "• Les succès sont activés : réalisez simplement les actions requises pour les obtenir naturellement.\n" +
                    "• Amusez-vous ! :)\n\n" +
                    "• Steam affiche 6 succès qui ne seront disponibles qu’à la sortie du DLC « Bridges & Ports »." },

                { m_Setting.GetOptionDescLocaleID(nameof(Settings.MainNotes)),
                    "Remarque : parfois, après avoir rempli les conditions, un succès peut n’apparaître qu’après un redémarrage du jeu." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Sélectionner un succès" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Choisissez un succès sur lequel agir." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "Débloquer la sélection" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Débloque et valide** le succès sélectionné." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "Réinitialiser la sélection" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Marque le succès sélectionné comme **non terminé**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "EFFACER / RÉINITIALISER ce succès.\n\nContinuer ?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• Ce mod active déjà les succès (par défaut) sans utiliser les boutons de l’onglet Avancé.\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**ATTENTION** lors de l’utilisation du bouton [Débogage : TOUT RÉINITIALISER]. En cas d’erreur, vous pouvez récupérer des succès via [Débloquer la sélection]." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "Débogage : TOUT RÉINITIALISER" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**AVERTISSEMENT** : réinitialise TOUS les succès. Utile pour le debug et les tests.\n" +
                    "En cas d’erreur, vous pouvez les récupérer via [Débloquer la sélection]." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "Avertissement : RÉINITIALISER/EFFACER tous les succès en état **non terminé**. Continuer ?" },
            };
        }

        public void Unload() { }
    }
}
