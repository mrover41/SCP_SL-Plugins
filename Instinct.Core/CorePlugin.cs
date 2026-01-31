using HarmonyLib;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using System.Reflection;
using Instinct.Core.Features.ModuleSystem.Manager;

namespace Instinct.Core {
    public class CorePlugin : Plugin<Config> {
        private static Harmony? _harmony;
        
        public override string Name => "Instinct.Core";
        public override string Description => "хз, не придумал";
        public override string Author => "Mr_Over41 && everyofflineuser && wexels.dev";

        public override Version Version => new("2.0.0");
        public override Version RequiredApiVersion => LabApiProperties.CurrentVersion;
        
        public static CorePlugin? Instance { get; private set; }

        public override void Enable() {
            Instance = this;
            
            _harmony = new Harmony("today.glitching.instinct.core");
            _harmony.PatchAll();

            RegisterEvents(); 

            ModuleManager.RegisterModules(Assembly.GetExecutingAssembly());

            Logger.Info($"\n Plugin {this.Name} is running!\n Creator: {this.Author}");
            Logger.Info($"Plugin {this.Name} started");
        }

        public override void Disable() {
            _harmony?.UnpatchAll();
            ModuleManager.DisableAllModules();
            UnRegisterEvents();

            Instance = null;
        }
        
        private static void RegisterEvents() {
            EventHandler.RegisterEvents();
            LabApi.Events.Handlers.PlayerEvents.Joined += EventHandler.OnPlayerJoined;
        }

        private static void UnRegisterEvents() {
            EventHandler.UnRegisterEvents();
            LabApi.Events.Handlers.PlayerEvents.Joined -= EventHandler.OnPlayerJoined;
        }
    }
}
