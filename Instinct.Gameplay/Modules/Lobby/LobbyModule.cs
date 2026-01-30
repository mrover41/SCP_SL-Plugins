using Instinct.Core.Features.ModuleSystem.Attributies;
using Instinct.Core.Features.ModuleSystem.BaseClass;
using LabApi.Events.Arguments.PlayerEvents;
using PlayerRoles;
using UnityEngine;

namespace Instinct.Gameplay.Modules.Lobby {
    [LoadModule]
    internal class LobbyModule : ModuleBase {
        public override void OnEnable() {
            Logger.Info("Module");

            LabApi.Events.Handlers.ServerEvents.WaitingForPlayers += OnWaitingForPlayers;
            LabApi.Events.Handlers.PlayerEvents.Joined += OnJoined;
            base.OnEnable();
        }
        
        public override void OnDisable() {
            LabApi.Events.Handlers.ServerEvents.WaitingForPlayers -= OnWaitingForPlayers;
            LabApi.Events.Handlers.PlayerEvents.Joined -= OnJoined;
            base.OnDisable();
        }

        private void OnWaitingForPlayers() {
            GameObject.Find("StartRound").transform.localScale = Vector3.zero;
        }

        private void OnJoined(PlayerJoinedEventArgs ev) {
            if (Round.IsRoundStarted) 
                return;
            ev.Player.SetRole(RoleTypeId.Tutorial);
            ev.Player.Position = Room.Get(MapGeneration.RoomName.EzIntercom).FirstOrDefault().Transform.position + new Vector3(-4.3f, -4.86f, -2.7f);
        }

        private void OnRoundStarted() {
            LabApi.Events.Handlers.ServerEvents.RoundStarted -= OnRoundStarted;
        }
    }
}
