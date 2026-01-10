using Corwarx_Project.Features.ModuleSystem.BaseClass;
using Corwarx_Project.Features.RoleSystem.Managers;
using Exiled.Events.EventArgs.Player;

namespace Corwarx_Project.Modules {
    public class RoleManager : ModuleBase {
        public override void OnEnable() {
            Exiled.Events.Handlers.Player.ChangingRole += ChangeRole;
            Exiled.Events.Handlers.Player.Left += OnDisconnect;
            base.OnEnable();
        }

        public override void OnDisable() {
            Exiled.Events.Handlers.Player.ChangingRole -= ChangeRole;
            Exiled.Events.Handlers.Player.Left -= OnDisconnect;
            base.OnDisable();
        }

        private void OnDisconnect(LeftEventArgs ev) {
            ev.Player.RemoveRole();
        }

        private void ChangeRole(ChangingRoleEventArgs ev) {
            ev.Player.RemoveRole();
        }
    }
}