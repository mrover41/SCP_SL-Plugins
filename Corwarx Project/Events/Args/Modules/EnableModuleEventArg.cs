using Instinct.Core.Features.ModuleSystem.BaseClass;

namespace Instinct.Core.Events.Args.Modules {
    public class EnableModuleEventArg {
        public EnableModuleEventArg(ModuleBase module) {
            this.Module = module;
            this.IsAllowed = true;
        }
        public ModuleBase Module { get; private set; }
        public bool IsAllowed { get; set; }
    }
}
