// <copyright file="LocaleTH.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// LocaleTH.cs
namespace AchievementFixer
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Thai locale (th-TH)
    /// </summary>
    public class LocaleTH : IDictionarySource
    {
        private readonly Settings m_Setting;

        public LocaleTH(Settings setting)
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
                { m_Setting.GetOptionTabLocaleID(Settings.MainTab),     "หลัก" },
                { m_Setting.GetOptionTabLocaleID(Settings.AdvancedTab), "ขั้นสูง" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.NotesGroup),    "หมายเหตุ" },
                { m_Setting.GetOptionGroupLocaleID(Settings.MainInfoGroup), "ข้อมูล" },
                { m_Setting.GetOptionGroupLocaleID(Settings.ButtonGroup),   "ลิงก์สนับสนุน" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowActions), "การดำเนินการ" },
                { m_Setting.GetOptionGroupLocaleID(Settings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.MainNotes)),
                    "<• เปิดใช้งานความสำเร็จแล้ว;> เพียงทำภารกิจตามข้อกำหนดเพื่อปลดล็อกความสำเร็จตามปกติ\n\n" +
                    "ขอให้สนุก! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.NameDisplay)),    "ม็อด" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.NameDisplay)),     "ชื่อที่แสดงของม็อดนี้" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.VersionDisplay)), "เวอร์ชัน" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.VersionDisplay)),  "หมายเลขเวอร์ชันปัจจุบัน" },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenParadoxButton)), "เปิดหน้าเว็บ **Paradox** สำหรับม็อดของผู้สร้างรายนี้ในเบราว์เซอร์" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenDiscordButton)), "เปิด **Discord** สำหรับการสร้างม็อด CS2 ในเบราว์เซอร์" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "วิกิความสำเร็จ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.OpenAchievementsWikiButton)), "เปิด **วิกิ** ความสำเร็จในเบราว์เซอร์" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.SelectedAchievement)),   "เลือกความสำเร็จ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.SelectedAchievement)),    "เลือกความสำเร็จที่ต้องการดำเนินการ" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.UnlockSelectedAchievement)), "ปลดล็อกที่เลือก" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.UnlockSelectedAchievement)),  "**ปลดล็อกและทำสำเร็จ** ความสำเร็จที่เลือก" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ClearSelectedAchievement)),  "ล้างที่เลือก" },
                { m_Setting.GetOptionDescLocaleID(nameof(Settings.ClearSelectedAchievement)),   "ทำเครื่องหมายความสำเร็จที่เลือกว่า **ยังไม่สำเร็จ**" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Settings.ClearSelectedAchievement)), "ล้าง / รีเซ็ตความสำเร็จนี้\n\nดำเนินการต่อหรือไม่?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "• หมายเหตุ: ความสำเร็จ <เปิดใช้งานอยู่แล้ว> (ค่าเริ่มต้น) โดยไม่ต้องใช้ปุ่มขั้นสูงเหล่านี้\n\n" +
                    "• หากต้องการดูรายละเอียด ให้วางเมาส์เหนือปุ่มใดก็ได้เพื่อดูข้อมูลในแผงด้านขวา"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.AdvancedAdvisory)),
                    "โปรด **ระมัดระวัง** เมื่อใช้ปุ่ม [DEBUG: รีเซ็ตทั้งหมด] หากกดโดยไม่ตั้งใจ สามารถกู้คืนความสำเร็จที่เคยทำสำเร็จได้ด้วยปุ่ม [ปลดล็อกที่เลือก]"
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(Settings.ResetAllAchievements)),  "DEBUG: รีเซ็ตทั้งหมด" }, // Button label
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Settings.ResetAllAchievements)),
                    "**คำเตือน**: ล้าง/รีเซ็ตความสำเร็จทั้งหมด ใช้สำหรับการดีบักหรือการทดสอบ\n" +
                    "หากกดโดยไม่ตั้งใจ สามารถกู้คืนความสำเร็จได้ด้วยปุ่ม [ปลดล็อกที่เลือก]"
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(Settings.ResetAllAchievements)),
                    "คำเตือน: รีเซ็ต/ล้างความสำเร็จทั้งหมดให้เป็นสถานะยังไม่สำเร็จ ดำเนินการต่อหรือไม่?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
