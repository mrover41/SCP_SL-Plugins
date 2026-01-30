using PlayerRoles;

namespace Instinct.Core.Features.RoleSystem.Containers {
    public abstract class RoleConfig {
        public Team Team { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ID { get; set; }
        public RoleTypeId RoleTypeId { get; set; }
        public List<ItemType>? Items { get; set; }
        public List<Type>? CustomItems { get; set; }
    }
}