using Corwarx_Project.Features.RoleSystem.BaseClass;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using UnityEngine;

namespace Corwarx_Roles.Roles.InstanceComponents {
    public class TestRoleInstanceComponent : RoleInstanceComponentBase {
        public TestRoleInstanceComponent(RoleBase role, Player player) : base(role, player) {
        }

        public override void OnAdd() {
            Exiled.Events.Handlers.Player.Hurt += OnHurt;
            base.OnAdd();
        }

        public override void OnRemove() {
            Exiled.Events.Handlers.Player.Hurt -= OnHurt;
            base.OnRemove();
        }

        private void OnHurt(HurtEventArgs ev) {
            if (ev.Player != Player) return;

            ev.DamageHandler.Damage *= 0.7f;
        }
    }
}