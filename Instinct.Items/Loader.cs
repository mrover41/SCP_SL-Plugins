using Instinct.Items.Items;

namespace Instinct.Items {
    public class Loader : Plugin {
        public static Loader Instance { get; private set; }
        public Loader() => Instance = this;

        public override void OnEnabled() {
            Plugin.OnLoadPlugin(new Corwarx_Project.Events.Args.Plugin.LoadPluginEventArgs("Instinct.Items"));
            Trangulizer.RegisterItems();

            ModuleManager.RegisterModules(System.Reflection.Assembly.GetExecutingAssembly());

            base.OnEnabled();
        }

        public override void OnDisabled() {
            Trangulizer.UnregisterItems();
            base.OnDisabled();
        }
    }
}
