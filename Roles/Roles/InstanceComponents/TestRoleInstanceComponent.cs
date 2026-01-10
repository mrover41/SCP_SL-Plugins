using Corwarx_Project.Features.RoleSystem.BaseClass;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Exiled.API.Features;
using UnityEngine;

namespace Corwarx_Roles.Roles.InstanceComponents {
    public class TestRoleInstanceComponent : RoleInstanceComponentBase {
        public TestRoleInstanceComponent(RoleBase role, Player player) : base(role, player) {
        }

        public override void OnAdd() {
            Player.Scale = Vector3.one * 0.1f;
            base.OnAdd();
        }

        public override void OnRemove() {
            Player.Scale = Vector3.one;
            base.OnRemove();
        }
    }
}