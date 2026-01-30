using System;
using System.Collections.Generic;
using Corwarx_Project.Features.RoleSystem.Containers;
using LabApi.API.Interfaces;
using Items.Items;
using PlayerRoles;

namespace Corwarx_Roles {
    public class Config : IConfig {
        public RoleConfig TestRoleConfig { get; set; } = new RoleConfig {
            ID = 5,
            Name = "TestRole",
            Description = "Test Role",
            Team = Team.ClassD,
            RoleTypeId = RoleTypeId.ClassD
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
            Team = Team.Scientists
        };

        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }
    }
}