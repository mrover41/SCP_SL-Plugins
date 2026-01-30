using Instinct.Core.Features.RoleSystem.BaseClass.Role;

namespace Instinct.Core.Events.Args.Roles {
    public class SpawningRoleEventArg {
        public SpawningRoleEventArg(CustomRoleBase customRoleBase) {
            this.CustomRoleBase = customRoleBase;
            this.IsAllowed = true;
        }
        public CustomRoleBase CustomRoleBase { get; set; }
        public bool IsAllowed { get; set; } = true;
    }
}
