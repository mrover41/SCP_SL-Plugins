using Instinct.Core.Features.RoleSystem.BaseClass.Spawn;
using PlayerRoles;

namespace Instinct.Core.Features.RoleSystem.SpawnConditions {
    public class LimitRoundSpawnCondition : SpawnConditionBase {
        private readonly int _maxRounds;
        
        private int _currentRound;
        
        public LimitRoundSpawnCondition(int max) {
            LabApi.Events.Handlers.ServerEvents.RoundRestarted += this.OnRestartRound;
            this._maxRounds = max;
        }
        
        public override bool CanSpawn(Player player, RoleChangeReason reason, Faction faction) {
            return this._currentRound < this._maxRounds;
        }

        public override void Spawn() {
            this._currentRound++;
            base.Spawn();
        }

        private void OnRestartRound() {
            this._currentRound = 0;
        }
    }
}