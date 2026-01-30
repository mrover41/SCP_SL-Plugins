using System.Collections.Generic;
using UnityEngine;

namespace Instinct.Items.Items {
    [LabApi.API.Features.Attributes.CustomItem(ItemType.GunCOM18)]
    public class ItemD : CustomWeapon {
        public override string Description { get; set; } = "Дублює предмети";
        public override float Weight { get; set; } = 2f;
        public override string Name { get; set; } = "Дублiкатор";
        public override uint Id { get; set; } = 122;
        public override ItemType Type { get; set; } = ItemType.GunCOM18;
        public override float Damage { get; set; } = 0;
        public override byte ClipSize { get; set; } = 3;

        protected override void SubscribeEvents() {
            base.SubscribeEvents();
            LabApi.Events.Handlers.Player.Shot += Wapon;
            LabApi.Events.Handlers.Player.ChangedItem += Select_Info;
            LabApi.Events.Handlers.Player.ReloadingWeapon += Reload;
        }

        protected override void UnsubscribeEvents() {
            LabApi.Events.Handlers.Player.Shot -= Wapon;
            LabApi.Events.Handlers.Player.ChangedItem -= Select_Info;
            LabApi.Events.Handlers.Player.ReloadingWeapon -= Reload;
            base.UnsubscribeEvents();
        }

        private void Select_Info(ChangedItemEventArgs ev) { 
            if (Check(ev.Item)) {
                ev.Player.Broadcast(4, "<b><color=#FCF7D9>Ви підібрали</color> <color=#00ADAD>Дублікатор</color></b>");
            }
        }

        private void Wapon(ShotEventArgs ev) {
            if (!Check(ev.Item)) {
                return;
            } if (ev.Firearm.TotalAmmo <= 0) { 
                ev.Player.RemoveItem(ev.Item);
                Map.ExplodeEffect(ev.Player.Position, ProjectileType.FragGrenade);
            } if (ev.Target != null) {
                ev.CanHurt = false;
                Hitmarker.SendHitmarkerDirectly(ev.Player.ReferenceHub, 1.5f);
                Ragdoll.CreateAndSpawn(ev.Target.Role.Type, ev.Target.Nickname, "Душа покинула его убегая от парадоксов", ev.Target.Transform.position, ev.Target.Transform.rotation);
            } if (Physics.Linecast(ev.Player.CameraTransform.position, ev.RaycastHit.point, out RaycastHit raycastHit)) {
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