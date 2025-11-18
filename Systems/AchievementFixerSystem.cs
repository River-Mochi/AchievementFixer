// AchievementFixerSystem.cs
namespace AchievementFixer
{
    using Colossal.PSI.Common;              // PlatformManager
    using Colossal.Serialization.Entities;  // Purpose enum
    using Game;                             // GameSystemBase, GameMode

    /// <summary>
    /// After a game load completes, keep achievements enabled for a frame-based window,
    /// then go completely idle.
    /// Also re-assert the banner warning override:
    ///   - once when gameplay starts
    ///   - once at the end of the assert window.
    /// </summary>
    public sealed partial class AchievementFixerSystem : GameSystemBase
    {
        // --- Tunables (frames) ---
        private const int kAssertFrames = 1800;  // ~30s @ 60FPS or ~60s @ 30FPS

        // --- State ---
        private int m_FramesLeft;        // counts down from kAssertFrames to 0

        protected override void OnCreate()
        {
            base.OnCreate();

            m_FramesLeft = 0;

            // Start idle so we don't get scheduled until a real game load occurs
            Enabled = false;

#if DEBUG
            Mod.s_Log.Info("AchievementFixerSystem created (idle)");
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
                Mod.s_Log.Info($"OnGameLoadingComplete: mode={mode}; not gameplay → skipping.");
#endif
                return;
            }

            // Open the frame-based assert window and start ticking.
            m_FramesLeft = kAssertFrames;
            Enabled = true;

            // Enforce immediately at first tick and push our banner once at start.
            ForceEnableIfNeeded("OnGameLoadingComplete");
            Mod.ReapplyBannerForActiveLocale();

#if DEBUG
            Mod.s_Log.Info($"Assert window started: {kAssertFrames} frames.");
#endif
        }

        protected override void OnUpdate()
        {
            // If the window ended, do one last banner re-apply (with a single Release log), then go idle.
            if (m_FramesLeft <= 0)
            {
                Mod.ReapplyBannerForActiveLocaleFinal();
                Enabled = false;
                return;
            }

            // Keep achievementsEnabled true — check every frame (cheap & robust)
            ForceEnableIfNeeded("OnUpdate");

            // Advance the window
            m_FramesLeft--;

#if DEBUG
            // Every ~60 frames, log a coarse heartbeat to avoid noise.
            if (m_FramesLeft % 60 == 0)
            {
                bool achievementsOn = PlatformManager.instance?.achievementsEnabled == true;
                string flag = achievementsOn ? "TRUE" : "FALSE";
                Mod.s_Log.Info($"Asserting… framesLeft={m_FramesLeft}, achievementsEnabled={flag}");
            }
#endif
        }

        private static bool ForceEnableIfNeeded(string source)
        {
            PlatformManager pm = PlatformManager.instance;
            if (pm == null)
            {
#if DEBUG
                Mod.s_Log.Info($"{source}: PlatformManager.instance is null; skip");
#endif
                return false;
            }

            if (!pm.achievementsEnabled)
            {
                // KEEP these Release logs (proof for players it's on)
                Mod.s_Log.Info($"{source}: ATTN: detected game flipped achievementsEnabled == FALSE. Forcing TRUE now");
                pm.achievementsEnabled = true;
                Mod.s_Log.Info($"{source}: achievementsEnabled is now TRUE.");
                return true;
            }

            return false;
        }
    }
}
