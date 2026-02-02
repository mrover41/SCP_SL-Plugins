using MEC;
using System.Collections.Generic;
using Instinct.Core.Enums;
using Instinct.Core.Extensions;
using Instinct.CustomItems.Items;
using LabApi.Features.Wrappers;
using PlayerRoles;
using PlayerStatsSystem;
using UnityEngine;

namespace Instinct.Items.Items {
    public class Trangulizer : CustomFirearmBase {
        public override string CustomItemName { get; set; } = "Транквилизатор";
        public override string Description { get; set; } = "Обезвреживает об`екты";
        public override float Weight => 2f;
        public override ItemType Type => ItemType.GunCOM15;
        public override float Damage => 0;

        public override void OnHurt(Player player, Player attacker, FirearmDamageHandler firearmDamage) {
            if (player.IsGodModeEnabled) return;

            if (player.IsSCP) {
                this.ScpEffect(player, attacker);
            } 
            else {
                Timing.RunCoroutine(this.Delay(player));
            }
            firearmDamage.Damage = 0;
        }

        public override void OnChanged(Player player, Item oldItem, Item newItem, bool changedToThisItem) {
            if (!changedToThisItem) return;
            player.ShowCoreHint($"<b><color=#FCF7D9>Вы подобрали</color> <color=#DB633C>Транквилизатор</color></b>", 4);
            
            base.OnChanged(player, oldItem, newItem, changedToThisItem);
        }

        public override void OnReloading(Player player, FirearmItem weapon, bool isAllowedHelper) {
            isAllowedHelper = false;
        }

        private IEnumerator<float> Delay(Player player) {
            if (player.CurrentItem != null) {
                player.DropItem(player.CurrentItem);
            }
            
            Ragdoll rg = Ragdoll.SpawnRagdoll(player.Role, player.Position, player.Rotation, new CustomReasonDamageHandler("Прилёг отдохнуть"), player.DisplayName, player.Scale);
            player.Inventory.enabled = false;
            player.Scale = new Vector3(0.5f, 0.5f, 0.5f);
            player.IsGodModeEnabled = true;
            
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
            rg?.Destroy();
        }

        private void ScpEffect(Player target, Player attacker) {
            switch (target.Role) {
                case RoleTypeId.Scp106:
                    Hitmarker.SendHitmarkerDirectly(attacker.ReferenceHub, 1.5f);
                    target.EnableEffect(EffectType.Slowness, 25, 10);
                    target.EnableEffect(EffectType.Blurred, 255, 10);
                    break;
                case RoleTypeId.Scp049:
                    Hitmarker.SendHitmarkerDirectly(attacker.ReferenceHub, 1.5f);
                    target.EnableEffect(EffectType.SinkHole, 10, 10);
                    target.EnableEffect(EffectType.AmnesiaVision, 255, 10);
                    target.EnableEffect(EffectType.Blurred, 255, 10);
                    break;
                case RoleTypeId.Scp096:
                    Hitmarker.SendHitmarkerDirectly(attacker.ReferenceHub, 1.5f);
                    target.EnableEffect(EffectType.SinkHole, 10, 10);
                    target.EnableEffect(EffectType.Blurred, 255, 10);
                    break;
                case RoleTypeId.Scp3114:
                    Hitmarker.SendHitmarkerDirectly(attacker.ReferenceHub, 1.5f);
                    target.EnableEffect(EffectType.Flashed, 255, 10);
                    target.EnableEffect(EffectType.Deafened, 255, 10);
                    target.EnableEffect(EffectType.SinkHole, 10, 10);
                    break;
                case RoleTypeId.Scp939:
                    Hitmarker.SendHitmarkerDirectly(attacker.ReferenceHub, 1.5f);
                    target.EnableEffect(EffectType.Slowness, 40, 10);
                    target.EnableEffect(EffectType.AmnesiaVision, 200, 10);
                    break;
                case RoleTypeId.None:
                case RoleTypeId.Scp173:
                case RoleTypeId.ClassD:
                case RoleTypeId.Spectator:
                case RoleTypeId.NtfSpecialist:
                case RoleTypeId.Scientist:
                case RoleTypeId.Scp079:
                case RoleTypeId.ChaosConscript:
                case RoleTypeId.Scp0492:
                case RoleTypeId.NtfSergeant:
                case RoleTypeId.NtfCaptain:
                case RoleTypeId.NtfPrivate:
                case RoleTypeId.Tutorial:
                case RoleTypeId.FacilityGuard:
                case RoleTypeId.CustomRole:
                case RoleTypeId.ChaosRifleman:
                case RoleTypeId.ChaosMarauder:
                case RoleTypeId.ChaosRepressor:
                case RoleTypeId.Overwatch:
                case RoleTypeId.Filmmaker:
                case RoleTypeId.Destroyed:
                case RoleTypeId.Flamingo:
                case RoleTypeId.AlphaFlamingo:
                case RoleTypeId.ZombieFlamingo:
                case RoleTypeId.NtfFlamingo:
                case RoleTypeId.ChaosFlamingo:
                default:
                    break;
            }
        }
    }
}
