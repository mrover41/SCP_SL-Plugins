using PlayerRoles;

namespace Instinct.Core.Features.RoleSystem.BaseClass.Spawn {
    public abstract class SpawnConditionBase {
        public abstract bool CanSpawn(Player player, RoleChangeReason reason, Faction faction);

        public virtual void Spawn() { }
    }
}