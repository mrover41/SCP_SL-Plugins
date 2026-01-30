using Instinct.Core.Features.ModuleSystem.BaseClass;

namespace Instinct.Core.Events.Args.Modules {
    public class EnabledModuleEventArg {
        public EnabledModuleEventArg(ModuleBase module) {
            this.Module = module;
        }
        public ModuleBase Module { get; private set; }
    }
}
