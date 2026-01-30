using Instinct.Core.Features.ModuleSystem.Attributies;
using Instinct.Core.Features.ModuleSystem.BaseClass;
using MEC;
using UnityEngine;

namespace Instinct.Core.Features.UpdateInjector {
    [LoadModule]
    internal class UpdateInitModule : ModuleBase {
        public override void OnEnable() {
            Timing.CallDelayed(1, () => {
                new GameObject("Updater").AddComponent<Updater>().Init();
            });
            base.OnEnable();
        }
    }
}
