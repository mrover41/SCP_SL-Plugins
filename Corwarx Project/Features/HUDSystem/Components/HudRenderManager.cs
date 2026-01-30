using Instinct.Core.Features.HUDSystem.BaseClass;
using MEC;

namespace Instinct.Core.Features.HUDSystem.Components {
    public static class HudLoader {
        public static void RegisterHUD(HudUpdater hudUpdater) { 
            hudUpdater.OnEnable();
            Timing.RunCoroutine(enumerator(hudUpdater));
        }

        private static IEnumerator<float> enumerator(HudUpdater hudUpdater) { 
            for (; ; ) { 
                hudUpdater.Tick();
                yield return Timing.WaitForOneFrame; 
            } 
        }
    }
}
