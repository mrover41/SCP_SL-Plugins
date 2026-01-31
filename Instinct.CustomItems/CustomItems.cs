using System.Reflection;
using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using InventorySystem;
using InventorySystem.Items;
using InventorySystem.Items.Pickups;
using UnityEngine;

namespace Instinct.CustomItems;

public static class CustomItems
{
    internal static readonly Dictionary<ushort, CustomItemBase> SerialToCustomItem = [];

    internal static readonly HashSet<CustomItemBase> CustomItemBaseList = [];

    public static T? CreateItem<T>() where T : CustomItemBase
    {
        CustomItemBase? cib = CustomItemBaseList.FirstOrDefault(x => x.GetType() == typeof(T));
        if (cib == null)
            return null;
        T newItem = (T)cib;
        CustomItemEvents.OnNewCreated(newItem);
        newItem.OnNewCreated();
        return newItem;
    }

    public static CustomItemBase? CreateItem(string itemName)
    {
        CustomItemBase? cib = CustomItemBaseList.FirstOrDefault(x => x.CustomItemName == itemName);
        if (cib == null)
            return null;
        CustomItemEvents.OnNewCreated(cib);
        cib.OnNewCreated();
        return cib;
    }
    
    public static Item? AddCustomItem<T>(Player player) where T : CustomItemBase
    {
        T? item = CreateItem<T>();
        return AddCustomItem(item, player);
    }

    public static Item? AddCustomItem(string customItemName, Player player)
    {
        CustomItemBase? customItemBase = CreateItem(customItemName);
        return AddCustomItem(customItemBase, player);
    }
    
    public static Item? AddCustomItem(this CustomItemBase? item, Player player)
    {
        if (item == null)
            return null;
        Item? itemBase = player.AddItem(item.Type);
        if (itemBase == null)
            return null;
        CustomItemEvents.OnParseItem(item, itemBase);
        item.Parse(itemBase);
        player.ReferenceHub.inventory.UserInventory.Items[itemBase.Serial] = itemBase.Base;
        SerialToCustomItem.Add(itemBase.Serial, item);
        return itemBase;
    }

    public static Item? AddCustomItem(this CustomItemBase? item, ReferenceHub hub)
    {
        if (item == null)
            return null;
        Item itemBase = Item.Get(hub.inventory.ServerAddItem(item.Type, ItemAddReason.AdminCommand));
        CustomItemEvents.OnParseItem(item, itemBase);
        item.Parse(itemBase);
        hub.inventory.UserInventory.Items[itemBase.Serial] = itemBase.Base;
        SerialToCustomItem.Add(itemBase.Serial, item);
        return itemBase;
    }

    public static Pickup? Spawn(string customItemName, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, bool shouldSpawn = true)
    {
        CustomItemBase? item = CreateItem(customItemName);
        return Spawn(item, position, rotation, scale, shouldSpawn);
    }

    public static Pickup? Spawn<T>(Vector3 position, Quaternion? rotation = null, Vector3? scale = null, bool shouldSpawn = true) where T : CustomItemBase
    {
        T? item = CreateItem<T>();
        return Spawn(item, position, rotation, scale, shouldSpawn);
    }
    
    public static Pickup? Spawn(this CustomItemBase? customItem, Vector3 position, Quaternion? rotation = null, Vector3? scale = null, bool shouldSpawn = true)
    {
        if (customItem == null)
            return null;
        if (rotation == null)
            rotation = Quaternion.identity;
        if (scale == null)
            scale = Vector3.one;
        Pickup? pickup = Pickup.Create(customItem.Type, position, rotation.Value, scale.Value);
        if (pickup == null)
            return null;
        if (shouldSpawn)
            pickup.Spawn();
        CustomItemEvents.OnParsePickup(customItem, pickup);
        customItem.Parse(pickup);
        SerialToCustomItem.Add(pickup.Serial, customItem);
        return pickup;
    }
    
    public static bool IsItemNameExist(string? itemName, StringComparison comparison = StringComparison.InvariantCulture)
    {
        if (string.IsNullOrEmpty(itemName))
            return false;
        return CustomItemBaseList.Any(x => x.CustomItemName.Equals(itemName, comparison));
    }

    public static bool IsCustom(this ushort serial) => SerialToCustomItem.ContainsKey(serial);

    public static bool IsCustom(this Item? item) => item != null && SerialToCustomItem.ContainsKey(item.Serial);

    public static bool IsCustom(this ItemBase? item) => item != null && SerialToCustomItem.ContainsKey(item.ItemSerial);

    public static bool IsCustom(this Pickup? item) => item != null && SerialToCustomItem.ContainsKey(item.Serial);

    public static bool IsCustom(this ItemPickupBase? item) => item != null && SerialToCustomItem.ContainsKey(item.Info.Serial);

    public static bool IsHoldingCustomItem(this Player? player)
    {
        if (player == null)
            return false;
        return IsCustom(player.CurrentItem);
    }
    
    public static T? GetCustomItem<T>(this Item? item) where T : CustomItemBase
    {
        if (item == null)
            return null;
        return GetCustomItem<T>(item.Serial);
    }

    public static T? GetCustomItem<T>(this Pickup? item) where T : CustomItemBase
    {
        if (item == null)
            return null;
        return GetCustomItem<T>(item.Serial);
    }

    public static T? GetCustomItem<T>(this Player player) where T : CustomItemBase
    {
        if (player.IsHost)
            return null;
        return GetCustomItem<T>(player.CurrentItem);
    }

    public static T? GetCustomItem<T>(this ushort serial) where T : CustomItemBase
    {
        if (serial == 0)
            return null;
        if (SerialToCustomItem.TryGetValue(serial, out CustomItemBase? customItem) && customItem is T customItemType)
            return customItemType;
        return null;
    }
    
    public static CustomItemBase? GetCustomItem(this Item? item)
    {
        if (item == null)
            return null;
        return GetCustomItem(item.Serial);
    }

    public static CustomItemBase? GetCustomItem(this ItemBase? item)
    {
        if (item == null)
            return null;
        return GetCustomItem(item.ItemSerial);
    }

    public static CustomItemBase? GetCustomItem(this Pickup? item)
    {
        if (item == null)
            return null;
        return GetCustomItem(item.Serial);
    }

    public static CustomItemBase? GetCustomItem(this ItemPickupBase? item)
    {
        if (item == null)
            return null;
        return GetCustomItem(item.Info.Serial);
    }

    public static CustomItemBase? GetCustomItem(this Player player)
    {
        if (player.IsHost)
            return null;
        return GetCustomItem(player.CurrentItem);
    }

    public static CustomItemBase? GetCustomItem(this ushort serial)
    {
        if (serial == 0)
            return null;
        if (SerialToCustomItem.TryGetValue(serial, out CustomItemBase? customItem))
            return customItem;
        return null;
    }
    
    public static bool TryGetCustomItem(this Player player, out CustomItemBase? customItem)
    {
        return TryGetCustomItem(player.CurrentItem, out customItem);
    }

    public static bool TryGetCustomItem(this Item? item, out CustomItemBase? customItem)
    {
        customItem = null;
        if (item == null)
            return false;
        return TryGetCustomItem(item.Serial, out customItem);
    }

    public static bool TryGetCustomItem(this Pickup? pickup, out CustomItemBase? customItem)
    {
        customItem = null;
        if (pickup == null)
            return false;
        return TryGetCustomItem(pickup.Serial, out customItem);
    }

    public static bool TryGetCustomItem(this ushort serial, out CustomItemBase? customItem)
    {
        return SerialToCustomItem.TryGetValue(serial, out customItem);
    }

    public static bool TryGetCustomItem<T>(this Player player, out T? customItem) where T : CustomItemBase
    {
        return TryGetCustomItem(player.CurrentItem, out customItem);
    }

    public static bool TryGetCustomItem<T>(this Item? item, out T? customItem) where T : CustomItemBase
    {
        customItem = null;
        if (item == null)
            return false;
        return TryGetCustomItem(item.Serial, out customItem);
    }

    public static bool TryGetCustomItem<T>(this Pickup? pickup, out T? customItem) where T : CustomItemBase
    {
        customItem = null;
        if (pickup == null)
            return false;
        return TryGetCustomItem(pickup.Serial, out customItem);
    }

    public static bool TryGetCustomItem<T>(this ushort serial, out T? customItem) where T : CustomItemBase
    {
        if (SerialToCustomItem.TryGetValue(serial, out CustomItemBase? customItemBase) && customItemBase is T customItemT)
        {
            customItem = customItemT;
            return true;
        }
        customItem = null;
        return false;
    }
    
    public static void RegisterCustomItems()
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        if (assembly == typeof(CustomItems).Assembly)
            return;
        List<Type> types = [.. assembly.GetTypes().
            Where(item =>
                !item.IsAbstract &&
                typeof(CustomItemBase).IsAssignableFrom(item)
                )];
        foreach (Type type in types)
        {
            RegisterCustomItem(type);
        }
    }

    public static void RegisterCustomItemsExcept(params Type[] exceptType)
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        if (assembly == typeof(CustomItems).Assembly)
            return;
        List<Type> types = [.. assembly.GetTypes().
            Where(item =>
                !item.IsAbstract &&
                typeof(CustomItemBase).IsAssignableFrom(item))];
        foreach (Type type in types)
        {
            if (exceptType.Contains(type))
                continue;
            RegisterCustomItem(type);
        }
    }

    public static void RegisterCustomItems(params Type[] types)
    {
        foreach (Type type in types)
        {
            RegisterCustomItem(type);
        }
    }

    public static void RegisterCustomItem(Type? type)
    {
        if (type == null)
            return;
        Logger.Debug(type, ItemPlugin.Instance!.Config!.Debug);
        CustomItemBase customItem = (CustomItemBase)Activator.CreateInstance(type);
        RegisterCustomItem(customItem);
    }

    public static void RegisterCustomItem(this CustomItemBase? customItemBase)
    {
        if (customItemBase == null)
            return;
        CustomItemEvents.OnRegistered(customItemBase);
        customItemBase.OnRegistered();
        CustomItemBaseList.Add(customItemBase);
    }
    
    public static void UnRegisterCustomItems(params Type[] types)
    {
        foreach (Type type in types)
        {
            UnRegisterCustomItem(type);
        }
    }

    public static void UnRegisterCustomItem(Type type)
    {
        CustomItemBaseList.RemoveWhere(x => x.GetType() == type);
    }
    
    public static void UnRegisterCustomItem(this CustomItemBase? customItemBase)
    {
        if (customItemBase == null)
            return;
        CustomItemEvents.OnUnregistered(customItemBase);
        customItemBase.OnUnRegistered();
        CustomItemBaseList.Remove(customItemBase);
    }

    public static void UnRegisterCustomItems()
    {
        Assembly assembly = Assembly.GetCallingAssembly();
        List<Type> types = [.. assembly.GetTypes().Where(x => !x.IsAbstract).Where(item => item.BaseType != null && (item.BaseType == typeof(CustomItemBase) || item.BaseType.IsSubclassOf(typeof(CustomItemBase))))];
        foreach (CustomItemBase? item in CustomItemBaseList.Where(x => types.Contains(x.GetType())).ToList())
        {
            UnRegisterCustomItem(item);
        }
        SerialToCustomItem.Clear();
    }

    public static void UnRegisterAllCustomItems()
    {
        foreach (CustomItemBase? item in CustomItemBaseList.ToList())
        {
            UnRegisterCustomItem(item);
        }
        SerialToCustomItem.Clear();
    }

    public static void ClearSerials()
    {
        SerialToCustomItem.Clear();
    }
    
    public static void AddCustomItemToSerial(ushort serial, CustomItemBase? customItem)
    {
        if (serial == 0)
            return;
        if (customItem == null)
            return;
        if (SerialToCustomItem.ContainsKey(serial))
            return;
        SerialToCustomItem.Add(serial, customItem);
    }
}