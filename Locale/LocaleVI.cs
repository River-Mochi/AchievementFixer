using System.Collections.Generic;
using Colossal;

namespace AchievementFixer
{
    /// <summary>
    /// Vietnamese locale (vi-VN)
    /// </summary>
    public class LocaleVI : IDictionarySource
    {
        private readonly Settings m_Setting;
        public LocaleVI(Settings setting) { m_Setting = setting; }

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
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "Liên kết"  },
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "Ghi chú"   },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "Hành động" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG"     },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "Mod"        },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "Tên hiển thị của mod này." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "Phiên bản"  },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "Phiên bản hiện tại của mod." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "Wiki thành tựu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)),
                  "Mở wiki thành tựu trong trình duyệt của bạn." },

                // Main >> Notes
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "Ghi chú:\n" +
                    "• Thành tựu hiện đang được bật — chỉ cần hoàn thành các nhiệm vụ yêu cầu để đạt được tự nhiên.\n" +
                    "• Chúc bạn vui vẻ! :)\n\n" +
                    "• Steam hiển thị 6 thành tựu sẽ chỉ khả dụng khi DLC “Bridges & Ports” phát hành." },

                { m_Setting.GetOptionDescLocaleID(nameof(Settings.MainNotes)),
                    "Lưu ý: đôi khi sau khi hoàn thành yêu cầu, thành tựu có thể không hiện cho đến khi khởi động lại game." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "Chọn thành tựu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "Chọn một thành tựu để thao tác." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "Mở khóa mục đã chọn" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**Mở khóa & hoàn thành** thành tựu đã chọn." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "Xóa mục đã chọn" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "Đánh dấu thành tựu đã chọn là **chưa hoàn thành**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "XÓA / ĐẶT LẠI thành tựu này.\n\nTiếp tục?" },

                // Advanced >> advisory text
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                  "• Mod này đã bật thành tựu (mặc định) mà không cần dùng các nút trong tab Nâng cao.\n" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "**CẨN THẬN** khi dùng nút [Gỡ lỗi:  ĐẶT LẠI TẤT CẢ]. Nếu bấm nhầm, bạn có thể khôi phục bằng [Mở khóa mục đã chọn]." },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "Gỡ lỗi:  ĐẶT LẠI TẤT CẢ" }, // Button label
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**CẢNH BÁO**: đặt lại TẤT CẢ các thành tựu. Hữu ích cho kiểm thử/gỡ lỗi.\n" +
                    "Nếu bấm nhầm, có thể khôi phục bằng [Mở khóa mục đã chọn]." },

                // Confirmation modal Yes/No
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)), "Cảnh báo: ĐẶT LẠI/XÓA tất cả thành tựu về trạng thái **chưa hoàn thành**. Tiếp tục?" },
            };
        }

        public void Unload() { }
    }
}
