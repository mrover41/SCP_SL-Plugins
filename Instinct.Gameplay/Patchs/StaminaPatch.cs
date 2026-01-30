using HarmonyLib;
using InventorySystem;

namespace Instinct.Gameplay.Patchs {
    [HarmonyPatch(typeof(Inventory), nameof(Inventory.StaminaUsageMultiplier), MethodType.Getter)]
    internal class StaminaUsageMultiplierPatch {
        public static bool Prefix(Inventory __instance, ref float __result) {
            if (!Round.IsRoundInProgress) {
                __result = 0f;
                return false;
            }
            return true;
        }
    }
}
