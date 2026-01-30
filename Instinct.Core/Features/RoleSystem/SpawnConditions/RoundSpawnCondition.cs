using Instinct.Core.Features.RoleSystem.BaseClass.Spawn;
using PlayerRoles;

namespace Instinct.Core.Features.RoleSystem.SpawnConditions {
    public class RoundSpawnCondition(Faction faction, bool useFaction = true) : SpawnConditionBase {
        public override bool CanSpawn(Player player, RoleChangeReason reason, Faction faction1) {
            if (!useFaction)
                return reason == RoleChangeReason.RoundStart;
            
            return reason == RoleChangeReason.RoundStart && faction == faction1;
        }
    }
}