using Instinct.Core.Features.RoleSystem.BaseClass.Role;
using Instinct.Core.Features.RoleSystem.BaseClass.Spawn;
using PlayerRoles;

namespace Instinct.Core.Features.RoleSystem.Managers {
    public static class SpawnManager {
        public static void SpawnPlayers(List<Player> players, RoleChangeReason reason, Faction faction) {
            foreach (Player player in players) {
                SpawnPlayer(player, reason, faction);
            }
        }

        public static bool SpawnPlayer(Player player, RoleChangeReason reason, Faction faction) {
            foreach (CustomRoleBase? role in from role in RoleManager.Roles let can = role?.SpawnConditions != null && (role.SpawnConditions).All(condition => condition.CanSpawn(player, reason, faction)) where can select role) {
                player.AddRole(role);
                if (role?.SpawnConditions == null) return true;
                
                foreach (SpawnConditionBase condition in role.SpawnConditions) {
                    condition.Spawn();
                }

                return true;
            }

            return false;
        }
    }
}