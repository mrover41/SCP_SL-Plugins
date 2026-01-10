using Corwarx_Project.Features.RoleSystem.BaseClass.Spawn;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace Corwarx_Project.Features.RoleSystem.SpawnConditions {
    public class WaveSpawnCondition : SpawnConditionBase {
        private readonly PlayerRoles.Faction _fraction;
        
        public WaveSpawnCondition(PlayerRoles.Faction frac) {
            _fraction = frac;
        }
        
        public override bool CanSpawn(Player player, SpawnReason reason, PlayerRoles.Faction faction) {
            return _fraction == faction;   
        }
    }
}