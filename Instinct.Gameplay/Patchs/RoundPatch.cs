using HarmonyLib;
using PlayerRoles;

namespace Instinct.Gameplay.Patchs {
    [HarmonyPatch(typeof(CharacterClassManager), nameof(CharacterClassManager.ForceRoundStart))]
    internal static class RoundStartPatch {
        [HarmonyPrefix]
        private static bool Prefix() {
            foreach (Player player in Player.List) {
                player.SetRole(RoleTypeId.None);
            }
            return true;
        }
    }
}