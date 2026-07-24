// <copyright file="Mod.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// Mod.cs

namespace AchievementFixer
{
    using System.Collections.Generic;
    using System.Reflection;
    using Colossal.IO.AssetDatabase;
    using Colossal.Localization;
    using Colossal.Logging;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Achievements;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        // ---- PUBLIC CONSTANTS / METADATA ----
        public const string ModName = "Achievement Fixer";
        public const string ModId = "AchievementFixer";
        public const string ModTag = "[AF]";

        /// <summary>
        /// Read Version from .csproj (3-part).
        /// </summary>
        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        // CO logger
        private static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        private static bool s_BannerLogged;
        private AFSettings? m_Settings;

        public void OnLoad(UpdateSystem updateSystem)
        {
            LogUtils.Configure(ModId, s_Log);

            // no-repeat metadata banner top of AF log.
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                LogUtils.Info($"{ModName} {ModTag} v{ModVersion} OnLoad");
            }

            // Settings object must exist before creating locale sources.
            AFSettings settings = new AFSettings(this);
            m_Settings = settings;

            LocalizationManager? localizationManager =
                GameManager.instance?.localizationManager;

            if (localizationManager != null)
            {
                // Options UI strings.
                localizationManager.AddSource("en-US", new LocaleEN(settings));
                localizationManager.AddSource("fr-FR", new LocaleFR(settings));
                localizationManager.AddSource("de-DE", new LocaleDE(settings));
                localizationManager.AddSource("es-ES", new LocaleES(settings));
                localizationManager.AddSource("it-IT", new LocaleIT(settings));
                localizationManager.AddSource("ja-JP", new LocaleJA(settings));
                localizationManager.AddSource("ko-KR", new LocaleKO(settings));
                localizationManager.AddSource("vi-VN", new LocaleVI(settings));
                localizationManager.AddSource("pl-PL", new LocalePL(settings));
                localizationManager.AddSource("pt-BR", new LocalePT_BR(settings));
                localizationManager.AddSource("pt-PT", new LocalePT_PT(settings));
                localizationManager.AddSource("zh-HANS", new LocaleZH_CN(settings));
                localizationManager.AddSource("zh-HANT", new LocaleZH_HANT(settings));
                localizationManager.AddSource("th-TH", new LocaleTH(settings));
                localizationManager.AddSource("uk-UA", new LocaleUK(settings));

                // Override the game's built-in "achievements disabled" banner.
                foreach (string localeId in LocaleBannerText.LocaleIds)
                {
                    localizationManager.AddSource(
                        localeId,
                        new LocaleOverrideSource(new Dictionary<string, string>
                        {
                            ["Menu.ACHIEVEMENTS_WARNING_MODS"] =
                                LocaleBannerText.For(localeId)
                        }));
                }
            }
            else
            {
                LogUtils.Warn(
                    $"{ModTag} LocalizationManager is null; locale sources were not registered.");
            }

            AssetDatabase.global.LoadSettings(
                ModId,
                settings,
                new AFSettings(this));

            settings.RegisterInOptionsUI();

            // Run after the game's achievement trigger during the main loop.
            updateSystem.UpdateAfter<AchievementFixerSystem, AchievementTriggerSystem>(
                SystemUpdatePhase.MainLoop);
        }

        public void OnDispose()
        {
            m_Settings?.UnregisterInOptionsUI();
            m_Settings = null;
        }
    }
}
