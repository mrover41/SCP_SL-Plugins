using System;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using Instinct.Core.Modules;

namespace Instinct.Roles {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }

        public override string Name => "Instinct.Roles";
        public override string Description => "хз, не придумал";
        public override string Author => "Mr_Over41 && everyofflineuser && wexels.dev";


        public override Version Version => new Version("1.0.0");

        public override Version RequiredApiVersion => LabApiProperties.CurrentVersion;


        public Loader() => Instance = this;
        
        public override void Enable() {
            RoleManager.RegisterAllRoles(System.Reflection.Assembly.GetExecutingAssembly());
        }
        
        
        override public void Disable() {
            Instance = null;
        }

    }
}
