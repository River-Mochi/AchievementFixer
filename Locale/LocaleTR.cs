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
        private readonly Settings m_Setting;

        public LocaleTR(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Ana"      },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Gelişmiş" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Notlar"       },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Bilgi"        },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Destek Bağlantıları" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "İşlemler" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"    },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• Başarımlar artık etkin;> sadece gereken görevleri yaparak başarımları doğal olarak tamamlayın.\n\n" +
                    "Keyifli oyunlar! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Bu modun görünen adı." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Sürüm" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Mevcut sürüm numarası." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)),  "Bu yazarın modları için **Paradox** web sayfasını açın." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),  "CS2 modlama **Discord** sunucusunu tarayıcınızda açın." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Başarımlar Wiki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "Başarımlar **Wiki** sayfasını tarayıcınızda açın." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Başarım seç" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "İşlem yapılacak bir başarım seçin." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "SEÇİLENİ AÇIN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "Seçilen başarımı **açar ve tamamlar**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "SEÇİLENİ TEMİZLE" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Seçilen başarımı **tamamlanmadı** olarak işaretler." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "Bu başarımı TEMİZLE / SIFIRLA.\n\nDevam edilsin mi?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• Not: başarımlar bu Gelişmiş düğmeleri kullanmadan <zaten etkin> (varsayılan).\n\n" +
                    "• İlgileniyorsanız, sağ yan panelde ayrıntıları görmek için herhangi bir düğmenin üzerine gelin."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "[DEBUG: TÜMÜNÜ SIFIRLA] düğmesini kullanırken **DİKKATLİ OLUN**. Yanlışlıkla kullanırsanız, tamamlanan başarımları [Seçileni Aç] düğmesi ile kurtarabilirsiniz."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: TÜMÜNÜ SIFIRLA" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**UYARI**: **TÜM** başarımları temizler/sıfırlar. Hata ayıklama veya test için yararlıdır.\n" +
                    "Bunu yanlışlıkla kullanırsanız, [Seçileni Aç] düğmesini kullanarak başarımları geri alabilirsiniz."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "Uyarı Uyarı: TÜM başarımları tamamlanmadı durumuna SIFIRLA/TEMİZLE. Devam edilsin mi?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
