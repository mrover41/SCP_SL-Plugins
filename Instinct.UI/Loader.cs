using System.Reflection;

namespace Instinct.UI {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }
        public Loader() => Instance = this;
        public override void OnEnabled() {
            Corwarx_Project.Events.Handles.Plugin.OnLoadPlugin(new LoadPluginEventArgs("Instinct.UI"));

            ModuleManager.RegisterModules(Assembly.GetExecutingAssembly());

            base.OnEnabled();
        }

        public override void OnDisabled() {
            base.OnDisabled();
        }
    }
}
