namespace Instinct.Roles.Roles {
    [LoadRole(typeof(MedicRoleInstanceComponent))]
    public class Medic : RoleBase {
        public Medic() : base(Loader.Instance.Config.MedicRoleConfig) {
            SpawnConditions.Add(new RoundSpawnCondition(Faction.FoundationStaff));
            SpawnConditions.Add(new LimitRoundSpawnCondition(1));
        }
    }
}