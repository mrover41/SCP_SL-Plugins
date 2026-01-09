using System.Linq;
using Corwarx_Project.Features.RoleSystem.Managers;
using Exiled.API.Features;
using MEC;

namespace Corwarx_Roles {
    public class Loader : Plugin<Config> {
        public static Loader Instance { get; private set; }

        public Loader() => Instance = this;
        
        public override void OnEnabled() {
            RoleManager.RegisterAllRoles(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnEnabled();
        }
        
        
        override public void OnDisabled() {
            Instance = null;
            base.OnDisabled();
        }
    }
}
