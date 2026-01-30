using Instinct.Core.Features.ModuleSystem.Attributies;
using Instinct.Core.Features.ModuleSystem.BaseClass;
using Instinct.Core.Features.RoleSystem.Managers;
using LabApi.Events.Arguments.PlayerEvents;
using PlayerRoles;

namespace Instinct.Core.Modules {
    [LoadModule]
    public class RoleManager : ModuleBase {
        public override void OnEnable() {
            LabApi.Events.Handlers.PlayerEvents.Left += this.OnDisconnect;
            LabApi.Events.Handlers.ServerEvents.RoundStarted += this.OmStartRound;
            base.OnEnable();
        }

        public override void OnDisable() {
            LabApi.Events.Handlers.PlayerEvents.Left -= this.OnDisconnect;
            LabApi.Events.Handlers.ServerEvents.RoundStarted -= this.OmStartRound;
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