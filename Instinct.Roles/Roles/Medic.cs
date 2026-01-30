using Instinct.Core.Features.RoleSystem.Attributies;
using Instinct.Core.Features.RoleSystem.SpawnConditions;
using Instinct.Roles.Roles.InstanceComponents;
using PlayerRoles;
using Instinct.Core.Features.RoleSystem.BaseClass;
using Instinct.Core.Features.RoleSystem.BaseClass.Role;

namespace Instinct.Roles.Roles {
    [LoadRole(typeof(MedicRoleInstanceComponent))]
    public class Medic : CustomRoleBase {
        public Medic() : base(Loader.Instance.Config.MedicRoleConfig) {
            SpawnConditions.Add(new RoundSpawnCondition(Faction.FoundationStaff));
            SpawnConditions.Add(new LimitRoundSpawnCondition(1));
        }
    }
}