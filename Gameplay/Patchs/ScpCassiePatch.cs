using Cassie;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Corwarx_Project.Features.RoleSystem.Managers;
using Exiled.API.Features;
using Exiled.API.Features.DamageHandlers;
using HarmonyLib;
using PlayerRoles;

namespace Gameplay.Patches {
    [HarmonyPatch(typeof(CassieScpTerminationAnnouncement), nameof(CassieScpTerminationAnnouncement.AnnounceScpTermination))]
    internal class ScpCassiePatch {
        private static bool Prefix(ReferenceHub scp, DamageHandlerBase hit) {
            Player.TryGet(scp, out Player ply);
            RoleInstanceComponentBase roleComponent = ply.GetRole();
            if (ply != null && roleComponent != null && roleComponent.Role.RoleConfig.Team == Team.SCPs) {
                Exiled.API.Features.Cassie.CustomScpTermination(roleComponent.Role.RoleConfig.Name, hit);
                return false;
            }
            return true;
        }
    }
}
