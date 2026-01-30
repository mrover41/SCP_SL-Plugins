namespace Instinct.Core.Features.RoleSystem.BaseClass.Role {
    public abstract class RoleInstanceComponentBase {
        public CustomRoleBase CustomRoleBase { get; private set; }

        public readonly Player Player;

        protected RoleInstanceComponentBase(CustomRoleBase customRoleBase, Player player) {
            this.CustomRoleBase = customRoleBase;
            this.Player = player;

            this.OnAdd();
        }
        
        public virtual void OnAdd() {}
        public virtual void OnRemove() {}
    }
}