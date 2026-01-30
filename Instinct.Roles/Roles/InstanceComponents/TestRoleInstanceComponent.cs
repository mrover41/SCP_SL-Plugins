namespace Corwarx_Project.Roles.InstanceComponents {
    public class TestRoleInstanceComponent : RoleInstanceComponentBase {
        public TestRoleInstanceComponent(RoleBase role, Player player) : base(role, player) {
        }

        public override void OnAdd() {
            LabApi.Events.Handlers.Player.Hurt += OnHurt;
            base.OnAdd();
        }

        public override void OnRemove() {
            LabApi.Events.Handlers.Player.Hurt -= OnHurt;
            base.OnRemove();
        }

        private void OnHurt(HurtEventArgs ev) {
            if (ev.Player != Player) return;

            ev.DamageHandler.Damage *= 0.7f;
        }
    }
}