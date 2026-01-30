using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using LabApi.Features.Wrappers;
using PlayerRoles;

namespace Corwarx_Project.Features.RoleSystem.BaseClass.Spawn {
    public abstract class SpawnConditionBase {
        public SpawnConditionBase() {

        }
        
        public abstract bool CanSpawn(Player player, RoleChangeReason reason, PlayerRoles.Faction faction);

        public virtual void Spawn() {
            
        }
    }
}