using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using LabApi.API.Enums;
using LabApi.API.Features;
using LabApi.Events.EventArgs.Player;
using PlayerRoles;
using UnityEngine;

namespace Gameplay.Modules.Lobby {
    [LoadModule]
    internal class LobbyModule : ModuleBase {
        public override void OnEnable() {
            Logger.Info("Module");

            LabApi.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayers;
            LabApi.Events.Handlers.Player.Verified += OnVerified;
            base.OnEnable();
        }
        
        public override void OnDisable() {
            LabApi.Events.Handlers.Server.WaitingForPlayers -= OnWaitingForPlayers;
            LabApi.Events.Handlers.Player.Verified -= OnVerified;
            base.OnDisable();
        }

        private void OnWaitingForPlayers() {
            GameObject.Find("StartRound").transform.localScale = Vector3.zero;
        }

        private void OnVerified(VerifiedEventArgs ev) {
            if (!Round.IsLobby) 
                return;
            ev.Player.Role.Set(RoleTypeId.Tutorial);
            ev.Player.Teleport(Room.Get(RoomType.EzIntercom).Transform.TransformPoint(-4.3f, -4.86f, -2.7f));
        }

        private void OnRoundStarted() {
            LabApi.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
        }
    }
}
