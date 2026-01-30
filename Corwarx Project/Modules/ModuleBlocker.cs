/*using Instinct.Core;
using Instinct.Core.Features.ModuleSystem.Atributies;
using Instinct.Events.Args.Modules;
using Instinct.Features.ModuleSystem.BaseClass;
using LabApi.API.Features;

namespace Instinct.Modules {
    [LoadModule]
    internal class ModuleBlocker : ModuleBase {
        public override string Name => "Module Blocker";

        public override void OnEnable() {
            Instinct.Events.Handles.Module.EnableModuleEvent += OnModuleEnable;
            base.OnEnable();
        }

        public override void OnDisable() {
            Instinct.Events.Handles.Module.EnableModuleEvent -= OnModuleEnable;
            base.OnDisable();
        }

        private void OnModuleEnable(EnableModuleEventArg ev) {
            if (!Loader.Instance.Config.BlackListModules.Contains(ev.Module.Name)) return;
            if (!Loader.Instance.Config.BlackListModulesNameof.Contains(nameof(ev.Module))) return;
            ev.IsAllowed = false;

            Logger.Debug($"Module {ev.Module.Name} is blocked from being enabled by the Module System.");
        }
    }
}
*/