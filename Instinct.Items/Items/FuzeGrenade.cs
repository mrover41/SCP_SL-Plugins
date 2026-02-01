using MEC;
using System.Collections.Generic;
using System.Linq;
using Instinct.CustomItems;
using Instinct.CustomItems.Items;
using InventorySystem.Items.Usables.Scp244;
using InventorySystem.Items.Usables.Scp244.Hypothermia;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.Arguments.ServerEvents;
using LabApi.Events.Handlers;
using LabApi.Features.Wrappers;
using PlayerRoles;
using UnityEngine;

namespace Instinct.Items.Items {
    public class FuzeGrenade : CustomThrowableBase {
        public float Duration { get; set; } = 10f;
        public override ItemType Type { get; } = ItemType.GrenadeFlash;
        //public override float FuseTime { get; set; } = 10; // TODO: Make this
        public override float Weight { get; } = 1;
        public override string CustomItemName { get; set; } = "Граната";
        public override string Description { get; set; } = "Дымовая граната";
        //public override uint Id { get; set; } = 140;
        //public override bool ExplodeOnCollision { get; set; } = true; //TODO: Make this
        //public override SpawnProperties SpawnProperties { get; set; } = null;
        private List<Vector3> _grenades = new List<Vector3>();

        public override void OnRegistered()
        {
            PlayerEvents.Spawned += Spawner;
            PlayerEvents.Hurting += Hut;
           // ServerEvents.ExplosionSpawning += OnExploding;
            
            base.OnRegistered();
        }

        public override void OnUnRegistered()
        {
            PlayerEvents.Spawned -= Spawner;
            PlayerEvents.Hurting -= Hut;
            
            base.OnUnRegistered();
        }

        public override void OnChanged(Player player, Item oldItem, Item newItem, bool changedToThisItem)
        {
            if (!changedToThisItem) return;
            player.SendBroadcast($"<b><color=#FCF7D9>Вы подобрали</color> <color=#A9BCD4>Дымовую гранату</color></b>", 4);
            
            base.OnChanged(player, oldItem, newItem, changedToThisItem);
        }

        //Кто эту х.ню написал, потом исправлю, наверное
        private void Spawner(PlayerSpawnedEventArgs ev) { 
            if (ev.Player.Role == RoleTypeId.NtfSergeant) {
                CustomItemBase customitem = CustomItems.CustomItems.CreateItem<FuzeGrenade>();
                if (customitem != null)
                    CustomItems.CustomItems.AddCustomItem(customitem, ev.Player);
            }
        }
        

        private void Hut(PlayerHurtingEventArgs ev) { 
            if (ev.Player.HasEffect<Hypothermia>()) {
                foreach (Vector3 vector in this._grenades) { 
                    if (Vector3.Distance(ev.Player.Position, vector) <= 5) {
                        ev.IsAllowed = false;
                    }
                }
            }
        }

        public override void OnThrowingProjectile(Player player, ThrowableItem throwableItem, InventorySystem.Items.ThrowableProjectiles.ThrowableItem.ProjectileSettings settings, bool isFullForce,
            bool isAllowed)
        {
            Scp244Pickup fog = (Scp244Pickup)Pickup.Create(ItemType.SCP244a, settings.RelativePosition);
            //fog.Scale = Vector3.one * 0.01f;
            fog?.Rotation = Quaternion.Euler(0, 0, 90);
            //fog.ActivationDot = 0;
            fog?.Spawn();
            this._grenades.Add(fog!.Position);
            Timing.CallDelayed(10, () => {fog.State = Scp244State.Destroyed; });
            Timing.CallDelayed(10, () => { this._grenades.Remove(fog.Position); });
            isAllowed = false;

            if (player.CurrentItem.IsCustom())
                player.CurrentItem?.DropItem();
            
            base.OnThrowingProjectile(player, throwableItem, settings, isFullForce, isAllowed);
        }
    }
}