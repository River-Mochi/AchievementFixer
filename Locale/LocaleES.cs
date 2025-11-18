// LocaleES.cs
namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Spanish locale (es-ES)
    /// </summary>
    public class LocaleES : IDictionarySource
    {
        private readonly Settings m_Setting;

        public LocaleES(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Avanzado"  },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notas"          },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Información"    },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Enlaces de soporte" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Acciones" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"   },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• Los logros están activados ahora;> simplemente realiza las tareas necesarias para completarlos de forma natural.\n\n" +
                    "¡Disfruta! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Nombre visible de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Versión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Número de versión actual." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)),  "Abrir la página de **Paradox** con los mods de este autor." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),  "Abrir el **Discord** de modding de CS2 en el navegador." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki de logros" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "Abrir la **wiki** de logros en el navegador." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Seleccionar logro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Elige un logro sobre el que operar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "DESBLOQUEAR SELECCIONADO" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Desbloquea y completa** el logro seleccionado." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "LIMPIAR SELECCIONADO" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Marca el logro seleccionado como **no completado**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "LIMPIAR / RESTABLECER este logro.\n\n¿Continuar?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• Nota: los logros ya están <activados> (por defecto) sin usar estos botones Avanzados.\n\n" +
                    "• Si te interesa, pasa el ratón sobre cualquier botón para ver detalles en el panel derecho."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**TEN CUIDADO** al usar el botón [DEBUG: RESTABLECER TODO]. Si lo usas por error, puedes recuperar los logros completados con el botón [Desbloquear seleccionado]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: RESTABLECER TODO" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**ADVERTENCIA**: restablece **todos** los logros. Útil para pruebas.\n" +
                    "Si lo haces por error, puedes recuperarlos con el botón [Desbloquear seleccionado]."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "Advertencia: RESTABLECER / LIMPIAR todos los logros al estado NO completado. ¿Continuar?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
