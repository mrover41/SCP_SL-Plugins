using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using LabApi.API.Features;
using LabApi.Events.EventArgs.Player;
using UnityEngine;

namespace Corwarx_Roles.Roles.InstanceComponents {
    public class MedicRoleInstanceComponent : RoleInstanceComponentBase {
        public MedicRoleInstanceComponent(RoleBase role, Player player) : base(role, player) {
        }

        public override void OnAdd() {
            LabApi.Events.Handlers.Player.UsedItem += OnUsingItem;
            base.OnAdd();
        }

        public override void OnRemove() {
            LabApi.Events.Handlers.Player.UsedItem -= OnUsingItem;
            base.OnRemove();
        }

        private void OnUsingItem(UsedItemEventArgs ev) {
            if (ev.Player == Player && ev.Item.Type == ItemType.Medkit) {
                if (Physics.Raycast(ev.Player.CameraTransform.position + ev.Player.CameraTransform.forward * 0.5f,
                        ev.Player.CameraTransform.forward, out var hit)) {
                    Player target = Player.Get(hit.collider.gameObject);
                    if (target != null && target.Role.Team == ev.Player.Role.Team) {
                        target.Heal(15);
                    }
                }
            }
        }
    }
}