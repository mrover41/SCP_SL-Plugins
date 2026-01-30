using MEC;
using System.Collections.Generic;
using UnityEngine;

namespace Instinct.Items.Items {
    [LabApi.API.Features.Attributes.CustomItem(ItemType.GunCOM15)]
    public class Trangulizer : CustomWeapon {
        public override string Description { get; set; } = "Обезвреживает об`екты";
        public override float Weight { get; set; } = 2f;
        public override string Name { get; set; } = "Транквилизатор";
        public override uint Id { get; set; } = 120;
        public override ItemType Type { get; set; } = ItemType.GunCOM15;
        public override float Damage { get; set; } = 0;
        public override byte ClipSize { get; set; } = 7;

        protected override void SubscribeEvents() {
            base.SubscribeEvents();
            LabApi.Events.Handlers.Player.Shot += Sh;
            LabApi.Events.Handlers.Player.ChangedItem += Select_Info;
            LabApi.Events.Handlers.Player.ReloadingWeapon += Reload;
        }
    
        protected override void UnsubscribeEvents() {
            LabApi.Events.Handlers.Player.Shot -= Sh;
            LabApi.Events.Handlers.Player.ChangedItem -= Select_Info;
            LabApi.Events.Handlers.Player.ReloadingWeapon -= Reload;
            base.UnsubscribeEvents();
        }

        private void Select_Info(ChangedItemEventArgs ev) { 
            if (Check(ev.Item)) {
                ev.Player.Broadcast(4, "<b><color=#FCF7D9>Вы подобрали</color> <color=#DB633C>Транквилизатор</color></b>");
            }
        }

        private void Sh(ShotEventArgs ev) {
            if (ev.Target == null) return;
            if (!Check(ev.Item)) return;
            if (ev.Target.IsGodModeEnabled) return;

            if (ev.Target.IsScp) {
                this.SCPEffect(ev);
            } else {
                Timing.RunCoroutine(this.Delay(ev.Target));
            }
            ev.CanHurt = false;
        }

        private IEnumerator<float> Delay(LabApi.API.Features.Player player) {
            player.CurrentItem = null;
            player.Inventory.enabled = false;
            player.Scale = new Vector3(0.5f, 0.5f, 0.5f);
            player.IsGodModeEnabled = true;
            Ragdoll rg = Ragdoll.CreateAndSpawn(player.Role.Type, player.Nickname, "Немного помялся", player.Position, player.Rotation);
            player.EnableEffect(EffectType.Deafened);
            player.EnableEffect(EffectType.Invisible);
            player.EnableEffect(EffectType.Ensnared);
            //player.EnableEffect(EffectType.Flashed);
            player.EnableEffect(EffectType.Flashed, 255);
            yield return Timing.WaitForSeconds(10);
            player.DisableEffect(EffectType.Flashed);
            player.DisableEffect(EffectType.Deafened);
            player.DisableEffect(EffectType.Invisible);
            player.DisableEffect(EffectType.Ensnared);
            //player.DisableEffect(EffectType.Flashed);
            player.Scale = new Vector3(1, 1, 1);
            player.Inventory.enabled = true;
            player.IsGodModeEnabled = false;
            rg.Destroy();
        }

        private void SCPEffect(ShotEventArgs ev) {
            switch (ev.Target.Role.Type) {
                case RoleTypeId.Scp173:
                    break;
                case RoleTypeId.Scp106:
                    Hitmarker.SendHitmarkerDirectly(ev.Player.ReferenceHub, 1.5f);
                    ev.Target.EnableEffect(EffectType.Slowness, 25, 10);
                    ev.Target.EnableEffect(EffectType.Blurred, 255, 10);
                    break;
                case RoleTypeId.Scp049:
                    Hitmarker.SendHitmarkerDirectly(ev.Player.ReferenceHub, 1.5f);
                    ev.Target.EnableEffect(EffectType.SinkHole, 10, 10);
                    ev.Target.EnableEffect(EffectType.AmnesiaVision, 255, 10);
                    ev.Target.EnableEffect(EffectType.Blurred, 255, 10);
                    break;
                case RoleTypeId.Scp096:
                    Hitmarker.SendHitmarkerDirectly(ev.Player.ReferenceHub, 1.5f);
                    ev.Target.EnableEffect(EffectType.SinkHole, 10, 10);
                    ev.Target.EnableEffect(EffectType.Blurred, 255, 10);
                    break;
                case RoleTypeId.Scp3114:
                    Hitmarker.SendHitmarkerDirectly(ev.Player.ReferenceHub, 1.5f);
                    ev.Target.EnableEffect(EffectType.Flashed, 255, 10);
                    ev.Target.EnableEffect(EffectType.Deafened, 255, 10);
                    ev.Target.EnableEffect(EffectType.SinkHole, 10, 10);
                    break;
                case RoleTypeId.Scp939:
                    Hitmarker.SendHitmarkerDirectly(ev.Player.ReferenceHub, 1.5f);
                    ev.Target.EnableEffect(EffectType.Slowness, 40, 10);
                    ev.Target.EnableEffect(EffectType.AmnesiaVision, 200, 10);
                    break;
            }
        }

        private void Reload(ReloadingWeaponEventArgs ev) { 
            if (Check(ev.Item)) {
                ev.IsAllowed = false;
            }
        }

        public override SpawnProperties SpawnProperties { get; set; } = null;

    }
}
