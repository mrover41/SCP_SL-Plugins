using System;
using Exiled.API.Features;
using HarmonyLib;
using MEC;
using PlayerRoles;

namespace Gameplay.Patchs {
    [HarmonyPatch(typeof(CharacterClassManager), nameof(CharacterClassManager.ForceRoundStart))]
    internal static class RoundStartPatch {
        [HarmonyPrefix]
        private static bool Prefix() {
            foreach (Player player in Player.List) {
                player.Role.Set(RoleTypeId.None);
            }
            
            return true;
        }
    }
}