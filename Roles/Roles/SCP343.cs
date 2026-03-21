using Corwarx_Project.Features.RoleSystem.Attributies;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Corwarx_Project.Features.RoleSystem.Containers;
using Corwarx_Project.Features.RoleSystem.SpawnConditions;
using Corwarx_Roles.Roles.InstanceComponents;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;

namespace Corwarx_Roles.Roles {
    [LoadRole(typeof(SCP343RoleInstanceComponent))]
    public class SCP343 : RoleBase {
        public SCP343() : base(Loader.Instance.Config.SCP343RoleConfig) {
            SpawnConditions.Add(new RoundSpawnCondition(Faction.FoundationEnemy));
            SpawnConditions.Add(new MinPlayerSpawnCondition(3));
            SpawnConditions.Add(new ChanceSpawnCondition(5));
            SpawnConditions.Add(new LimitRoundSpawnCondition(1));
        }

        protected override void OnAdd(Player player) {
            player.IsGodModeEnabled = true;
            player.IsBypassModeEnabled = true;
            player.EnableEffect(EffectType.Ghostly);
            Round.IgnoredPlayers.Add(player.ReferenceHub);
            player.MaxHealth = 100;
            player.Health = player.MaxHealth;
            
            base.OnAdd(player);
        }

        protected override void OnRemove(Player player) {
            player.IsGodModeEnabled = false;
            player.IsBypassModeEnabled = false;
            Round.IgnoredPlayers.Add(player.ReferenceHub);
            
            base.OnRemove(player);
        }
    }
}