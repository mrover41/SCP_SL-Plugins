using System;
using Instinct.Core.Features.ModuleSystem.Manager;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;

namespace Instinct.Items {
    public class Loader : Plugin<Config> {
        public override string Name => "Instinct.Items";
        public override string Description => "хз, не придумал";
        public override string Author => "Mr_Over41 && everyofflineuser && wexels.dev";

        public override Version Version => new Version("2.0.0");
        public override Version RequiredApiVersion => LabApiProperties.CurrentVersion;
        public static Loader Instance { get; private set; }
        public Loader() => Instance = this;

        public override void Enable() {
            //Plugin.OnLoadPlugin(new Instinct.Core.Events.Args.Plugin.LoadPluginEventArgs("Instinct.Items"));
            //Trangulizer.RegisterItems();

            ModuleManager.RegisterModules(System.Reflection.Assembly.GetExecutingAssembly());
        }

        public override void Disable() {
            //Trangulizer.UnregisterItems();
        }
    }
}
