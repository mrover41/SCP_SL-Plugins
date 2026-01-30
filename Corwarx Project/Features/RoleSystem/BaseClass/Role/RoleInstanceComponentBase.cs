using LabApi.Features.Wrappers;

namespace Corwarx_Project.Features.RoleSystem.BaseClass.Role {
    public abstract class RoleInstanceComponentBase {
        public RoleBase Role { get; private set; }

        public readonly Player Player;

        protected RoleInstanceComponentBase(RoleBase role, Player player) {
            Role = role;
            Player = player;
            
            OnAdd();
        }
        
        public virtual void OnAdd() {}
        public virtual void OnRemove() {}
    }
}