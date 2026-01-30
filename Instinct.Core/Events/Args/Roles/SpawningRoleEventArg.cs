using Instinct.Core.Features.RoleSystem.BaseClass.Role;

namespace Instinct.Core.Events.Args.Roles {
    public class SpawningRoleEventArg {
        public SpawningRoleEventArg(BaseCustomRole baseCustomRole) {
            this.BaseCustomRole = baseCustomRole;
            this.IsAllowed = true;
        }
        public BaseCustomRole BaseCustomRole { get; set; }
        public bool IsAllowed { get; set; } = true;
    }
}
