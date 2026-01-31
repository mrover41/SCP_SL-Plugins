using System;
using System.Collections.Generic;
using Instinct.Items.Items;
using Instinct.Core.Features.RoleSystem.Containers;
using PlayerRoles;

namespace Instinct.Roles {
    public class Config {
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
    }
}