using Instinct.Core.Events.Args.Roles;

namespace Instinct.Core.Events.Handles {
    public static class Roles {
        public static event Action<SpawningRoleEventArg> SpawningRole;
        public static event Action<SpawnRoleEventArg> SpawnRole;
        public static event Action<SpawningAllRolesEventArg> SpawningAllRoles;
        public static event Action SpawnAllRoles;

        public static SpawningAllRolesEventArg OnSpawningAllRoles(SpawningAllRolesEventArg args) {
            SpawningAllRoles?.Invoke(args);
            return args;
        }
        public static void OnSpawnAllRoles() {
            SpawnAllRoles?.Invoke();
        }
        public static SpawningRoleEventArg OnSpawningRole(SpawningRoleEventArg args) {
            SpawningRole?.Invoke(args);
            return args;
        }
        public static SpawnRoleEventArg OnSpawnRole(SpawnRoleEventArg args) {
            SpawnRole?.Invoke(args);
            return args;
        }
    }
}
