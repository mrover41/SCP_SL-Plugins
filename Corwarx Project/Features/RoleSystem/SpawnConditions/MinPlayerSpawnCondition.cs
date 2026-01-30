using Corwarx_Project.Features.RoleSystem.BaseClass.Spawn;
using LabApi.API.Enums;
using LabApi.API.Features;

namespace Corwarx_Project.Features.RoleSystem.SpawnConditions {
    public class MinPlayerSpawnCondition : SpawnConditionBase {
        private int _minCount = 0;
        
        public MinPlayerSpawnCondition(int minCount) {
            _minCount = minCount;
        }
        
        public override bool CanSpawn(Player player, SpawnReason reason, PlayerRoles.Faction faction) {
            return Player.List.Count > _minCount;
        }
    }
}