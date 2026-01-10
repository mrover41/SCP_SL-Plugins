using Corwarx_Project.Features.RoleSystem.BaseClass.Spawn;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;
using UnityEngine;

namespace Corwarx_Project.Features.RoleSystem.SpawnConditions {
    public class ChanceSpawnCondition : SpawnConditionBase {
        private readonly int _chance;

        public ChanceSpawnCondition(int chance) {
            _chance = chance;
        }
        
        public override bool CanSpawn(Player player, SpawnReason reason, Faction faction) {
            return Random.Range(0, 100) < _chance;
        }
    }
}