using Corwarx_Project.Features.ModuleSystem.Manager;
using HarmonyLib;
using LabApi.Features;
using LabApi.Features.Console;
using LabApi.Loader.Features.Plugins;
using System;
using System.Reflection;
using Plugin = Corwarx_Project.Events.Handles.Plugin;

namespace Corwarx_Project.Core {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }
        public Loader() => Instance = this;
        public override string Name => typeof(Loader).Namespace;

        public override string Description => "Mega simga";

        public override string Author => "Mr_Over41 && everyofflineuser && wexels.dev";

        public override System.Version Version => new Version("1.0.0");

        public override System.Version RequiredApiVersion => LabApiProperties.CurrentVersion;


        internal static Harmony _harmony;
        internal EventHandler EventHandler = new EventHandler();

        public void OnEnabled() {
            _harmony = new Harmony("com.corwarx.core");
            _harmony.PatchAll();

            RegisterEvents(); 

            ModuleManager.RegisterModules(Assembly.GetExecutingAssembly());

            //RueI.RueIMain.EnsureInit();

            Logger.Info("\n Plugin CORWAX CORE is running!\n Creator: Mr_Over41\n Made for: Me :3\n oo-ee-oo");
            Logger.Info($"Plugin {Name} started");
        }

        public void OnDisabled() {
            _harmony.UnpatchAll();
            ModuleManager.DisableAllModules();
            UnRegisterEvents();
        }

        private void RegisterEvents() {
            EventHandler.RegisterEvents();
            LabApi.Events.Handlers.PlayerEvents.Joined += EventHandler.OnPlayerJoined;
        }

        private void UnRegisterEvents() {
            EventHandler.UnRegisterEvents();
            LabApi.Events.Handlers.PlayerEvents.Joined -= EventHandler.OnPlayerJoined;
        }

        public override void Enable()
        {
            throw new System.NotImplementedException();
        }

        public override void Disable()
        {
            throw new System.NotImplementedException();
        }

    }
}
