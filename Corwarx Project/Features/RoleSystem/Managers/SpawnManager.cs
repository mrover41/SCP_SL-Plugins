using System.Collections.Generic;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Corwarx_Project.Features.RoleSystem.BaseClass.Spawn;
using LabApi.Features.Wrappers;
using PlayerRoles;

namespace Corwarx_Project.Features.RoleSystem.Managers {
    public static class SpawnManager {
        public static void SpawnPlayers(List<Player> players, RoleChangeReason reason, PlayerRoles.Faction faction) {
            foreach (Player player in players) {
                SpawnPlayer(player, reason, faction);
            }
        }

        public static bool SpawnPlayer(Player player, RoleChangeReason reason, PlayerRoles.Faction faction) {
            foreach (RoleBase role in RoleManager.Roles) {
                bool can = true;
                
                foreach (SpawnConditionBase condition in role.SpawnConditions) {
                    if (!condition.CanSpawn(player, reason, faction)) {
                        can = false;
                        break;
                    }
                }

                if (!can)
                    continue;
                
                player.AddRole(role);
                foreach (SpawnConditionBase condition in role.SpawnConditions) {
                    condition.Spawn();
                }
                return true;
            }
            return false;
        }
    }
}