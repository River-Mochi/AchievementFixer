using System.Collections.Generic;
using Colossal;

namespace AchievementFixer
{
    /// <summary>
    /// Spanish locale (es-ES)
    /// </summary>
    public class LocaleES : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleES(Settings setting) { m_Setting = setting; }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Principal" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Avanzado"  },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Información" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Enlaces"     },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notas"       },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Acciones" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"    },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod"      },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Nombre visible de este mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Versión"  },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Versión actual del mod." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki de logros" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),
                  "Abrir el wiki de logros en tu navegador." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "Notas:\n" +
                    "• Los logros están habilitados: solo realiza las tareas requeridas para completarlos de forma natural.\n" +
                    "• ¡Disfruta! :)\n\n" +
                    "• Steam muestra 6 logros que no estarán disponibles hasta que se lance el DLC \"Bridges & Ports\"." },

                { m_Setting.GetOptionDescLocaleID(nameof(Settings.MainNotes)),
                    "Nota: a veces, tras completar los requisitos, el logro puede no aparecer hasta reiniciar el juego." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Seleccionar logro" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Elige un logro sobre el que operar." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "Desbloquear seleccionado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Desbloquea y completa** el logro seleccionado." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "Restablecer seleccionado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Marca el logro seleccionado como **no completado**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "BORRAR / RESTABLECER este logro.\n\n¿Continuar?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• Este mod ya habilita los logros (por defecto) sin usar botones en la pestaña Avanzado.\n" +
                  "• Si quieres que sea más rápido, prueba el botón [Desbloquear seleccionado]." },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**CUIDADO** al usar el botón [RESET ALL]. Si lo usas por error, puedes recuperar logros con [Desbloquear seleccionado]." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "Depuración:  REINICIAR TODO" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**ADVERTENCIA**: restablece TODOS los logros. Útil para depurar o probar.\n" +
                    "Si lo usas por accidente, puedes recuperar logros con [Desbloquear seleccionado]." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "Advertencia: RESTABLECER/LIMPIAR todos los logros a **no completado**. ¿Continuar?" },
            };
        }

        public void Unload() { }
    }
}
