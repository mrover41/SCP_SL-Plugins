using Corwarx_Project.Events.Args.Plugin;
using Corwarx_Project.Features.ModuleSystem.Manager;
using LabApi.API.Features;
using System.Reflection;

namespace UI {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }
        public Loader() => Instance = this;
        public override void OnEnabled() {
            Corwarx_Project.Events.Handles.Plugin.OnLoadPlugin(new LoadPluginEventArgs("UI"));

            ModuleManager.RegisterModules(Assembly.GetExecutingAssembly());

            base.OnEnabled();
        }

        public override void OnDisabled() {
            base.OnDisabled();
        }
    }
}
