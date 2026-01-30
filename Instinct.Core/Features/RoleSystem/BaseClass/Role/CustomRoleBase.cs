using Instinct.Core.Features.RoleSystem.BaseClass.Spawn;
using Instinct.Core.Features.RoleSystem.Containers;

namespace Instinct.Core.Features.RoleSystem.BaseClass.Role {
    public abstract class CustomRoleBase(RoleConfig config) {
        private static readonly List<Player> Players = [];
        
        public readonly RoleConfig RoleConfig = config;
        public readonly List<SpawnConditionBase> SpawnConditions = [];

        internal void EnableRole(Player player) {
            player.SetRole(this.RoleConfig.RoleTypeId);
            Players.Add(player);
            player.ClearInventory();

            List<ItemType>? roleConfigItems = this.RoleConfig.Items;
            if (roleConfigItems != null)
                foreach (ItemType type in roleConfigItems) {
                    player.AddItem(type);
                }

            List<Type>? roleConfigCustomItems = this.RoleConfig.CustomItems;
            if (roleConfigCustomItems != null)
                foreach (Type customItem in roleConfigCustomItems) {
                    //foreach (CustomItem item in CustomItem.Get(customItem)) {
                    //    item.Give(player);
                    //}
                    
                    // use ours citems in future
                }

            this.OnAdd(player);
        }

        internal void DisableRole(Player player) {
            if (!Players.Contains(player))
                return;
            
            Players.Remove(player);
            this.OnRemove(player);
        }
        
        protected virtual void OnAdd(Player player) { }

        protected virtual void OnRemove(Player player) { }
    }
}
