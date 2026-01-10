using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Corwarx_Project.Features.RoleSystem.Attributies;
using Corwarx_Project.Features.RoleSystem.BaseClass;
using Exiled.API.Features;

namespace Corwarx_Project.Features.RoleSystem.Managers {
    public static class RoleManager {
        public static List<RoleBase> Roles = new List<RoleBase>();
        public static List<RoleInstanceComponentBase> RoleInstances { get; private set; } = new List<RoleInstanceComponentBase>();
        
        public static void RegisterAllRoles(Assembly asm) {
            foreach (Type type in asm.GetTypes().Where(t => t.GetCustomAttribute<LoadRoleAttribute>() != null)) {
                Roles.Add(Activator.CreateInstance(type) as RoleBase);
                
                Log.Info($"Registered role {type.Name}");
            }
        }

        public static void AddRole(this Player player, int id) {
            RoleBase role = Roles.Find(x => x.RoleConfig.ID == id);
            if (role == null)
                return;
            
            Type type = role.GetType().GetCustomAttribute<LoadRoleAttribute>().ComponetType;
            
            RoleInstanceComponentBase roleInstance = (RoleInstanceComponentBase)Activator.CreateInstance(type, role, player);
            
            role.EnableRole(player);
            roleInstance.OnAdd();
            
            RoleInstances.Add(roleInstance);
        }
        
        public static void RemoveRole(this Player player) {
            for (;;) {
                RoleInstanceComponentBase roleInstance = RoleInstances.Find(x => x.Player == player);
                if (roleInstance == null)
                    continue;
            
                roleInstance.OnRemove();
                roleInstance.Role.DisableRole(player);
            
                RoleInstances.Remove(roleInstance);
            }
        }
    }
}