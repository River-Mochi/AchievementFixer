// <copyright file="AchievementFixerSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// AchievementFixerSystem.cs
namespace AchievementFixer
{
    using Colossal.PSI.Common;              // PlatformManager
    using Colossal.Serialization.Entities;  // Purpose enum
    using CS2Shared.RiverMochi;              // LogUtils
    using Game;                              // GameSystemBase, GameMode

    /// <summary>
    /// After a game load completes, keep achievements enabled for a frame-based window,
    /// then go completely idle.
    /// </summary>
    public sealed partial class AchievementFixerSystem : GameSystemBase
    {
        // --- Tunables (frames) ---
        private const int kAssertFrames = 1800;  // ~30s @ 60FPS or ~60s @ 30FPS

        // --- State ---
        private int m_FramesLeft;  // counts down from kAssertFrames to 0

        protected override void OnCreate()
        {
            base.OnCreate();

            m_FramesLeft = 0;

            // Start idle so the system is not scheduled until a real game load occurs.
            Enabled = false;

#if DEBUG
            LogUtils.Info("AchievementFixerSystem created (idle)");
#endif
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            // Only assert while entering real gameplay; skip menu/editor.
            if (mode != GameMode.Game)
            {
                Enabled = false;
#if DEBUG
                LogUtils.Info(
                    $"OnGameLoadingComplete: mode={mode}; not gameplay → skipping.");
#endif
                return;
            }

            // Open the frame-based assert window and start ticking.
            m_FramesLeft = kAssertFrames;
            Enabled = true;

            // Enforce immediately at first tick.
            ForceEnableIfNeeded("OnGameLoadingComplete");

#if DEBUG
            LogUtils.Info($"Assert window started: {kAssertFrames} frames.");
#endif
        }

        protected override void OnUpdate()
        {
            // If the assert window ended, go idle.
            if (m_FramesLeft <= 0)
            {
                Enabled = false;
                return;
            }

            // Keep achievementsEnabled true; checking every frame is cheap and robust.
            ForceEnableIfNeeded("OnUpdate");

            m_FramesLeft--;

#if DEBUG
            // Every ~60 frames, log a coarse heartbeat to avoid noise.
            if (m_FramesLeft % 60 == 0)
            {
                bool achievementsOn =
                    PlatformManager.instance?.achievementsEnabled == true;

                LogUtils.Info(
                    () => $"Asserting… framesLeft={m_FramesLeft}, " +
                          $"achievementsEnabled={(achievementsOn ? "TRUE" : "FALSE")}");
            }
#endif
        }

        private static void ForceEnableIfNeeded(string source)
        {
            PlatformManager pm = PlatformManager.instance;
            if (pm == null)
            {
#if DEBUG
                LogUtils.WarnOnce(
                    "AchievementFixer.PlatformManagerNull",
                    () => $"{source}: PlatformManager.instance is null; skipping.");
#endif
                return;
            }

            if (!pm.achievementsEnabled)
            {
                // Keep these Release logs as proof that the mod corrected the game state.
                LogUtils.Info(
                    $"{source}: detected achievementsEnabled == FALSE; forcing TRUE.");

                pm.achievementsEnabled = true;

                LogUtils.Info($"{source}: achievementsEnabled is now TRUE.");
            }
        }
    }
}
