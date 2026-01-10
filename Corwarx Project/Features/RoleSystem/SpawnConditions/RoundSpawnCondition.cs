using Corwarx_Project.Features.RoleSystem.BaseClass.Spawn;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace Corwarx_Project.Features.RoleSystem.SpawnConditions {
    public class RoundSpawnCondition : SpawnConditionBase {
        public override bool CanSpawn(Player player, SpawnReason reason, PlayerRoles.Faction faction) {
            return reason == SpawnReason.RoundStart;
        }
    }
}