using System.Collections.Generic;
using System.Linq;
using Corwarx_Project.Features.RoleSystem.Managers;
using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using MEC;
using PlayerRoles;
using PlayerRoles.RoleAssign;
using Respawning;
using Respawning.Waves;

namespace Corwarx_Project.Patchs {
    [HarmonyPatch(typeof(WaveManager), nameof(WaveManager.Spawn))]
    public class WaveSpawnPatch {
        [HarmonyPostfix]
        public static bool Postfix(SpawnableWaveBase wave) {
            SpawnManager.SpawnPlayers(Player.List.Where(x => x.Role == RoleTypeId.Spectator).ToList(), SpawnReason.Respawn, wave.TargetFaction);
            return true;
        }
    }

    /*[HarmonyPatch(typeof(HumanSpawner), nameof(HumanSpawner.AssignHumanRoleToRandomPlayer))]
    public static class RoundSpawnPatch {
        [HarmonyPrefix]
        public static bool Prefix(RoleTypeId role) {
            List<ReferenceHub> referenceHubs = HumanSpawner.Candidates;

            referenceHubs.TryGetRandomItem(out ReferenceHub random);
            
            if (SpawnManager.SpawnPlayer(Player.Get(random), SpawnReason.RoundStart, role.GetFaction()))
                return false;
            return true;
        }
    }*/
}