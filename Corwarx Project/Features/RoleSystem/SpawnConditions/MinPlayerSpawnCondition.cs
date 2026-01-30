using Instinct.Core.Features.RoleSystem.BaseClass.Spawn;
using PlayerRoles;

namespace Instinct.Core.Features.RoleSystem.SpawnConditions {
    public class MinPlayerSpawnCondition(int minCount) : SpawnConditionBase {
        public override bool CanSpawn(Player player, RoleChangeReason reason, Faction faction) {
            return Player.List.Count > minCount;
        }
    }
}