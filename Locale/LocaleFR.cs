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
        private readonly Settings m_Setting;

        public LocaleFR(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Avancé"    },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notes"          },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Informations"   },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Liens de support" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Actions" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"  },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• Les succès sont maintenant activés ;> accomplissez simplement les tâches requises pour les obtenir naturellement.\n\n" +
                    "Amusez-vous bien ! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Nom d’affichage de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Numéro de version actuel." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)),  "Ouvrir la page **Paradox** des mods de cet auteur." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),  "Ouvrir le **Discord** de modding CS2 dans votre navigateur." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki des succès" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "Ouvrir le **wiki** des succès dans votre navigateur." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Sélectionner un succès" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Choisissez un succès sur lequel agir." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "DÉVERROUILLER LA SÉLECTION" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Déverrouille et complète** le succès sélectionné." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "EFFACER LA SÉLECTION" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Marque le succès sélectionné comme **non complété**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "EFFACER / RÉINITIALISER ce succès.\n\nContinuer ?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• Remarque : les succès sont <déjà activés> (par défaut) sans utiliser ces boutons Avancés.\n\n" +
                    "• Si cela vous intéresse, survolez un bouton pour voir les détails dans le panneau de droite."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**FAITES ATTENTION** en utilisant le bouton [DEBUG: TOUT RÉINITIALISER]. Si vous l’utilisez par erreur, vous pouvez récupérer les succès complétés avec le bouton [Déverrouiller la sélection]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG : TOUT RÉINITIALISER" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**AVERTISSEMENT** : réinitialise **tous** les succès. Utile pour les tests.\n" +
                    "Si vous l’utilisez par erreur, vous pouvez les récupérer avec le bouton [Déverrouiller la sélection]."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "Avertissement : RÉINITIALISER / EFFACER tous les succès vers l’état NON complété. Continuer ?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
