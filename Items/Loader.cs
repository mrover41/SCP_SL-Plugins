using Corwarx_Project.Events.Handles;
using Corwarx_Project.Features.ModuleSystem.Manager;
using LabApi.API.Features;
using Items.Items;

namespace Items {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }
        public Loader() => Instance = this;

        public override void OnEnabled() {
            Plugin.OnLoadPlugin(new Corwarx_Project.Events.Args.Plugin.LoadPluginEventArgs("Items"));
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
