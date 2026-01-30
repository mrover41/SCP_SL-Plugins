namespace Instinct.Core.Events.Args.Plugin {
    public class UnLoadPluginEventArgs {
        public UnLoadPluginEventArgs(string name) {
            this.Name = name;
        }
        public string Name { get; set; }
    }
}
