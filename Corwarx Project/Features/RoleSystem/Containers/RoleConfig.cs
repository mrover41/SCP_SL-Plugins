using System.Collections.Generic;
using Exiled.CustomItems.API.Features;
using PlayerRoles;

namespace Corwarx_Project.Features.RoleSystem.Containers {
    public class RoleConfig {
        public Team Team { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public RoleTypeId RoleTypeId { get; set; }
        public List<ItemType> Items { get; set; }
    }
}