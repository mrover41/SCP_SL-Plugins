using Instinct.Core.Features.RoleSystem.BaseClass.Role;
using Instinct.Core.Features.RoleSystem.SpawnConditions;
using LabApi.Features.Wrappers;
using PlayerRoles;
using UnityEngine;

namespace Instinct.Roles.Roles {
    //[LoadRole(typeof(TestRoleInstanceComponent))]
    public class TestRole : CustomRoleBase {
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