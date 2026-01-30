using MEC;
using System.Collections.Generic;

namespace Instinct.Items.Items {
    [CustomItem(ItemType.Adrenaline)]
    public class SCP420J : CustomItem {
        public override string Description { get; set; } = ";)";
        public override float Weight { get; set; } = 2f;
        public override string Name { get; set; } = "SCP-420-J";
        public override uint Id { get; set; } = 124;
        public override ItemType Type { get; set; } = ItemType.Adrenaline;
        //public override SpawnProperties SpawnProperties { get; set; } = null;

        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties() {
            Limit = 10,
            DynamicSpawnPoints = new List<DynamicSpawnPoint> {
            new DynamicSpawnPoint() {
                Location = SpawnLocationType.Inside173Armory,
                Chance = 100
            }
        },
            StaticSpawnPoints = new List<StaticSpawnPoint> {
            new StaticSpawnPoint() {
                Chance = 100,
                Position = new UnityEngine.Vector3(0, 1, 0), Name = "SCP-420-J"
            }
        }
        };

        private List<LabApi.API.Features.Player> playersList = new List<LabApi.API.Features.Player>();
        protected override void SubscribeEvents() {
            LabApi.Events.Handlers.Player.UsingItemCompleted += OnUsed;
            LabApi.Events.Handlers.Player.Hurting += Damage;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents() {
            LabApi.Events.Handlers.Player.UsingItemCompleted -= OnUsed;
            LabApi.Events.Handlers.Player.Hurting -= Damage;
            base.UnsubscribeEvents();
        }

        private void Damage(HurtingEventArgs ev) { 
            if (ev.DamageHandler.Type == DamageType.CardiacArrest) { 
                if (this.playersList.Contains(ev.Player)) {
                    ev.IsAllowed = false;
                }
            }
        }

        private void OnUsed(UsingItemCompletedEventArgs ev) {
            if (!Check(ev.Item)) {
                return;
            }

            this.playersList.Add(ev.Player);
            ev.Player.EnableEffect(EffectType.Slowness, 255, 10);
            ev.Player.EnableEffect(EffectType.CardiacArrest, 255, 10);
            ev.Player.EnableEffect(EffectType.FogControl, 255, 10);
            FogControl fogControl = ev.Player.GetEffect(EffectType.FogControl) as FogControl;
            fogControl.Duration = 10;
            EffectTypeExtension.SetFogType(fogControl, FogType.Decontamination);
            Timing.CallDelayed(10, () => { this.playersList.Remove(ev.Player); });
        }
    }
}