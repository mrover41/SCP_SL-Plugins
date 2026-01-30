using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace Instinct.Items.Items {
    [CustomItem(ItemType.GrenadeFlash)]
    public class FuzeGranate : CustomGrenade {
        public float Duration { get; set; } = 10f;
        public override ItemType Type { get; set; } = ItemType.GrenadeFlash;
        public override float FuseTime { get; set; } = 10;
        public override float Weight { get; set; } = 1;
        public override string Description { get; set; } = "Димова граната";
        public override uint Id { get; set; } = 140;
        public override string Name { get; set; } = "Граната";
        public override bool ExplodeOnCollision { get; set; } = true;
        public override SpawnProperties SpawnProperties { get; set; } = null;
        private List<Vector3> Granates = new List<Vector3>();
        protected override void SubscribeEvents() {
            LabApi.Events.Handlers.Player.Hurting += Hut;
            LabApi.Events.Handlers.Player.Spawned += Spawner;
            LabApi.Events.Handlers.Player.ChangedItem += Select_Info;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents() {
            LabApi.Events.Handlers.Player.Hurting -= Hut;
            LabApi.Events.Handlers.Player.Spawned -= Spawner;
            LabApi.Events.Handlers.Player.ChangedItem -= Select_Info;
            base.UnsubscribeEvents();
        }

        private void Select_Info(ChangedItemEventArgs ev) { 
            if (Check(ev.Item)) {
                ev.Player.Broadcast(4, "<b><color=#FCF7D9>Ви підібрали</color> <color=#A9BCD4>Димову гранату</color></b>");
            }
        }
        
        //Кто эту х.ню написал, потом исправлю, наверное
        private void Spawner(SpawnedEventArgs ev) { 
            if (ev.Player.Role.Type == RoleTypeId.NtfSergeant) {
                CustomItem.TryGive(ev.Player, 140, false);
            }
        }

        private void Hut(HurtingEventArgs ev) { 
            if (ev.DamageHandler.Type == LabApi.API.Enums.DamageType.Hypothermia) {
                foreach (Vector3 vector in this.Granates) { 
                    if (Vector3.Distance(ev.Player.Position, vector) <= 5) {
                        ev.IsAllowed = false;
                    }
                }
            }
        }
        protected override void OnExploding(ExplodingGrenadeEventArgs ev) {
            Scp244Pickup fog = Pickup.Create(ItemType.SCP244a).As<Scp244Pickup>();
            fog.Scale = Vector3.one * 0.01f;
            fog.Rotation = Quaternion.Euler(0, 0, 90);
            fog.ActivationDot = 0;
            fog.Spawn(ev.Position, fog.Rotation);
            this.Granates.Add(fog.Position);
            Timing.CallDelayed(10, () => {fog.State = Scp244State.Destroyed; });
            Timing.CallDelayed(10, () => { this.Granates.Remove(fog.Position); });
            ev.IsAllowed = false;
            base.OnExploding(ev);
        }
    }
}