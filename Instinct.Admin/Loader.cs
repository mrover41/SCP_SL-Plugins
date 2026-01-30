using Instinct.Core.Features.ModuleSystem.Manager;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;

namespace Instinct.Admin {
    public class Loader : Plugin<Config> {
        public override string Name => "Instinct.Admin";
        public override string Description => "хз, не придумал";
        public override string Author => "Mr_Over41 && everyofflineuser && wexels.dev";

        public override Version Version => new(2, 0, 0);
        public override Version RequiredApiVersion => LabApiProperties.CurrentVersion;
        
        public static Loader? Instance { get; private set; }

        public override void Enable() {
            Instance = this;
            ModuleManager.RegisterModules(System.Reflection.Assembly.GetExecutingAssembly());
        }

        public override void Disable() {
            Instance = null;
        }
    }
}
