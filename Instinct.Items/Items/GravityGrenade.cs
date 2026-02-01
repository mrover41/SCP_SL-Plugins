using LabApi.Features.Wrappers;
using MEC;
using UnityEngine;

namespace Instinct.Items.Items { 
        /*public class GravityGrenade : ThrowableItem {
        public float Duration { get; set; } = 10f;
        public override ItemType Type { get; set; } = ItemType.GrenadeHE;
        public override float FuseTime { get; set; } = 10;
        public override float Weight { get; set; } = 5;
        public override string Description { get; set; } = "r";
        public override uint Id { get; set; } = 200;
        public override string Name { get; set; } = "g";
        public override bool ExplodeOnCollision { get; set; } = false;
        public override Vector3 Scale { get; set; } = new Vector3(2, 5, 2);
        public override SpawnProperties SpawnProperties { get; set; } = null;
        protected override void SubscribeEvents() {
            LabApi.Events.Handlers.Player.ChangedItem += Select_Info;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents() {
            LabApi.Events.Handlers.Player.ChangedItem -= Select_Info;
            base.UnsubscribeEvents();
        }

        private void Select_Info(ChangedItemEventArgs ev) {
            if (Check(ev.Item)) {
                ev.Player.Broadcast(4, "<b><color=#FCF7D9>Ви підібрали</color> <color=#A9BCD4>😣</color></b>");
            }
        }
        protected override void OnExploding(ExplodingGrenadeEventArgs ev) {
            foreach (Pickup pickup in Pickup.List) { 
                pickup.PhysicsModule.Rb.useGravity = false;
                pickup.PhysicsModule.Rb.AddForce(0, 5, 0);
            }
            Timing.CallDelayed(60, () => {
                foreach (Pickup pickup in Pickup.List) {
                    pickup.PhysicsModule.Rb.useGravity = true;
                }
            });
            ev.IsAllowed = false;
            base.OnExploding(ev);
        }
    }*/
}