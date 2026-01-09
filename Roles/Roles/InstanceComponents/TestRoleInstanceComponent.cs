using Corwarx_Project.Features.RoleSystem.BaseClass;
using Exiled.API.Features;

namespace Corwarx_Roles.Roles.InstanceComponents {
    public class TestRoleInstanceComponent : RoleInstanceComponentBase {
        public TestRoleInstanceComponent(RoleBase role, Player player) : base(role, player) {
        }

        public override void OnAdd() {
            Log.Info("AAAAAAAAAAa");
            base.OnAdd();
        }
    }
}