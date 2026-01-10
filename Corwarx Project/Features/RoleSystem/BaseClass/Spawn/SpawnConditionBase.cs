using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;

namespace Corwarx_Project.Features.RoleSystem.BaseClass.Spawn {
    public abstract class SpawnConditionBase {
        public SpawnConditionBase() {

        }
        
        public abstract bool CanSpawn(Player player, int roleID, SpawnReason reason, SpawnableFaction faction);

        public virtual void Spawn() {
            
        }
    }
}