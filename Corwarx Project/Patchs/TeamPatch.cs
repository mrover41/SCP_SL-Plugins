using System.Reflection;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Corwarx_Project.Features.RoleSystem.Managers;
using Exiled.API.Features;
using HarmonyLib;
using PlayerRoles;
using Respawning;

namespace Corwarx_Project.Patchs {
    /*[HarmonyPatch(typeof(Round), nameof(PlayerRoleBase.Team), MethodType.Getter)]
    public static class TeamPatch {
        [HarmonyPostfix]
        public static void Postfix(PlayerRoleBase __instance, ref Team __result) {
            if (__instance.TryGetOwner(out ReferenceHub owner)) {
                Player player = Player.Get(owner);
                RoleInstanceComponentBase roleInstance = player.GetRole();
                if (roleInstance != null) {
                    __result = roleInstance.Role.RoleConfig.Team;
                }
            }
        }
    }*/
    
    [HarmonyPatch(typeof(HumanRole), nameof(HumanRole.Team), MethodType.Getter)]
    public static class HumanTeamPatch {
        private static readonly FieldInfo LastOwnerField = AccessTools.Field(typeof(PlayerRoleBase), "_lastOwner");
        [HarmonyPostfix]
        public static void Postfix(PlayerRoles.HumanRole __instance, ref Team __result) {
            if (LastOwnerField.GetValue(__instance) is ReferenceHub hub && hub != null) {
                Player player = Player.Get(hub);
                RoleInstanceComponentBase customRole = player?.GetRole();

                if (customRole != null) {
                    __result = customRole.Role.RoleConfig.Team;
                }
            }
        }
    }
}