using Corwarx_Project.Features.ModuleSystem.Manager;
using Exiled.API.Features;
using HarmonyLib;
using Plugin = Corwarx_Project.Events.Handles.Plugin;

namespace Gameplay {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }
        public Loader() => Instance = this;
        internal static Harmony _harmony { get; private set; } = new Harmony("com.corwarx.gameplay");
        public override void OnEnabled() {
            Plugin.OnLoadPlugin(new Corwarx_Project.Events.Args.Plugin.LoadPluginEventArgs("Gameplay"));
            _harmony.PatchAll();

            ModuleManager.RegisterModules(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnEnabled();
        }

        override public void OnDisabled() {
            _harmony.UnpatchAll();
            base.OnDisabled();
        }
    }
}
