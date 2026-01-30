using Instinct.Core.Features.RoleSystem.BaseClass.Role;

namespace Instinct.Core.Events.Args.Roles {
    public class SpawnRoleEventArg {
        public SpawnRoleEventArg(CustomRoleBase customRoleBase) {
            this.CustomRoleBase = customRoleBase;
        }
        public CustomRoleBase CustomRoleBase { get; set; }
    }
}
