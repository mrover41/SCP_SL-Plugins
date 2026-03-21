using Corwarx_Project.Features.RoleSystem.Managers;
using Exiled.API.Features;
using HarmonyLib;
using PlayerRoles.FirstPersonControl;
using UnityEngine;

namespace Gameplay.Patchs {
    [HarmonyPatch(typeof(Escape), nameof(Escape.CanEscape))]
    internal static class EscapePatch {
        [HarmonyPrefix]
        private static bool Prefix(ReferenceHub hub, out IFpcRole role, out Bounds zone, ref bool __result) {
            role = null;
            zone = default;
            
            if (Player.Get(hub).GetRole() != null) __result = false;
            else return true;
           return false;
        }
    }
}