using CustomPlayerEffects;
using Instinct.Core.Enums;
using InventorySystem.Items;
using PlayerRoles.FirstPersonControl;
using PlayerStatsSystem;
using UnityEngine;

namespace Instinct.Core.Extensions;

public static class PlayerExtensions {
    extension(Player player) {
        public StatusEffectBase? GetEffectFromName(EffectType type) {
            player.TryGetEffect(type.ToString(), out StatusEffectBase? statusEffect);
            return statusEffect;
        }

        public bool EnableEffect(EffectType type, byte intensity = 1, float duration = 0, bool addDuration = false) {
            StatusEffectBase? effect = GetEffectFromName(player, type);
            if (effect == null)
                return false;
            player.EnableEffect(effect, intensity, duration, addDuration);
            return true;
        }

        public bool EnableEffectIfNotExists(EffectType type, byte intensity = 1, float duration = 0, bool addDuration = false) {
            StatusEffectBase? effect = GetEffectFromName(player, type);
            if (effect == null)
                return false;
            if (effect.IsEnabled)
                return false;
        
            player.EnableEffect(effect, intensity, duration, addDuration);
            return true;
        }

        public bool DisableEffect(EffectType type) {
            StatusEffectBase? effect = GetEffectFromName(player, type);
            if (effect == null)
                return false;
        
            player.DisableEffect(effect);
            return true;
        }

        public Player? GetFromView(float lenght) {
            return !Physics.Raycast(player.Camera.position, player.Camera.forward, out RaycastHit hit, lenght) ? null : Player.Get(hit.transform.GetComponentInParent<ReferenceHub>());
        }

        public string ToShortString() => player.IsHost ? "Server" : $"{player.Nickname} ({player.PlayerId}|{player.UserId})";
        
        public List<Player> FindNearby(float distance) => Player.List.Where(x => Vector3.Distance(player.Position, x.Position) <= distance && x != player).ToList();

        public void AddAhp(float amount, float decay = 1.2f, float efficacy = 0.7f, float sustain = 0f, bool persistant = false) {
            if (amount < 0f)
                return;
        
            player.ReferenceHub.playerStats.GetModule<AhpStat>().ServerAddProcess(amount, player.MaxArtificialHealth, decay, efficacy, sustain, persistant);
        }

        public void ThrewItem(Item item) {
            player.Inventory.UserCode_CmdDropItem__UInt16__Boolean(item.Serial, true);
        }

        public void SetScale(Vector3 value, bool isFake = false) {
            Vector3 original = player.Scale;
            if (value == original && !isFake)
                return;

            if (isFake) {
                SetFakeScale(player, Player.ReadyList.Where(x => x != player), value);
                return;
            }

            player.Scale = value;
            if (value == Vector3.one)
                return;
        
            if (player.ReferenceHub.roleManager.CurrentRole is not IFpcRole fpcRole)
                return;
        
            float halfHeight = fpcRole.FpcModule.CharController.height / 2;
            float tpY = value.y < -0.1f ? value.y * -1f : value.y - halfHeight;
            player.Position += new Vector3(0f, tpY, 0f);
        }

        public void SetFakeGravity(Player target, Vector3 gravity) {
            player.Connection.Send<SyncedGravityMessages.GravityMessage>(new(gravity, target.ReferenceHub));
        }

        public void SetFakeGravity(IEnumerable<Player> targets, Vector3 gravity) {
            foreach (Player target in targets) {
                player.SetFakeGravity(target, gravity);
            }
        }

        public void SetFakeScale(Player target, Vector3 scale) {
            player.Connection.Send<SyncedScaleMessages.ScaleMessage>(new(scale, target.ReferenceHub));
        }

        public void SetFakeScale(IEnumerable<Player> targets, Vector3 scale) {
            foreach (Player target in targets) {
                player.SetFakeScale(target, scale);
            }
        }

        public void SetFakeBadgeText(Player target, string badgeText) {
            target.SendFakeSyncVar(player.ReferenceHub.serverRoles, 1, badgeText);
        }

        public void SetFakeBadgeColor(Player target, string color) {
            target.SendFakeSyncVar(player.ReferenceHub.serverRoles, 2, color);
        }

        public void SetFakeViewRange(Player target, float viewRange) {
            target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 1, viewRange);
        }

        public void SetFakeCustomInfo(Player target, string customInfo) {
            target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 2, customInfo);
        }

        public void SetFakeInfoArea(Player target, PlayerInfoArea playerInfoArea) {
            target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 4, playerInfoArea);
        }

        public void SetFakeNick(Player target, string nick) {
            target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 8, nick);
        }

        public void SetFakeDisplayName(Player target, string displayName) {
            target.SendFakeSyncVar(player.ReferenceHub.nicknameSync, 16, displayName);
        }

        public void SetFakeMaxPlayers(Player target, ushort maxPlayer) {
            target.SendFakeSyncVar(player.ReferenceHub.characterClassManager, 2, maxPlayer);
        }

        public void SetFakeCurrentItem(Player target, ItemIdentifier item) {
            target.SendFakeSyncVar(player.ReferenceHub.inventory, 1, item);
        }
    }
}