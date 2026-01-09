using System.Linq;
using Corwarx_Project.Features.RoleSystem.Managers;
using Exiled.API.Features;
using MEC;

namespace Corwarx_Roles {
    public class Loader : Plugin<Config> {
        public override void OnEnabled() {
            RoleManager.RegisterAllRoles(System.Reflection.Assembly.GetExecutingAssembly());
            Exiled.Events.Handlers.Server.RoundStarted += StartRound;
            base.OnEnabled();
        }

        private void StartRound() {
            Timing.CallDelayed(1f, () => { RoleManager.AddRole(Player.List.First(), 5); });
            Log.Info("Starting Round");
        }
        
        override public void OnDisabled() {
            Exiled.Events.Handlers.Server.RoundStarted -= StartRound;
            base.OnDisabled();
        }
    }
}
