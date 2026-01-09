using Corwarx_Project.Features.RoleSystem.Containers;
using Exiled.API.Interfaces;
using PlayerRoles;

namespace Corwarx_Roles {
    public class Config : IConfig {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }

        public RoleConfig TestRoleConfig { get; set; } = new RoleConfig() {
            ID = 5,
            Name = "TestRole",
            Description = "Test Role",
            Team = Team.ClassD
        };
    }
}
