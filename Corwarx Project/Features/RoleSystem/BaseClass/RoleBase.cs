using System;
using System.Collections.Generic;
using Corwarx_Project.Features.RoleSystem.Containers;
using Exiled.API.Features;

namespace Corwarx_Project.Features.RoleSystem.BaseClass {
    public abstract class RoleBase {
        protected static List<Player> Players = new List<Player>();
        public int ID { get; protected set; }
        public RoleBase(RoleConfig config) {
        }

        internal void EnableRole(Player player) {
            Players.Add(player);
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
