using Instinct.Core.Extensions;
using Instinct.Core.Features.RoleSystem.BaseClass.Role;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Wrappers;
using PlayerRoles;
using UnityEngine;

namespace Instinct.Roles.Roles.InstanceComponents {
    public class MedicRoleInstanceComponent : RoleInstanceComponentBase {
        public MedicRoleInstanceComponent(CustomRoleBase customRoleBase, Player player) : base(customRoleBase, player) {
        }

        public override void OnAdd() {
            LabApi.Events.Handlers.PlayerEvents.UsedItem += OnUsingItem;
            base.OnAdd();
        }

        public override void OnRemove() {
            LabApi.Events.Handlers.PlayerEvents.UsedItem -= OnUsingItem;
            base.OnRemove();
        }

        private void OnUsingItem(PlayerUsedItemEventArgs ev) {
            if (ev.Player == this.Player && ev.Item.Type == ItemType.Medkit) {

                Player target = ev.Player.GetFromView(5);
                if (target != null && target.Role.GetTeam() == ev.Player.Role.GetTeam()) {
                    target.Heal(15);
                }
                
            }
        }
    }
}