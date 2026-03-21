using System;
using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using UnityEngine;

namespace Gameplay.Modules.Lobby {
    [LoadModule]
    internal class LobbyModule : ModuleBase {
        public override void OnEnable() {
            Log.Info("Module");

            Exiled.Events.Handlers.Server.WaitingForPlayers += OnWaitingForPlayers;
            Exiled.Events.Handlers.Player.Verified += OnVerified;
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStarted;
            base.OnEnable();
        }
        
        public override void OnDisable() {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= OnWaitingForPlayers;
            Exiled.Events.Handlers.Player.Verified -= OnVerified;
            Exiled.Events.Handlers.Server.RoundStarted -= OnRoundStarted;
            base.OnDisable();
        }

        private void OnWaitingForPlayers() {
            GameObject.Find("StartRound").transform.localScale = Vector3.zero;
            Door.Get(DoorType.Intercom).Lock(DoorLockType.AdminCommand);
        }

        private void OnRoundStarted() {
            Timing.CallDelayed(1f,
                () => { Intercom.DisplayText = String.Empty; /*Да кослыть, мне в падлу делать нормально*/ });
            
            Door.Get(DoorType.Intercom).Unlock();
        }

        private void OnVerified(VerifiedEventArgs ev) {
            if (!Round.IsLobby) 
                return;
            ev.Player.Role.Set(RoleTypeId.Tutorial);
            ev.Player.Teleport(Room.Get(RoomType.EzIntercom).Transform.TransformPoint(-4.3f, -4.86f, -2.7f));
        }
    }
}
