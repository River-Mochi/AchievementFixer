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
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Colossal.IO.AssetDatabase;
    using Colossal.Localization;
    using Colossal.Logging;
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

        // ----- Logger & public properties -----
        public static readonly ILog s_Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(false);

        public static Settings? Settings
        {
            get; private set;
        }

        // ----- Private state -----
        private static bool s_BannerLogged;

        // ----- IMod -----
        public void OnLoad(UpdateSystem updateSystem)
        {
            // metadata banner (once)
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                s_Log.Info($"{ModName} {ModTag} v{ModVersion} OnLoad");
            }

            if (GameManager.instance == null)
            {
                s_Log.Warn($"{ModTag} GameManager.instance is null; {ModName} cannot initialize.");
                return;
            }

            // Settings object (must exist before locales so labels resolve)
            var settings = new Settings(this);
            Settings = settings;

            try
            {
                LocalizationManager? localizationManager = GameManager.instance.localizationManager;
                if (localizationManager == null)
                {
                    s_Log.Warn($"{ModTag} LocalizationManager is null; locale sources were not registered.");
                }
                else
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

                    // Built-in achievement warning banner override.
                    foreach (string localeId in LocaleBannerText.LocaleIds)
                    {
                        localizationManager.AddSource(localeId, CreateBannerOverrideSource(localeId));
                    }
                }
            }
            catch (Exception ex)
            {
                s_Log.Warn($"{ModTag} Localization registration failed: {ex.GetType().Name}: {ex.Message}");
            }

            // Load settings if available, then register Options UI.
            try
            {
                AssetDatabase.global.LoadSettings(ModId, settings, new Settings(this));
            }
            catch (Exception ex)
            {
                s_Log.Warn($"{ModTag} Settings load failed: {ex.GetType().Name}: {ex.Message}");
            }

            try
            {
                settings.RegisterInOptionsUI();
            }
            catch (Exception ex)
            {
                s_Log.Warn($"{ModTag} Options UI registration failed: {ex.GetType().Name}: {ex.Message}");
            }

            try
            {
                // Ensure AF system runs after the game's trigger during the main loop.
                updateSystem.UpdateAfter<AchievementFixerSystem, AchievementTriggerSystem>(SystemUpdatePhase.MainLoop);
            }
            catch (Exception ex)
            {
                s_Log.Warn($"{ModTag} System scheduling failed: {ex.GetType().Name}: {ex.Message}");
            }
        }

        public void OnDispose()
        {
            Settings?.UnregisterInOptionsUI();
            Settings = null;
        }

        private static LocaleOverrideSource CreateBannerOverrideSource(string localeId)
        {
            const string kWarningKey = "Menu.ACHIEVEMENTS_WARNING_MODS";

            return new LocaleOverrideSource(new Dictionary<string, string>
            {
                [kWarningKey] = LocaleBannerText.For(localeId)
            });
        }
    }
}
