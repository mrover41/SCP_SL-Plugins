using Corwarx_Project.Features.RoleSystem.BaseClass.Spawn;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace Corwarx_Project.Features.RoleSystem.SpawnConditions {
    public class WaveSpawnCondition : SpawnConditionBase {
        private SpawnableFaction _fraction = SpawnableFaction.None;
        
        public WaveSpawnCondition(SpawnableFaction frac) {
            _fraction = frac;
        }
        
        public override bool CanSpawn(Player player, int roleID, SpawnReason reason, SpawnableFaction faction) {
            return _fraction == faction;   
        }
    }
}