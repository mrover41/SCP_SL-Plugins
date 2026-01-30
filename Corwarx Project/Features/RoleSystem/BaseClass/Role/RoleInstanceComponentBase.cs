namespace Instinct.Core.Features.RoleSystem.BaseClass.Role {
    public abstract class RoleInstanceComponentBase {
        public BaseCustomRole BaseCustomRole { get; private set; }

        public readonly Player Player;

        protected RoleInstanceComponentBase(BaseCustomRole baseCustomRole, Player player) {
            this.BaseCustomRole = baseCustomRole;
            this.Player = player;

            this.OnAdd();
        }
        
        public virtual void OnAdd() {}
        public virtual void OnRemove() {}
    }
}