using Corwarx_Project.Features.RoleSystem.Attributies;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Corwarx_Project.Features.RoleSystem.SpawnConditions;
using Corwarx_Roles.Roles.InstanceComponents;
using PlayerRoles;

namespace Corwarx_Roles.Roles {
    [LoadRole(typeof(MedicRoleInstanceComponent))]
    public class Medic : RoleBase {
        public Medic() : base(Loader.Instance.Config.MedicRoleConfig) {
            SpawnConditions.Add(new RoundSpawnCondition(Faction.FoundationStaff));
            SpawnConditions.Add(new LimitRoundSpawnCondition(1));
        }
    }
}