using System;
using System.Collections.Generic;
using Corwarx_Project.Features.RoleSystem.BaseClass.Spawn;
using Corwarx_Project.Features.RoleSystem.Containers;
using LabApi.Features.Wrappers;

namespace Corwarx_Project.Features.RoleSystem.BaseClass.Role {
    public abstract class RoleBase {
        protected static List<Player> Players = new List<Player>();
        
        public readonly RoleConfig RoleConfig;
        public readonly List<SpawnConditionBase> SpawnConditions = new List<SpawnConditionBase>();
        public RoleBase(RoleConfig config) {
            RoleConfig = config;
        }

        internal void EnableRole(Player player) {
            player.Role.Set(RoleConfig.RoleTypeId);
            Players.Add(player);
            player.ClearInventory();
            
            foreach (ItemType type in RoleConfig.Items) {
                player.AddItem(type);
            }

            foreach (Type customItem in RoleConfig.CustomItems) {
                foreach (CustomItem item in CustomItem.Get(customItem)) {
                    item.Give(player);
                }
            }
            OnAdd(player);
        }

        internal void DisableRole(Player player) {
            if (!Players.Contains(player))
                return;
            
            Players.Remove(player);
            OnRemove(player);
        }
        
        protected virtual void OnAdd(Player player) {
            
        }

        protected virtual void OnRemove(Player player) {
            
        }
    }
}
