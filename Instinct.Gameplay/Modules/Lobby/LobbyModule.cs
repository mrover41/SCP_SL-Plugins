using Instinct.Core.Features.ModuleSystem.Attributies;
using Instinct.Core.Features.ModuleSystem.BaseClass;
using LabApi.Events.Arguments.PlayerEvents;
using PlayerRoles;
using UnityEngine;
using System.Linq;

namespace Instinct.Gameplay.Modules.Lobby {
    [LoadModule]
    internal class LobbyModule : ModuleBase {
        public override void OnEnable() {
            Logger.Info("Module");

            LabApi.Events.Handlers.ServerEvents.WaitingForPlayers += this.OnWaitingForPlayers;
            LabApi.Events.Handlers.PlayerEvents.Joined += this.OnJoined;
            base.OnEnable();
        }
        
        public override void OnDisable() {
            LabApi.Events.Handlers.ServerEvents.WaitingForPlayers -= this.OnWaitingForPlayers;
            LabApi.Events.Handlers.PlayerEvents.Joined -= this.OnJoined;
            base.OnDisable();
        }

        private void OnWaitingForPlayers() {
            GameObject.Find("StartRound").transform.localScale = Vector3.zero;
        }

        private void OnJoined(PlayerJoinedEventArgs ev) {
            if (Round.IsRoundStarted) 
                return;
            ev.Player.SetRole(RoleTypeId.Tutorial);
            
            var room = Room.Get(MapGeneration.RoomName.EzIntercom).FirstOrDefault();
            if (room != null)
            {
                var offset = new Vector3(Loader.Instance!.Config!.X, Loader.Instance!.Config!.Y, Loader.Instance!.Config!.Z);
                ev.Player.Position = room.Transform.position + room.Transform.rotation * offset;
            }
        }

        private void OnRoundStarted() {
            LabApi.Events.Handlers.ServerEvents.RoundStarted -= this.OnRoundStarted;
        }
    }
}
