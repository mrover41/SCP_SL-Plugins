using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace Corwarx_Roles.Roles.InstanceComponents {
    public class SCP0762InstanceComponent : RoleInstanceComponentBase {
        public SCP0762InstanceComponent(RoleBase role, Player player) : base(role, player) {
        }

        public override void OnAdd() {
            Exiled.Events.Handlers.Player.DroppingItem += OnDropingItem;
            base.OnAdd();
        }

        public override void OnRemove() {
            Exiled.Events.Handlers.Player.DroppingItem -= OnDropingItem;
            base.OnRemove();
        }

        private void OnDropingItem(DroppingItemEventArgs ev) {
            if (ev.Player == Player) ev.IsAllowed = false;
        }
    }
}