using System.Linq;
using Corwarx_Project.Features.RoleSystem.Attributies;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Corwarx_Project.Features.RoleSystem.SpawnConditions;
using Corwarx_Roles.Roles.InstanceComponents;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;

namespace Corwarx_Roles.Roles {
    [LoadRole(typeof(SCP0762InstanceComponent))]
    public class SCP0762 : RoleBase {
        public SCP0762() : base(Loader.Instance.Config.SCP0762RoleConfig) {
            SpawnConditions.Add(new RoundSpawnCondition(Faction.SCP));
            SpawnConditions.Add(new LimitRoundSpawnCondition(1));
            SpawnConditions.Add(new MinPlayerSpawnCondition(3));
            SpawnConditions.Add(new ChanceSpawnCondition(10));
        }

        protected override void OnAdd(Player player) {
            player.Broadcast(5, "<b>Ви стали <color=#ff0000>SCP076-2</color></b>\0");
            player.MaxHealth = 1800;
            player.Health = 1800;
            player.CurrentItem = player.Items.First();
            player.Teleport(RoomType.HczHid);
            base.OnAdd(player);
        }
    }
}