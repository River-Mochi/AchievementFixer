using Colossal.PSI.Common;              // PlatformManager
using Colossal.Serialization.Entities;  // Purpose enum
using Game;                             // GameSystemBase, GameMode
using Unity.Entities;                   // WorldSystemFilter

namespace AchievementFixer
{
    /// <summary>
    /// Keeps achievements enabled after each load with a short assert window.
    /// </summary>
    [WorldSystemFilter(WorldSystemFilterFlags.ClientSimulation)]    //only run this system in the actual gameplay
    public partial class AchievementFixerSystem : GameSystemBase
    {

        private int m_FramesLeft;

        // Assert window: after each load, for a short time, keep  achievementsEnabled = true.
        private const int kAssertFrames = 300;      // 300 frames = (~5s at 60 fps)

        protected override void OnCreate()
        {
            base.OnCreate();
            m_FramesLeft = 0;
            Mod.Log.Info("AchievementFixerSystem created");
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            // Start a new assert window at load-complete
            m_FramesLeft = kAssertFrames;

            ForceEnableIfNeeded("OnGameLoadingComplete");
#if DEBUG
            Mod.Log.Info($"Assert window started: {kAssertFrames} frames.");
#endif
        }

        protected override void OnUpdate()
        {
            if (m_FramesLeft <= 0)
                return;

            // If game flips FALSE anytime inside this window, flip it back to TRUE.
            ForceEnableIfNeeded("OnUpdate");

            m_FramesLeft--;     // Tick down the window; post decrement -1

#if DEBUG
    if (m_FramesLeft % 60 == 0)
        Mod.Log.Info($"Asserting… {m_FramesLeft} frames left");
#endif
        }


        private static bool ForceEnableIfNeeded(string source)
        {
            var pm = PlatformManager.instance;
            if (pm == null)
            {
                Mod.Log.Info($"{source}: PlatformManager.instance == null; skip");
                return false;
            }

            if (!pm.achievementsEnabled)
            {
                Mod.Log.Info($"{source}: ATTENTION: detected game flipped achievementsEnabled == FALSE. Forcing TRUE.");
                pm.achievementsEnabled = true;
                return true;
            }

            return false;
        }
    }
}
