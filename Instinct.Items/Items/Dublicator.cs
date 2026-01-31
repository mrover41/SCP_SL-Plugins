using System;
using System.Collections.Generic;
using Cherry.Core.Enums;
using Cherry.CustomItems;
using Cherry.CustomItems.Items;
using InventorySystem.Items.Firearms.Modules;
using InventorySystem.Items.Pickups;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Wrappers;
using PlayerStatsSystem;
using UnityEngine;

namespace Instinct.Items.Items {
    public class ItemD : CustomFirearmBase
    {
        public override string CustomItemName { get; set; } = "Дубликатор";
        public override string Description { get; set; } = "Дублирует предметы";
        public override float Weight { get; } = 2f;
        public override ItemType Type { get; } = ItemType.GunCOM18;
        public override float Damage { get; } = 0;

        public override void OnRegistered() {
            base.OnRegistered();
            LabApi.Events.Handlers.PlayerEvents.ReloadingWeapon += Reload;
        }

        public override void OnUnRegistered() {
            LabApi.Events.Handlers.PlayerEvents.ReloadingWeapon -= Reload;
            base.OnUnRegistered();
        }

        public override void OnChanged(Player player, Item oldItem, Item newItem, bool changedToThisItem)
        {
            if (!changedToThisItem) return;
            
            player.SendBroadcast("<b><color=#FCF7D9>Ви підібрали</color> <color=#00ADAD>Дублікатор</color></b>", 4);
            
            base.OnChanged(player, oldItem, newItem, changedToThisItem);
        }

        public override void OnHurting(Player player, Player attacker, FirearmDamageHandler firearmDamage, bool isAllowedHelper)
        {
            if (firearmDamage.Firearm.GetTotalStoredAmmo() <= 0) { 
                player.RemoveItem(firearmDamage.Firearm);
                //Map.ExplodeEffect(ev.Player.Position, ProjectileType.FragGrenade);
            } if (player != null) {
                isAllowedHelper = false;
                Hitmarker.SendHitmarkerDirectly(attacker.ReferenceHub, 1.5f);
                Ragdoll.SpawnRagdoll(player, firearmDamage);
            } if (Physics.Linecast(player.Camera.position, ev.RaycastHit.point, out RaycastHit raycastHit)) {
                if (raycastHit.transform.TryGetComponent(out ItemPickupBase itemPickupBase)) {
                    if (itemPickupBase.NetworkInfo.ItemId != ItemType.MicroHID && itemPickupBase.NetworkInfo.ItemId != ItemType.ParticleDisruptor && itemPickupBase.NetworkInfo.ItemId != ItemType.Jailbird) {
                        Pickup.CreateAndSpawn(itemPickupBase.NetworkInfo.ItemId, ev.RaycastHit.point + Vector3.up * 0.5f, default);
                        Hitmarker.SendHitmarkerDirectly(ev.Player.ReferenceHub, 2);
                    } else {
                        if (ev.Player.Health > 30) {
                            ev.Player.Health -= 30;
                            ev.Player.Broadcast(5, "<color=#FF5E3F> Ви не можете дублювати цей предмет </color>");
                        } else {
                            ev.Player.Kill(DamageType.ParticleDisruptor);
                        }
                    }
                }
            }
            
            base.OnHurting(player, attacker, firearmDamage, isAllowedHelper);
        }

        private void Reload(ReloadingWeaponEventArgs ev) {
            if (Check(ev.Item)) {
                ev.IsAllowed = false;
                ev.Player.RemoveItem(ev.Item);
            }
        }

        //public override SpawnProperties SpawnProperties { get; set; } = null;

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties() {
            Limit = 1,
            DynamicSpawnPoints = new List<DynamicSpawnPoint> {
                new DynamicSpawnPoint()
                {
                    Location = SpawnLocationType.Inside914,
                    Chance = 100
                }
            },  
            StaticSpawnPoints = new List<StaticSpawnPoint> {
                new StaticSpawnPoint() {
                    Chance = 100,
                    Position = new Vector3(0f, 0f, 0f), Name = "Дубликатор"
                }
            }
        };
    }
}