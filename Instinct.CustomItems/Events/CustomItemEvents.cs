using Instinct.CustomItems.Items;
using InventorySystem.Items;
using InventorySystem.Items.Pickups;
using Scp914;
using UnityEngine;

namespace Instinct.CustomItems.Events;

/// <summary>
/// Events for calling methods for <see cref="CustomItemBase"/>.
/// </summary>
public static class CustomItemEvents
{
    public static event Action<CustomItemBase>? Registered;
    public static event Action<CustomItemBase>? Unregistered;
    public static event Action<CustomItemBase>? NewCreated;
    public static event Action<CustomItemBase, Pickup>? ParsePickup;
    public static event Action<CustomItemBase, Item>? ParseItem;
    public static event Action<CustomItemBase>? Distribute;
    public static event Action<CustomItemBase, Player, Item?, Item?, bool>? Changed;
    public static event Action<CustomItemBase, Player, Item?, Item?, bool, bool>? Changing;
    public static event Action<CustomItemBase, Player, Pickup>? Dropped;
    public static event Action<CustomItemBase, Player, Item, bool, bool>? Dropping;
    public static event Action<CustomItemBase, Player, Pickup>? Searched;
    public static event Action<CustomItemBase, Player, Pickup, bool>? Searching;
    public static event Action<CustomItemBase, Player, Item>? Picked;
    public static event Action<CustomItemBase, Player, Pickup, bool>? Picking;
    public static event Action<CustomItemBase, Player, Pickup, Rigidbody>? Threw;
    public static event Action<CustomItemBase, Player, Pickup, Rigidbody, bool>? Throwing;
    public static event Action<CustomItemBase, Player, Item, Scp914KnobSetting, bool>? ProcessingItem;
    public static event Action<CustomItemBase, Pickup, Scp914KnobSetting, Vector3, bool>? ProcessingPickup;
    public static event Action<CustomItemBase, Player, ItemBase?, ItemPickupBase>? Removed;

    public static void OnRegistered(CustomItemBase customItem) 
        => Registered?.Invoke(customItem);
    public static void OnUnregistered(CustomItemBase customItem) 
        => Unregistered?.Invoke(customItem);
    public static void OnNewCreated(CustomItemBase customItem) 
        => NewCreated?.Invoke(customItem);
    public static void OnParsePickup(CustomItemBase customItem, Pickup pickup) 
        => ParsePickup?.Invoke(customItem, pickup);
    public static void OnParseItem(CustomItemBase customItem, Item item) 
        => ParseItem?.Invoke(customItem, item);
    public static void OnDistribute(CustomItemBase customItem) 
        => Distribute?.Invoke(customItem);
    public static void OnChanged(CustomItemBase? customItem, Player player, Item? oldItem, Item? newItem, bool changedToThisItem) 
        => Changed?.Invoke(customItem, player, oldItem, newItem, changedToThisItem);
    public static void OnChanging(CustomItemBase? customItem, Player player, Item? oldItem, Item? newItem, bool changedToThisItem, bool isAllowed)
        => Changing?.Invoke(customItem, player, oldItem, newItem, changedToThisItem, isAllowed);
    public static void OnDropped(CustomItemBase? customItem, Player player, Pickup pickup) 
        => Dropped?.Invoke(customItem, player, pickup);
    public static void OnDropping(CustomItemBase? customItem, Player player, Item item, bool isThrow, bool isAllowed)
        => Dropping?.Invoke(customItem, player, item, isThrow, isAllowed);
    public static void OnSearched(CustomItemBase? customItem, Player player, Pickup pickup) 
        => Searched?.Invoke(customItem, player, pickup);
    public static void OnSearching(CustomItemBase? customItem, Player player, Pickup pickup, bool isAllowed) 
        => Searching?.Invoke(customItem, player, pickup, isAllowed);
    public static void OnPicked(CustomItemBase? customItem, Player player, Item? item) 
        => Picked?.Invoke(customItem, player, item);
    public static void OnPicking(CustomItemBase? customItem, Player player, Pickup pickup, bool isAllowed) 
        => Picking?.Invoke(customItem, player, pickup, isAllowed);
    public static void OnThrew(CustomItemBase? customItem, Player player, Pickup pickup, Rigidbody rigidbody) 
        => Threw?.Invoke(customItem, player, pickup, rigidbody);
    public static void OnThrowing(CustomItemBase? customItem, Player player, Pickup pickup, Rigidbody rigidbody, bool isAllowed) 
        => Throwing?.Invoke(customItem, player, pickup, rigidbody, isAllowed);
    public static void OnProcessingItem(CustomItemBase customItem, Player player, Item item, Scp914KnobSetting knobSetting, bool isAllowed) 
        => ProcessingItem?.Invoke(customItem, player, item, knobSetting, isAllowed);
    public static void OnProcessingPickup(CustomItemBase customItem, Pickup pickup, Scp914KnobSetting knobSetting, Vector3 newPosition, bool isAllowed) 
        => ProcessingPickup?.Invoke(customItem,  pickup, knobSetting, newPosition, isAllowed);
    public static void OnRemoved(CustomItemBase customItem, Player player, ItemBase? itemBase, ItemPickupBase? itemPickupBase) 
        => Removed?.Invoke(customItem, player, itemBase, itemPickupBase);
}
