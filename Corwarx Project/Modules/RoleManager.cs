using System.Linq;
using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Corwarx_Project.Features.RoleSystem.Managers;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace Corwarx_Project.Modules {
    [LoadModule]
    public class RoleManager : ModuleBase {
        public override void OnEnable() {
            Exiled.Events.Handlers.Player.Left += OnDisconnect;
            Exiled.Events.Handlers.Server.RoundStarted += OmStartRound;
            base.OnEnable();
        }

        public override void OnDisable() {
            Exiled.Events.Handlers.Player.Left -= OnDisconnect;
            Exiled.Events.Handlers.Server.RoundStarted -= OmStartRound;
            base.OnDisable();
        }

        private void OnDisconnect(LeftEventArgs ev) {
            ev.Player.RemoveRole();
        }

        private void OmStartRound() {
           Player player = Player.List.Where(x => x.Role == RoleTypeId.ClassD).GetRandomValue();
           if (player == null) return;
           
           Faction faction = player.Role.Team.GetFaction();
           
           SpawnManager.SpawnPlayer(player, SpawnReason.RoundStart, faction);
        }
    }
}