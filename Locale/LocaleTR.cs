// <copyright file="LocaleTR.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleTR.cs
namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Turkish locale (tr-TR)
    /// </summary>
    public class LocaleTR : IDictionarySource
    {
        private readonly AFSettings m_Setting;

        public LocaleTR(AFSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(AFSettings.MainTab),     "Ana"     },
                { m_Setting.GetOptionTabLocaleID(AFSettings.AdvancedTab), "Gelişmiş" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.NotesGroup),    "Notlar"  },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.MainInfoGroup), "Bilgi"   },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.ButtonGroup),   "Destek Linkleri" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowActions), "İşlemler" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowDebug),   "DEBUG"    },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.MainNotes)),
                    "<• Başarımlar artık etkin;> başarımları doğal yoldan tamamlamak için gereken görevleri yapman yeterli.\n\n" +
                    "İyi eğlenceler! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.NameDisplay)),     "Bu modun görünen adı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.VersionDisplay)), "Sürüm" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.VersionDisplay)),  "Geçerli sürüm numarası." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenParadoxButton)), "Bu yapımcının modları için **Paradox** sayfasını tarayıcıda aç." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenDiscordButton)), "CS2 **Discord** sunucusunu tarayıcıda aç." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "Başarımlar Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "Başarımlar **Wiki** sayfasını tarayıcıda aç." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.SelectedAchievement)),   "Başarım seç" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.SelectedAchievement)),    "Üzerinde işlem yapılacak başarımı seç." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.UnlockSelectedAchievement)), "SEÇİLENİN KİLİDİNİ AÇ" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.UnlockSelectedAchievement)),  "Seçilen başarımın **kilidini açar ve tamamlar**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ClearSelectedAchievement)),  "SEÇİLENİ TEMİZLE" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ClearSelectedAchievement)),   "Seçilen başarımı **tamamlanmadı** olarak işaretler." },
                { m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ClearSelectedAchievement)), "Bu başarımı TEMİZLE / SIFIRLA.\n\nDevam edilsin mi?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "• Not: başarımlar bu gelişmiş düğmeleri kullanmadan da <zaten etkin> (varsayılan).\n\n" +
                    "• Ayrıntılar için herhangi bir düğmenin üstüne gel; sağ panelde gösterilir."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "**DİKKATLİ OL**: [DEBUG - TÜMÜNÜ SIFIRLA] düğmesini kullanırken dikkat et. Yanlışlıkla kullanırsan, tamamlanan başarımları [Seçilenin Kilidini Aç] düğmesiyle geri alabilirsin."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAchievements)), "DEBUG - TÜMÜNÜ SIFIRLA" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "**UYARI**: TÜM başarımları temizler/sıfırlar. Debug veya test için kullanışlıdır.\n" +
                    "Bunu yanlışlıkla kullanırsan, başarımları [Seçilenin Kilidini Aç] düğmesiyle geri alabilirsin.\n" +
                     "<[Tümünü sıfırla]> yeniden başlamak için kullanılır (başarımları tekrar eğlencesine kazanmak istersen)."
                },


                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "Uyarı Uyarı: TÜM başarımları TAMAMLANMADI durumuna SIFIRLA/TEMİZLE. Devam edilsin mi?"
                },

            };
        }

        public void Unload()
        {
        }
    }
}
