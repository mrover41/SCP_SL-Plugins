using Corwarx_Project.Features.RoleSystem.BaseClass.Spawn;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace Corwarx_Project.Features.RoleSystem.SpawnConditions {
    public class LimitRoundSpawnCondition : SpawnConditionBase {
        private readonly int _maxRounds;
        
        private int _currentRound = 0;
        
        public LimitRoundSpawnCondition(int max) {
            Exiled.Events.Handlers.Server.RestartingRound += OnRestartRound;
            _maxRounds = max;
        }
        public override bool CanSpawn(Player player, SpawnReason reason, PlayerRoles.Faction faction) {
            return _currentRound < _maxRounds;
        }

        public override void Spawn() {
            _currentRound++;
            base.Spawn();
        }

        private void OnRestartRound() {
            _currentRound = 0;
        }
    }
}