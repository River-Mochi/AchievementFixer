// AchievementFixerSystem.cs
namespace AchievementFixer
{
    using Colossal.PSI.Common;              // PlatformManager
    using Colossal.Serialization.Entities;  // Purpose enum
    using Game;                             // GameSystemBase, GameMode

    /// <summary>
    /// After a game load completes, keep achievements enabled for a frame-based window,
    /// then go completely idle.
    /// Re-assert the banner during that window to overwrite game "disabled banner".
    ///
    /// Lifecycle:
    ///   - OnCreate():   start disabled (no per-frame updates scheduled)
    ///   - OnGameLoadingComplete(Game): open assert window and enable the system
    ///   - OnUpdate():   enforce achievementsEnabled; re-apply banner at interval;
    ///                   when frames elapse, do one final banner apply (single log) then go idle
    /// </summary>
    public sealed partial class AchievementFixerSystem : GameSystemBase
    {
        // --- Tunables (frames) ---
        private const int kAssertFrames = 1800;  // ~30s @ 60FPS or ~60s @ 30FPS

        // Re-apply banner key to keep game or other mods from overriding it
        private const int kBannerReapplyEveryFrames = 60;   // ~2.0s @ 30fps or ~1.0s @ 60fps

        // --- State ---
        private int m_FramesLeft;        // counts down from kAssertFrames to 0
        private int m_BannerCountdown;   // counts down to next banner re-apply

        protected override void OnCreate()
        {
            base.OnCreate();

            m_FramesLeft = 0;
            m_BannerCountdown = 0;

            // Start idle so we don't get scheduled until a real game load occurs
            Enabled = false;

#if DEBUG
            Mod.Log.Info("AchievementFixerSystem created (idle)");
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
                Mod.Log.Info($"OnGameLoadingComplete: mode={mode}; not gameplay → skipping.");
#endif
                return;
            }

            // Open the frame-based assert window and start ticking.
            m_FramesLeft = kAssertFrames;
            m_BannerCountdown = 0;
            Enabled = true;

            // Enforce immediately at first tick and push our banner once at start.
            ForceEnableIfNeeded("OnGameLoadingComplete");
            Mod.ReapplyBannerForActiveLocale();

#if DEBUG
            Mod.Log.Info($"Assert window started: {kAssertFrames} frames.");
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

            // Re-apply the banner at the chosen frame cadence (idempotent & cheap)
            if (--m_BannerCountdown <= 0)
            {
                Mod.ReapplyBannerForActiveLocale();
                m_BannerCountdown = kBannerReapplyEveryFrames;
            }

            // Advance the window
            m_FramesLeft--;

#if DEBUG
            // Every ~60 frames, log a coarse heartbeat to avoid noise.
            if (m_FramesLeft % 60 == 0)
            {
                var flag = (PlatformManager.instance?.achievementsEnabled == true) ? "TRUE" : "FALSE";
                Mod.Log.Info($"Asserting… framesLeft={m_FramesLeft}, achievementsEnabled={flag}");
            }
#endif
        }

        private static bool ForceEnableIfNeeded(string source)
        {
            var pm = PlatformManager.instance;
            if (pm == null)
            {
#if DEBUG
                Mod.Log.Info($"{source}: PlatformManager.instance is null; skip");
#endif
                return false;
            }

            if (!pm.achievementsEnabled)
            {
                // KEEP these Release logs (proof for players)
                Mod.Log.Info($"{source}: ATTN: detected game flipped achievementsEnabled == FALSE. Forcing TRUE now");
                pm.achievementsEnabled = true;
                Mod.Log.Info($"{source}: achievementsEnabled is now TRUE.");
                return true;
            }

            return false;
        }
    }
}
