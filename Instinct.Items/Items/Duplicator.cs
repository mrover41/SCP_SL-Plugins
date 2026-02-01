using System;
using System.Collections.Generic;
using Instinct.Core.Enums;
using Instinct.CustomItems.Items;
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
        public override short ClipSize { get; } = 3;

        public override void OnChanged(Player player, Item oldItem, Item newItem, bool changedToThisItem)
        {
            if (!changedToThisItem) return;
            
            player.SendBroadcast("<b><color=#FCF7D9>Вы подобрали</color> <color=#00ADAD>Дубликатор</color></b>", 4);
            
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
            } if (Physics.Raycast(player.Camera.position, player.Camera.forward, out RaycastHit raycastHit, 10f)) {
                if (raycastHit.transform.TryGetComponent(out ItemPickupBase itemPickupBase)) {
                    if (itemPickupBase.NetworkInfo.ItemId != ItemType.MicroHID && itemPickupBase.NetworkInfo.ItemId != ItemType.ParticleDisruptor && itemPickupBase.NetworkInfo.ItemId != ItemType.Jailbird) {
                        Pickup.Create(itemPickupBase.NetworkInfo.ItemId, raycastHit.point + Vector3.up * 0.5f, default);
                        Hitmarker.SendHitmarkerDirectly(player.ReferenceHub, 2);
                    } else {
                        if (player.Health > 30) {
                            player.Health -= 30;
                            player.SendBroadcast("<color=#FF5E3F> Ви не можете дублювати цей предмет </color>", 5);
                        } else
                        {
                            player.Damage(new DisruptorDamageHandler(null, Vector3.zero, -1));
                        }
                    }
                }
            }
            
            base.OnHurting(player, attacker, firearmDamage, isAllowedHelper);
        }

        public override void OnReloading(Player player, FirearmItem weapon, bool isAllowedHelper)
        {
            isAllowedHelper = false;
            player.RemoveItem(weapon);
            
            base.OnReloading(player, weapon, isAllowedHelper);
        }

        //public override SpawnProperties SpawnProperties { get; set; } = null;

        /*public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties() {
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
        };*/
    }
}