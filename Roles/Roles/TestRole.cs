using Corwarx_Project.Features.RoleSystem.Attributies;
using Corwarx_Project.Features.RoleSystem.BaseClass;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Corwarx_Project.Features.RoleSystem.SpawnConditions;
using Corwarx_Roles.Roles.InstanceComponents;
using LabApi.API.Enums;
using LabApi.API.Features;
using PlayerRoles;
using UnityEngine;

namespace Corwarx_Roles.Roles {
    //[LoadRole(typeof(TestRoleInstanceComponent))]
    public class TestRole : RoleBase {
        public TestRole() : base(Loader.Instance.Config.TestRoleConfig) {
            SpawnConditions.Add(new RoundSpawnCondition(Faction.FoundationEnemy));
            SpawnConditions.Add(new LimitRoundSpawnCondition(1));
        }

        protected override void OnAdd(Player player) {
            player.Scale = Vector3.one * 0.5f;
            base.OnAdd(player);
        }

        protected override void OnRemove(Player player) {
            player.Scale = Vector3.one;
            base.OnRemove(player);
        }
    }
}