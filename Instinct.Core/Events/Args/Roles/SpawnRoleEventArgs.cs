using Instinct.Core.Features.RoleSystem.BaseClass.Role;

namespace Instinct.Core.Events.Args.Roles {
    public class SpawnRoleEventArg {
        public SpawnRoleEventArg(BaseCustomRole baseCustomRole) {
            this.BaseCustomRole = baseCustomRole;
        }
        public BaseCustomRole BaseCustomRole { get; set; }
    }
}
