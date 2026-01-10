using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Corwarx_Project.Features.RoleSystem.Managers;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;

namespace Corwarx_Project.Modules {
    [LoadModule]
    public class RoleManager : ModuleBase {
        public override void OnEnable() {
            Exiled.Events.Handlers.Player.ChangingRole += ChangeRole;
            Exiled.Events.Handlers.Player.Left += OnDisconnect;
            Exiled.Events.Handlers.Server.RoundStarted += RoundStart;
            base.OnEnable();
        }

        public override void OnDisable() {
            Exiled.Events.Handlers.Player.ChangingRole -= ChangeRole;
            Exiled.Events.Handlers.Player.Left -= OnDisconnect;
            Exiled.Events.Handlers.Server.RoundStarted -= RoundStart;
            base.OnDisable();
        }

        private void OnDisconnect(LeftEventArgs ev) {
            ev.Player.RemoveRole();
        }

        private void ChangeRole(ChangingRoleEventArgs ev) {
            ev.Player.RemoveRole();
        }

        private void RoundStart() {
            Timing.CallDelayed(1f, () => {
                foreach (Player player in Player.List) {
                    RoleTypeId role = player.Role;
                    if (SpawnManager.SpawnPlayer(player, SpawnReason.RoundStart, role.GetFaction())) ;
                }
            });
        }
    }
}