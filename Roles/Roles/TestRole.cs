using Corwarx_Project.Features.RoleSystem.Attributies;
using Corwarx_Project.Features.RoleSystem.BaseClass;
using Corwarx_Roles.Configs;
using Corwarx_Roles.Roles.InstanceComponents;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace Corwarx_Roles.Roles {
    [LoadRole(typeof(TestRoleInstanceComponent))]
    public class TestRole : RoleBase {
        public TestRole() : base(new TestRoleConfig()) {
            this.ID = 5;
        }

        protected override void OnAdd(Player player) {
            Log.Info("I`M ADD");
            player.EnableEffect(EffectType.Flashed);
            base.OnAdd(player);
        }
    }
}