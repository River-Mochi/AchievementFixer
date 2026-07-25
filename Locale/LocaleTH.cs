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
        private readonly AFSettings m_Setting;

        public LocaleTH(AFSettings setting)
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
                { m_Setting.GetOptionTabLocaleID(AFSettings.MainTab),     "หลัก" },
                { m_Setting.GetOptionTabLocaleID(AFSettings.AdvancedTab), "ขั้นสูง" },

                // Groups (Main tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.NotesGroup),    "หมายเหตุ" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.MainInfoGroup), "ข้อมูล" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.ButtonGroup),   "ลิงก์สนับสนุน" },

                // Groups (Advanced tab)
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowActions), "การดำเนินการ" },
                { m_Setting.GetOptionGroupLocaleID(AFSettings.AdvRowDebug),   "DEBUG" },

                // Main >> Notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.MainNotes)),
                    "<• เปิดใช้งานความสำเร็จแล้ว;> เพียงทำภารกิจตามข้อกำหนดเพื่อปลดล็อกความสำเร็จตามปกติ\n\n" +
                    "ขอให้สนุก! :)\n"
                },

                // Main >> Info
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.NameDisplay)),    "ม็อด" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.NameDisplay)),     "ชื่อที่แสดงของม็อดนี้" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.VersionDisplay)), "เวอร์ชัน" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.VersionDisplay)),  "หมายเลขเวอร์ชันปัจจุบัน" },

                // Main >> Links
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenParadoxButton)), "Paradox" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenParadoxButton)), "เปิดหน้าเว็บ **Paradox** สำหรับม็อดของผู้สร้างรายนี้ในเบราว์เซอร์" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenDiscordButton)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenDiscordButton)), "เปิด **Discord** สำหรับการสร้างม็อด CS2 ในเบราว์เซอร์" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "วิกิความสำเร็จ" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.OpenAchievementsWikiButton)), "เปิด **วิกิ** ความสำเร็จในเบราว์เซอร์" },

                // --- Advanced tab ---
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.SelectedAchievement)),   "เลือกความสำเร็จ" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.SelectedAchievement)),    "เลือกความสำเร็จที่ต้องการดำเนินการ" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.UnlockSelectedAchievement)), "ปลดล็อกที่เลือก" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.UnlockSelectedAchievement)),  "**ปลดล็อกและทำสำเร็จ** ความสำเร็จที่เลือก" },

                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ClearSelectedAchievement)),  "ล้างที่เลือก" },
                { m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ClearSelectedAchievement)),   "ทำเครื่องหมายความสำเร็จที่เลือกว่า **ยังไม่สำเร็จ**" },
                { m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ClearSelectedAchievement)), "ล้าง / รีเซ็ตความสำเร็จนี้\n\nดำเนินการต่อหรือไม่?" },

                // Advanced >> advisory text notes
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "• หมายเหตุ: ความสำเร็จ <เปิดใช้งานอยู่แล้ว> (ค่าเริ่มต้น) โดยไม่ต้องใช้ปุ่มขั้นสูงเหล่านี้\n\n" +
                    "• หากต้องการดูรายละเอียด ให้วางเมาส์เหนือปุ่มใดก็ได้เพื่อดูข้อมูลในแผงด้านขวา"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.AdvancedAdvisory)),
                    "โปรด **ระมัดระวัง** เมื่อใช้ปุ่ม [DEBUG: รีเซ็ตทั้งหมด] หากกดโดยไม่ตั้งใจ สามารถกู้คืนความสำเร็จที่เคยทำสำเร็จได้ด้วยปุ่ม [ปลดล็อกที่เลือก]"
                },

                // Advanced >> DEBUG
                { m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAchievements)), "DEBUG - รีเซ็ตทั้งหมด" },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "**คำเตือน**: ล้าง/รีเซ็ตความสำเร็จทั้งหมด ใช้สำหรับการดีบักหรือการทดสอบ\n" +
                    "หากกดโดยไม่ตั้งใจ สามารถกู้คืนความสำเร็จได้ด้วยปุ่ม [ปลดล็อกที่เลือก]\n" +
                    "[รีเซ็ตทั้งหมด] แล้วเริ่มใหม่ เพื่อปลดล็อกความสำเร็จอีกรอบสนุก ๆ"
                },
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(AFSettings.ResetAllAdvisory)),
                    "• <[รีเซ็ตทั้งหมด]> เพื่อเริ่มใหม่และปลดล็อกความสำเร็จอีกรอบสนุก ๆ"
                },

                // Confirmation modal Yes/No
                {
                    m_Setting.GetOptionWarningLocaleID(nameof(AFSettings.ResetAllAchievements)),
                    "คำเตือน: รีเซ็ต/ล้างความสำเร็จทั้งหมดให้เป็นสถานะยังไม่สำเร็จ ดำเนินการต่อหรือไม่?"
                },
            };
        }

        public void Unload()
        {
        }
    }
}

