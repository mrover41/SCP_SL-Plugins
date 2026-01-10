using Corwarx_Project.Features.RoleSystem.Attributies;
using Corwarx_Project.Features.RoleSystem.BaseClass;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Corwarx_Project.Features.RoleSystem.SpawnConditions;
using Corwarx_Roles.Roles.InstanceComponents;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;

namespace Corwarx_Roles.Roles {
    [LoadRole(typeof(TestRoleInstanceComponent))]
    public class TestRole : RoleBase {
        public TestRole() : base(Loader.Instance.Config.TestRoleConfig) {
            SpawnConditions.Add(new RoundSpawnCondition());
            SpawnConditions.Add(new LimitRoundSpawnCondition(2));
            //SpawnConditions.Add(new ChanceSpawnCondition(101));
        }

        protected override void OnAdd(Player player) {
            player.EnableEffect(EffectType.SinkHole);
            base.OnAdd(player);
        }
    }
}