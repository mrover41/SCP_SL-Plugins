using System.Linq;
using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Corwarx_Project.Features.RoleSystem.Managers;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Wrappers;
using PlayerRoles;

namespace Corwarx_Project.Modules {
    [LoadModule]
    public class RoleManager : ModuleBase {
        public override void OnEnable() {
            LabApi.Events.Handlers.PlayerEvents.Left += OnDisconnect;
            LabApi.Events.Handlers.ServerEvents.RoundStarted += OmStartRound;
            base.OnEnable();
        }

        public override void OnDisable() {
            LabApi.Events.Handlers.PlayerEvents.Left -= OnDisconnect;
            LabApi.Events.Handlers.ServerEvents.RoundStarted -= OmStartRound;
            base.OnDisable();
        }

        private void OnDisconnect(PlayerLeftEventArgs ev) {
            ev.Player.RemoveRole();
        }

        private void OmStartRound() {
            foreach (Player player in  Player.List) {
                if (player == null) return;
           
                Faction faction = player.Team.GetFaction();
           
                SpawnManager.SpawnPlayer(player, RoleChangeReason.RoundStart, faction);
            }
        }
    }
}