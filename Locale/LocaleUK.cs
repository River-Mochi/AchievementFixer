// <copyright file="LocaleUK.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleUK.cs
namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Ukrainian locale (uk-UA)
    /// </summary>
    public class LocaleUK : IDictionarySource
    {
        private readonly Settings m_Setting;

        public LocaleUK(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Основне" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Розширені" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Примітки" },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Інформація" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Посилання підтримки" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Дії" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• Досягнення вже ввімкнено;> просто виконуйте необхідні завдання, щоб вони відкривалися природним шляхом.\n\n" +
                    "Приємної гри! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Мод" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Назва цього мода." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Версія" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Поточний номер версії." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)), "Відкрити у браузері сторінку **Paradox** із модами цього автора." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)), "Відкрити у браузері **Discord** для модингу CS2." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Вікі досягнень" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Відкрити у браузері **вікі** досягнень." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Вибрати досягнення" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Виберіть досягнення, з яким потрібно виконати дію." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "РОЗБЛОКУВАТИ ВИБРАНЕ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Розблоковує та зараховує** вибране досягнення." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "ОЧИСТИТИ ВИБРАНЕ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Позначає вибране досягнення як **не виконане**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "ОЧИСТИТИ / СКИНУТИ це досягнення.\n\nПродовжити?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• Примітка: досягнення <вже ввімкнено> (за замовчуванням) без використання цих кнопок на вкладці «Розширені».\n\n" +
                    "• Щоб дізнатися більше, наведіть курсор на будь-яку кнопку — подробиці з’являться на панелі праворуч."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**БУДЬТЕ ОБЕРЕЖНІ** з кнопкою [DEBUG: СКИНУТИ ВСЕ]. Якщо натиснути її випадково, виконані досягнення можна відновити кнопкою [РОЗБЛОКУВАТИ ВИБРАНЕ]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: СКИНУТИ ВСЕ" }, // Button label
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**ПОПЕРЕДЖЕННЯ**: очищає/скидає ВСІ досягнення. Корисно для налагодження або тестування.\n" +
                    "Якщо зробити це випадково, досягнення можна повернути кнопкою [РОЗБЛОКУВАТИ ВИБРАНЕ]."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "Попередження: СКИНУТИ/ОЧИСТИТИ всі досягнення до стану «НЕ виконано». Продовжити?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
