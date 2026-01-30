namespace Corwarx_Project {
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
