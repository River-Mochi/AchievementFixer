// LocaleVI.cs

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
                { m_Setting.GetSettingsLocaleID(), Mod.ModName },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "Chính" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "Nâng cao" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Ghi chú" },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "Thông tin" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Liên kết hỗ trợ" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Thao tác" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• Thành tựu hiện đã được bật;> bạn chỉ cần chơi và hoàn thành các yêu cầu, thành tựu sẽ được mở khóa tự nhiên.\n\n" +
                    "Chúc bạn chơi vui! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Tên hiển thị của mod này." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Phiên bản" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Số phiên bản hiện tại của mod." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)),  "Mở trang Paradox với các mod của tác giả này trong trình duyệt." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)),  "Mở Discord modding CS2 trong trình duyệt." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki thành tựu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),  "Mở wiki về thành tựu trong trình duyệt." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Chọn thành tựu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Chọn thành tựu bạn muốn thao tác." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "MỞ KHÓA ĐÃ CHỌN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Mở khóa và hoàn thành** thành tựu đã chọn ngay lập tức." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "XÓA ĐÃ CHỌN" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Đánh dấu thành tựu đã chọn là **chưa hoàn thành**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "Xóa / đặt lại thành tựu này.\n\nTiếp tục?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• Lưu ý: thành tựu <đã được bật sẵn> theo mặc định, không cần dùng các nút ở tab Nâng cao.\n\n" +
                    "• Nếu muốn xem chi tiết, hãy rê chuột lên bất kỳ nút nào để xem mô tả ở bảng bên phải."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "Hãy **cẩn thận** khi dùng nút [DEBUG: ĐẶT LẠI TẤT CẢ]. Nếu lỡ nhấn, bạn vẫn có thể khôi phục các thành tựu đã hoàn thành bằng nút [MỞ KHÓA ĐÃ CHỌN]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: ĐẶT LẠI TẤT CẢ" }, // Button label
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**CẢNH BÁO**: xóa / đặt lại TẤT CẢ thành tựu. Hữu ích cho việc kiểm thử và debug.\n" +
                    "Nếu lỡ tay, bạn có thể dùng [MỞ KHÓA ĐÃ CHỌN] để lấy lại thành tựu."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "Cảnh báo: tất cả thành tựu sẽ được đặt lại về trạng thái **chưa hoàn thành**. Tiếp tục?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
