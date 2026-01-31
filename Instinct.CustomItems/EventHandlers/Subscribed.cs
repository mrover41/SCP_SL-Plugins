using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using InventorySystem.Items;
using InventorySystem.Items.MicroHID.Modules;
using InventorySystem.Items.Pickups;
using InventorySystem.Items.ThrowableProjectiles;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class Subscribed
{
    internal static void OnItemRemoved(ReferenceHub hub, ItemBase itemBase, ItemPickupBase itemPickupBase)
    {
        CustomItemBase? customItem = CustomItems.GetCustomItem<CustomItemBase>(Item.Get(itemBase));
        CustomItemBase? customItem2 = CustomItems.GetCustomItem<CustomItemBase>(Pickup.Get(itemPickupBase));
        Player player = Player.Get(hub);
        CustomItemEvents.OnRemoved(customItem, player, itemBase, itemPickupBase);
        customItem?.OnRemoved(player, itemBase, itemPickupBase);
        if (customItem != null && customItem != customItem2)
        {
            CustomItemEvents.OnRemoved(customItem2, player, itemBase, itemPickupBase);
            customItem2?.OnRemoved(player, itemBase, itemPickupBase);
        }
            
    }

    internal static void ProjectileSpawned(ThrownProjectile projectile)
    {
        Projectile labProjectile = Projectile.Get(projectile);
        if (!CustomItems.TryGetCustomItem(labProjectile, out CustomThrowableBase cur_item))
            return;
        CustomThrowableEvents.OnProjectileSpawned(cur_item, labProjectile);
        cur_item.OnProjectileSpawned(labProjectile);
    }

    internal static void PhaseChanged(ushort Serial, MicroHidPhase phase)
    {
        if (!CustomItems.TryGetCustomItem(Serial, out CustomMicroHidBase cur_item))
            return;
        if (Item.Get(Serial) is not MicroHIDItem microHIDItem)
            return;
        CustomMicroHIDEvents.OnPhaseChanged(cur_item, microHIDItem, phase);
        cur_item.OnPhaseChanged(microHIDItem, phase);
    }


    internal static void BrokenSyncModule_OnBroken(ushort Serial)
    {
        if (!CustomItems.TryGetCustomItem(Serial, out CustomMicroHidBase cur_item))
            return;
        if (Item.Get(Serial) is not MicroHIDItem microHIDItem)
            return;
        CustomMicroHIDEvents.OnBroken(cur_item, microHIDItem);
        cur_item.OnBroken(microHIDItem);
    }
}
