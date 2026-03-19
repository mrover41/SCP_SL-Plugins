using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Corwarx_Project.Features.RoleSystem.Attributies;
using Corwarx_Project.Features.RoleSystem.BaseClass;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Exiled.API.Features;

namespace Corwarx_Project.Features.RoleSystem.Managers {
    public static class RoleManager {
        //internal static List<RoleBase> Roles { get; private set; } = new List<RoleBase>();
        //private static List<RoleInstanceComponentBase> RoleInstances = new List<RoleInstanceComponentBase>();
        internal static Dictionary<int, RoleBase> Roles { get; private set; } = new Dictionary<int, RoleBase>();
        public static readonly Dictionary<Player, RoleInstanceComponentBase> RoleInstances = new Dictionary<Player, RoleInstanceComponentBase>();
        
        public static void RegisterAllRoles(Assembly asm) {
            foreach (Type type in asm.GetTypes().Where(t => t.GetCustomAttribute<LoadRoleAttribute>() != null)) {
                RoleBase role = Activator.CreateInstance(type) as RoleBase;
                
                if (role == null || !role.RoleConfig.IsEnabled) return;
                
                Roles.Add(role.RoleConfig.ID, role);
                
                Log.Info($"Registered role {type.Name}");
            }
        }

        public static void AddRole(this Player player, int id) {
            RoleBase role = Roles[id];
            if (role == null)
                return;
            
            Type type = role.GetType().GetCustomAttribute<LoadRoleAttribute>().ComponetType;
            
            RoleInstanceComponentBase roleInstance = (RoleInstanceComponentBase)Activator.CreateInstance(type, role, player);
            
            role.EnableRole(player);
            //roleInstance.OnAdd();
            
            RoleInstances.Add(player, roleInstance);
        }
        
        public static void AddRole(this Player player, RoleBase role) {
            if (role == null)
                return;
            
            Type type = role.GetType().GetCustomAttribute<LoadRoleAttribute>().ComponetType;
            
            RoleInstanceComponentBase roleInstance = (RoleInstanceComponentBase)Activator.CreateInstance(type, role, player);
            
            role.EnableRole(player);
            
            RoleInstances.Add(player, roleInstance);
        }
        
        public static void RemoveRole(this Player player) {
            for (;;) {
                RoleInstanceComponentBase roleInstance = RoleInstances.TryGetValue(player, out var role) ? role : null;
                if (roleInstance == null)
                    return;
            
                roleInstance.OnRemove();
                roleInstance.Role.DisableRole(player);
            
                RoleInstances.Remove(player);
            }
        }

        public static RoleInstanceComponentBase GetRole(this Player player) {
            return RoleInstances.TryGetValue(player, out var role) ? role : null;
        }
    }
}