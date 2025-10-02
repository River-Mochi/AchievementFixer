namespace AchievementFixer
{
    using Colossal.PSI.Common;              // PlatformManager.instance (achievementsEnabled flag)
    using Colossal.Serialization.Entities;  // Purpose enum (load purpose)
    using Game;                             // GameSystemBase, GameMode (tells us Menu/Editor/Game)

    /// <summary>
    /// After a game load completes, keep achievements enabled for a short "assert" window,
    /// then go completely idle. System is disabled by default and only enabled while
    /// the assert window runs.
    ///
    /// Lifecycle:
    ///   - OnCreate():   start disabled (no per-frame updates scheduled)
    ///   - OnGameLoadingComplete(Game): open a 5s assert window and enable the system
    ///   - OnUpdate():   enforce achievementsEnabled during the window, then disable again
    /// </summary>
    public partial class AchievementFixerSystem : GameSystemBase
    {
        /// <summary>Countdown for the assert window (frames remaining).</summary>
        private int m_FramesLeft;

        /// <summary>Duration of the assert window (~5s at 60fps).</summary>
        private const int kAssertFrames = 300;

        /// <summary>
        /// Created once when the world/system is constructed.
        /// Start DISABLED so OnUpdate is not scheduled until we actually need it.
        /// </summary>
        protected override void OnCreate()
        {
            base.OnCreate();

            m_FramesLeft = 0;

            // IMPORTANT: When Enabled == false, the scheduler will NOT call OnUpdate each frame.
            // This keeps the mod at zero per-frame cost until it is explicitly enabled.
            Enabled = false;

            Mod.Log.Info("AchievementFixerSystem created (disabled)");
        }

        /// <summary>
        /// Called by the game when a load completes (new map, save, etc.).
        /// Only run the assert window for real gameplay.
        /// </summary>
        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            // Simple GameMode gate
            // Skip in Menu/Editor — keep the system disabled and do nothing.
            if (mode != GameMode.Game)
            {
                Enabled = false; // remain idle; OnUpdate will not be scheduled
                Mod.Log.Info($"OnGameLoadingComplete: mode={mode}; not gameplay → skipping.");
                return;
            }

            // Enter gameplay: open a new assert window and ENABLE the system so it runs per-frame.
            m_FramesLeft = kAssertFrames;
            Enabled = true; // scheduler will now call OnUpdate()

            // Immediately enforce once at load-complete
            ForceEnableIfNeeded("OnGameLoadingComplete");

#if DEBUG
            Mod.Log.Info($"Assert window started: {kAssertFrames} frames.");
#endif
        }

        /// <summary>
        /// Called each frame ONLY while Enabled == true.
        /// Enforce during the assert window, then disable to go idle again.
        /// </summary>
        protected override void OnUpdate()
        {
            // When the window finishes, go fully idle:
            //  - set Enabled = false so the scheduler stops calling OnUpdate
            //  - return immediately (no more work this frame)
            if (m_FramesLeft <= 0)
            {
                Enabled = false; // turn off per-frame updates until the next load event
                return;
            }

            // During the window: if the game flips FALSE, force it back to TRUE.
            ForceEnableIfNeeded("OnUpdate");

            // Decrement AFTER enforcing so we still act on the last frame.
            m_FramesLeft--;

#if DEBUG
            if (m_FramesLeft % 60 == 0)
                Mod.Log.Info($"Asserting… {m_FramesLeft} frames left");
#endif
        }

        /// <summary>
        /// If achievements were flipped off, turn them back on and log it.
        /// </summary>
        private static bool ForceEnableIfNeeded(string source)
        {
            var pm = PlatformManager.instance;
            if (pm == null)
            {
                Mod.Log.Info($"{source}: PlatformManager.instance == null; skip");
                return false;
            }

            /// Return true if we changed state.
            if (!pm.achievementsEnabled)
            {
                Mod.Log.Info($"{source}: ATTENTION: detected game flipped achievementsEnabled == FALSE. Forcing TRUE.");
                pm.achievementsEnabled = true;
                Mod.Log.Info($"{source}: achievementsEnabled is now TRUE.");
                return true;
            }

            return false;
        }
    }
}
