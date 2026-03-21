using System.Linq;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using UnityEngine;

namespace Corwarx_Roles.Roles.InstanceComponents {
    public class SCP343RoleInstanceComponent : RoleInstanceComponentBase {
        public SCP343RoleInstanceComponent(RoleBase role, Player player) : base(role, player) {
        }

        private CoroutineHandle handle;
        
        public override void OnAdd() {
            Exiled.Events.Handlers.Player.DroppingItem += OnDroppingItem;
            Exiled.Events.Handlers.Player.UsingItem += OnUsingItem;
            Exiled.Events.Handlers.Player.PickingUpItem += OnPkItem;
            Exiled.Events.Handlers.Player.Handcuffing += OnCuffingPlayer;
            base.OnAdd();
        }

        public override void OnRemove() {
            Exiled.Events.Handlers.Player.DroppingItem -= OnDroppingItem;
            Exiled.Events.Handlers.Player.UsingItem -= OnUsingItem;
            Exiled.Events.Handlers.Player.PickingUpItem -= OnPkItem;
            Exiled.Events.Handlers.Player.Handcuffing -= OnCuffingPlayer;
            
            if (handle.IsValid) Timing.KillCoroutines(handle);
            base.OnRemove();
        }

        private void OnDroppingItem(DroppingItemEventArgs ev) {
            if (ev.Player == Player) ev.IsAllowed = false;
        }

        private void OnPkItem(PickingUpItemEventArgs ev) {
           if (ev.Player == Player) ev.IsAllowed = false; 
        }

        private void OnCuffingPlayer(HandcuffingEventArgs ev) {
            if (ev.Target == Player) ev.IsAllowed = false;
        }

        private void OnUsingItem(UsingItemEventArgs ev) {
            if (ev.Player != Player) return;
            switch (ev.Item.Type) {
                case ItemType.Medkit:
                    HealPlayers();
                    break;
            }
            ev.IsAllowed = false;
        }

        private void HealPlayers() {
            foreach (Player player in Player.List.Where(x => Vector3.Distance(Player.Position, x.Position) < 5)) {
                player.Heal(20);
            }
            Player.ClearInventory();
            handle = Timing.CallDelayed(20f, () => {Player.AddItem(ItemType.Medkit, 8);});
        }
    }
}