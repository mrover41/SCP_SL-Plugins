using Instinct.Core.Features.RoleSystem.BaseClass.Role;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Wrappers;
using PlayerStatsSystem;

namespace Instinct.Roles.Roles.InstanceComponents {
    public class TestRoleInstanceComponent : RoleInstanceComponentBase {
        public TestRoleInstanceComponent(CustomRoleBase role, Player player) : base(role, player) {
        }

        public override void OnAdd() {
            LabApi.Events.Handlers.PlayerEvents.Hurting += OnHurt;
            base.OnAdd();
        }

        public override void OnRemove() {
            LabApi.Events.Handlers.PlayerEvents.Hurting -= OnHurt;
            base.OnRemove();
        }

        private void OnHurt(PlayerHurtingEventArgs ev) {
            if (ev.Player != Player) return;
            
            ev.DamageHandler = new CustomReasonDamageHandler(ev.DamageHandler.DeathScreenText, 50);
        }
    }
}