namespace Instinct.Core.Events.Args.Roles {
    public class SpawningAllRolesEventArg {
        public SpawningAllRolesEventArg() {
            this.IsAllowed = true;
        }
        public bool IsAllowed { get; set; }
    }
}
