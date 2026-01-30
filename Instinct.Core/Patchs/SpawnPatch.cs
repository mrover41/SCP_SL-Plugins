using HarmonyLib;
using Instinct.Core.Features.RoleSystem.Managers;
using PlayerRoles;
using Respawning;
using Respawning.Waves;

namespace Instinct.Core.Patchs {
    [HarmonyPatch(typeof(WaveManager), nameof(WaveManager.Spawn))]
    internal static class WaveSpawnPatch {
        private static bool Prefix(SpawnableWaveBase wave) {
            SpawnManager.SpawnPlayers(Player.List.Where(x => x.Role == RoleTypeId.Spectator).ToList(), RoleChangeReason.Respawn, wave.TargetFaction);
            return true;
        }
    }

    /*[HarmonyPatch(typeof(HumanSpawner), nameof(HumanSpawner.AssignHumanRoleToRandomPlayer))]
    internal static class RoundSpawnPatch {
        private static void Postfix(RoleTypeId role) {
            List<ReferenceHub> referenceHubs = HumanSpawner.Candidates;

            referenceHubs.TryGetRandomItem(out ReferenceHub random);

            SpawnManager.SpawnPlayer(Player.Get(random), SpawnReason.RoundStart, role.GetFaction());
        }
    }*/
}