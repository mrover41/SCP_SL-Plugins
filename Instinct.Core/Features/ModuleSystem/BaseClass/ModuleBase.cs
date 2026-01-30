namespace Instinct.Core.Features.ModuleSystem.BaseClass {
    public abstract class ModuleBase {
        public string Name { get; }
        public virtual int Id { get; internal set; } = -1;
        public virtual string Description { get; } = "No description provided.";
        public bool IsEnabled { get; internal set; } = false;

        protected ModuleBase() {
            this.Name = this.GetType().Name;
        }
        
        public virtual void OnEnable() => Logger.Debug($"Module {this.Name} with ID {this.Id} enabled.");
        public virtual void OnDisable() => Logger.Debug($"Module {this.Name} with ID {this.Id} disabled.");
    }
}
