using Instinct.Core.Features.RoleSystem.BaseClass.Spawn;
using PlayerRoles;
using Random = UnityEngine.Random;

namespace Instinct.Core.Features.RoleSystem.SpawnConditions {
    public class ChanceSpawnCondition(int chance) : SpawnConditionBase {
        public override bool CanSpawn(Player player, RoleChangeReason reason, Faction faction) {
            return Random.Range(0, 100) < chance;
        }
    }
}