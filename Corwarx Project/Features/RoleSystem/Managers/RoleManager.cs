using System.Reflection;
using Instinct.Core.Features.RoleSystem.Attributies;
using Instinct.Core.Features.RoleSystem.BaseClass.Role;

namespace Instinct.Core.Features.RoleSystem.Managers {
    public static class RoleManager {
        internal static List<BaseCustomRole?> Roles { get; } = [];
        private static List<RoleInstanceComponentBase> _roleInstances = [];
        
        public static void RegisterAllRoles(Assembly asm) {
            foreach (Type type in asm.GetTypes().Where(t => t.GetCustomAttribute<LoadRoleAttribute>() != null)) {
                Roles.Add(Activator.CreateInstance(type) as BaseCustomRole);
                
                Logger.Info($"Registered role {type.Name}");
            }
        }

        extension(Player player) {
            public void AddRole(int id) {
                BaseCustomRole? baseCustomRole = Roles.Find(x => x?.RoleConfig.ID == id);
                if (baseCustomRole == null)
                    return;
            
                Type type = baseCustomRole.GetType().GetCustomAttribute<LoadRoleAttribute>().ComponentType;
            
                RoleInstanceComponentBase roleInstance = (RoleInstanceComponentBase)Activator.CreateInstance(type, baseCustomRole, player);
            
                baseCustomRole.EnableRole(player);
                roleInstance.OnAdd();
            
                _roleInstances.Add(roleInstance);
            }

            public void AddRole(BaseCustomRole? baseCustomRole) {
                if (baseCustomRole == null)
                    return;
            
                Type type = baseCustomRole.GetType().GetCustomAttribute<LoadRoleAttribute>().ComponentType;
            
                RoleInstanceComponentBase roleInstance = (RoleInstanceComponentBase)Activator.CreateInstance(type, baseCustomRole, player);
            
                baseCustomRole.EnableRole(player);
                roleInstance.OnAdd();
            
                _roleInstances.Add(roleInstance);
            }

            public void RemoveRole() {
                for (;;) {
                    RoleInstanceComponentBase roleInstance = _roleInstances.Find(x => x.Player == player);
                    if (roleInstance == null)
                        return;
            
                    roleInstance.OnRemove();
                    roleInstance.BaseCustomRole.DisableRole(player);
            
                    _roleInstances.Remove(roleInstance);
                }
            }
        }
    }
}