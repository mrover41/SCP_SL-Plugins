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
            Exiled.Events.Handlers.Player.Left += OnDisconnect;
            base.OnEnable();
        }

        public override void OnDisable() {
            Exiled.Events.Handlers.Player.Left -= OnDisconnect;
            base.OnDisable();
        }

        private void OnDisconnect(LeftEventArgs ev) {
            ev.Player.RemoveRole();
        }
        
    }
}