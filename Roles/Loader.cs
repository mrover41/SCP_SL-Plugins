using System.Linq;
using Corwarx_Project.Features.RoleSystem.Managers;
using Exiled.API.Features;
using MEC;

namespace Corwarx_Roles {
    public class Loader : Plugin<Config> {
        public override void OnEnabled() {
            RoleManager.RegisterAllRoles(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnEnabled();
        }
        
        
        override public void OnDisabled() {
            base.OnDisabled();
        }
    }
}
