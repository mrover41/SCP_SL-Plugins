using Corwarx_Project.Features.RoleSystem.Attributies;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Corwarx_Project.Features.RoleSystem.SpawnConditions;
using Corwarx_Roles.Roles.InstanceComponents;
using Exiled.API.Enums;
using Exiled.API.Features;
using PlayerRoles;

namespace Corwarx_Roles.Roles {
    [LoadRole(typeof(SCP035InstanceComponent))]
    public class SCP035 : RoleBase {
        public SCP035() : base(Loader.Instance.Config.SCP035RoleConfig) {
            SpawnConditions.Add(new RoundSpawnCondition(Faction.SCP));
            SpawnConditions.Add(new LimitRoundSpawnCondition(1));
            SpawnConditions.Add(new ChanceSpawnCondition(15));
        }
        
        protected override void OnAdd(Player player) {
            player.Teleport(RoomType.LczGlassBox);
            player.MaxHealth = 500;
            player.Health = 500;
            player.CustomInfo = "<color=#ff0000>SCP035</color>";
            player.Broadcast(5, "<b>Ви стали <color=#ff0000>SCP035</color></b>\0");
            base.OnAdd(player);
        }

        protected override void OnRemove(Player player) {
            player.CustomInfo = string.Empty;
            base.OnRemove(player);
        }
    }
}