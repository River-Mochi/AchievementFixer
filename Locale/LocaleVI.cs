namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;
    /// <summary>
    /// Vietnamese locale (vi-VN)
    /// </summary>
    public class LocaleVI : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleVI(Settings setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options menu entry
                { m_Setting.GetSettingsLocaleID(), Mod.Name },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Chính"     },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Nâng cao"  },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Thông tin" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Liên kết hỗ trợ"  },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Ghi chú"   },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Thao tác" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"    },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Tên hiển thị của mod này." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Phiên bản" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Phiên bản hiện tại của mod." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki thành tựu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "Mở wiki thành tựu trong trình duyệt." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)),          "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),           "Mở Discord modding CS2 trong trình duyệt." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "Ghi chú:\n" +
                    "• Thành tựu đã được bật — chỉ cần làm đủ yêu cầu để mở khóa tự nhiên.\n\n" +
                    "Chúc chơi vui! :)\n\n" +
                    "• Một số thành tựu chỉ có khi DLC phát hành (ví dụ: Bridges & Ports)." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Chọn thành tựu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Chọn thành tựu để thao tác." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "MỞ KHÓA ĐANG CHỌN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "Đánh dấu thành tựu đã chọn là **đã mở khóa & hoàn thành**." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "ĐẶT LẠI ĐANG CHỌN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Đặt thành tựu đã chọn về trạng thái **chưa hoàn thành**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)),"ĐẶT LẠI thành tựu này.\n\nTiếp tục?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• Mod này đã bật thành tựu sẵn (mặc định) — không cần dùng nút ở thẻ Nâng cao.\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**CẨN THẬN** với [DEBUG: ĐẶT LẠI TẤT CẢ]. Lỡ bấm thì có thể khôi phục bằng [MỞ KHÓA ĐANG CHỌN]." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: ĐẶT LẠI TẤT CẢ" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**CẢNH BÁO**: đặt lại **TẤT CẢ** thành tựu. Hữu ích cho việc thử nghiệm.\n" +
                    "Nếu lỡ tay, dùng [MỞ KHÓA ĐANG CHỌN] để khôi phục." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "Cảnh báo: ĐẶT LẠI tất cả thành tựu về **chưa hoàn thành**. Tiếp tục?" },
            };
        }

        public void Unload()
        {
        }
    }
}
