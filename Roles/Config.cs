using System;
using System.Collections.Generic;
using Corwarx_Project.Features.RoleSystem.Containers;
using Exiled.API.Interfaces;
using Items.Items;
using PlayerRoles;

namespace Corwarx_Roles {
    public class Config : IConfig {
        public RoleConfig TestRoleConfig { get; set; } = new RoleConfig {
            ID = 5,
            Name = "TestRole",
            Description = "Test Role",
            Team = Team.ClassD,
            RoleTypeId = RoleTypeId.ClassD,
            IsEnabled = false
        };

        public RoleConfig SCP343RoleConfig { get; set; } = new RoleConfig {
            ID = 343,
            Name = "SCP343",
            Description = "Бог",
            Items = new List<ItemType>() {
                ItemType.Medkit,
                ItemType.Medkit,
                ItemType.Medkit,
                ItemType.Medkit,
                ItemType.Medkit,
                ItemType.Medkit,
                ItemType.Medkit,
                ItemType.Medkit
            },
            RoleTypeId = RoleTypeId.Scientist,
            Team = Team.Dead,
            IsEnabled = true
        };

        public RoleConfig SCP035RoleConfig { get; set; } = new RoleConfig {
            ID = 35,
            Name = "SCP035",
            Description = "SCP035 Role",
            RoleTypeId = RoleTypeId.Tutorial,
            Team = Team.SCPs,
            IsEnabled = true
        };

        public RoleConfig MedicRoleConfig { get; set; } = new RoleConfig {
            ID = 6,
            Name = "MedicRole",
            Description = "Medic",
            Items = new List<ItemType> {
                ItemType.Medkit,
                ItemType.Medkit,
                ItemType.Medkit
            },
            CustomItems = new List<Type> {
                typeof(Trangulizer)
            },
            RoleTypeId = RoleTypeId.Scientist,
            Team = Team.Scientists,
            IsEnabled = true
        };

        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
    }
}