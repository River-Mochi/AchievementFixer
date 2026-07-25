// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

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
        private readonly AFSettings m_Setting;

        public LocaleVI(AFSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(AFSettings.MainTab),     "Chính" },
                { m_Setting.GetOptionTabLocaleID(AFSettings.AdvancedTab), "Nâng cao" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.NotesGroup),    "Ghi chú" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.MainInfoGroup), "Thông tin" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.ButtonGroup),   "Liên kết hỗ trợ" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowActions), "Thao tác" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.MainNotes)),
                    "<• Thành tựu hiện đã được bật;> bạn chỉ cần chơi và hoàn thành các yêu cầu, thành tựu sẽ được mở khóa tự nhiên.\n\n" +
                    "Chúc bạn chơi vui! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.NameDisplay)),    "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.NameDisplay)),     "Tên hiển thị của mod này." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.VersionDisplay)), "Phiên bản" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.VersionDisplay)),  "Số phiên bản hiện tại của mod." },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenParadoxButton)),  "Mở trang Paradox với các mod của tác giả này trong trình duyệt." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenDiscordButton)),  "Mở Discord modding CS2 trong trình duyệt." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "Wiki thành tựu" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)),  "Mở wiki về thành tựu trong trình duyệt." },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.SelectedAchievement)),   "Chọn thành tựu" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.SelectedAchievement)),    "Chọn thành tựu bạn muốn thao tác." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.UnlockSelectedAchievement)), "MỞ KHÓA ĐÃ CHỌN" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.UnlockSelectedAchievement)),  "**Mở khóa và hoàn thành** thành tựu đã chọn ngay lập tức." },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ClearSelectedAchievement)),  "XÓA ĐÃ CHỌN" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ClearSelectedAchievement)),   "Đánh dấu thành tựu đã chọn là **chưa hoàn thành**." },
                { m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ClearSelectedAchievement)), "Xóa / đặt lại thành tựu này.\n\nTiếp tục?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "• Lưu ý: thành tựu <đã được bật sẵn> theo mặc định, không cần dùng các nút ở tab Nâng cao.\n\n" +
                    "• Nếu muốn xem chi tiết, hãy rê chuột lên bất kỳ nút nào để xem mô tả ở bảng bên phải."
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "Hãy **cẩn thận** khi dùng nút [DEBUG: ĐẶT LẠI TẤT CẢ]. Nếu lỡ nhấn, bạn vẫn có thể khôi phục các thành tựu đã hoàn thành bằng nút [MỞ KHÓA ĐÃ CHỌN]."
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAchievements)), "DEBUG - ĐẶT LẠI TẤT CẢ" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "**CẢNH BÁO**: xóa / đặt lại TẤT CẢ thành tựu. Hữu ích cho việc kiểm thử và debug.\n" +
                    "Nếu lỡ tay, bạn có thể dùng [MỞ KHÓA ĐÃ CHỌN] để lấy lại thành tựu.\n" +
                    "[Đặt lại tất cả] để chơi lại từ đầu và mở khóa thành tựu lần nữa cho vui."
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAdvisory)),
                    "• <[Đặt lại tất cả]> thành tựu để chơi lại từ đầu và mở khóa lần nữa cho vui."
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "Cảnh báo: tất cả thành tựu sẽ được đặt lại về trạng thái **chưa hoàn thành**. Tiếp tục?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}

