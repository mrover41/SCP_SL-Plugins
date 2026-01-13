using Corwarx_Project.Features.RoleSystem.BaseClass.Spawn;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;

namespace Corwarx_Project.Features.RoleSystem.SpawnConditions {
    public class RoundSpawnCondition : SpawnConditionBase {
        private readonly PlayerRoles.Faction _faction;
        private readonly bool _useFaction;
        public RoundSpawnCondition(Faction faction, bool useFaction = true) {
            _faction = faction;
            _useFaction = useFaction;
        }
        public override bool CanSpawn(Player player, SpawnReason reason, PlayerRoles.Faction faction) {
            if (!_useFaction)
                return reason == SpawnReason.RoundStart;
            else
                return reason == SpawnReason.RoundStart &&  _faction == faction;
        }
    }
}