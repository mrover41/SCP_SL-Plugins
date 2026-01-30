namespace Instinct.Core.Events.Args.Plugin {
    public class LoadPluginEventArgs {
        public LoadPluginEventArgs(string name) {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
