using Instinct.Core.Features.RoleSystem.BaseClass.Role;
using UnityEngine;

namespace Instinct.Roles.Roles.InstanceComponents {
    public class MedicRoleInstanceComponent : RoleInstanceComponentBase {
        public MedicRoleInstanceComponent(BaseCustomRole baseCustomRole, Player player) : base(baseCustomRole, player) {
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
            if (ev.Player == this.Player && ev.Item.Type == ItemType.Medkit) {
                if (Physics.Raycast(ev.Player.CameraTransform.position + ev.Player.CameraTransform.forward * 0.5f,
                        ev.Player.CameraTransform.forward, out RaycastHit hit)) {
                    Player target = this.Player.Get(hit.collider.gameObject);
                    if (target != null && target.Role.Team == ev.Player.Role.Team) {
                        target.Heal(15);
                    }
                }
            }
        }
    }
}