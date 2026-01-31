using Instinct.CustomItems.Helpers;
using Instinct.CustomItems.Interfaces;
using InventorySystem.Items;
using InventorySystem.Items.Autosync;
using InventorySystem.Items.Pickups;
using MEC;
using Microsoft.EntityFrameworkCore.Internal;
using Scp914;
using UnityEngine;

namespace Instinct.CustomItems.Items;

/// <summary>
/// Custom <see cref="Item"/> base
/// </summary>
public abstract class CustomItemBase
{
    internal const float UnregisterTime = 0.3f;
    /// <summary>
    /// Action to show custom hint. Can be used with any hint framework or even disabling it (null).
    /// </summary>
    public Action<Player, string>? HintShow = (player, hint) => player.SendHint(hint);

    /// <summary>
    /// Name of your custom item.
    /// </summary>
    public abstract string CustomItemName { get; set; }

    /// <summary>
    /// Item description for admins/players.
    /// </summary>
    public abstract string Description { get; set; }

    /// <summary>
    /// <see cref="ItemType"/> to be made.
    /// </summary>
    public abstract ItemType Type { get; }

    /// <summary>
    /// Name of your custom item to display to others.
    /// </summary>
    public virtual string DisplayName { get; set; } = "";

    /// <summary>
    /// Gets the new weight of the <see cref="Pickup"/>
    /// </summary>
    public virtual float Weight { get; } = float.NaN;

    /// <summary>
    /// Overrides a to show a custom picked up show details
    /// </summary>
    public virtual bool OverrideShowPickedUpHint { get; set; } = ItemPlugin.Instance!.Config!.ShowPickedUpHint;

    /// <summary>
    /// Overrides the hint for showing custom picked up details
    /// </summary>
    public virtual string OverridePickedUpHint { get; set; } = ItemPlugin.Instance.Config!.PickedUpHint;

    /// <summary>
    /// Overrides a to show a custom selected show details
    /// </summary>
    public virtual bool OverrideShowSelectHint { get; set; } = ItemPlugin.Instance.Config!.ShowSelectedHint;

    /// <summary>
    /// Overrides the hint for showing custom selected details
    /// </summary>
    public virtual string OverrideSelectedHint { get; set; } = ItemPlugin.Instance.Config!.SelectedHint;

    /// <summary>
    /// Called once when this instance is registered.
    /// </summary>
    public virtual void OnRegistered()
    {
        Logger.Debug($"OnRegistered {this.GetType()} {this.CustomItemName}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// Called once when this instance is unregistered.
    /// </summary>
    public virtual void OnUnRegistered()
    {
        Logger.Debug($"OnUnRegistered {this.GetType()} {this.CustomItemName}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// Called when the New Item created for this Type.
    /// </summary>
    public virtual void OnNewCreated()
    {
        Logger.Debug($"OnNewCreated {this.GetType()} {this.CustomItemName}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// Parsing <paramref name="item"/> to this Custom Item.
    /// </summary>
    /// <param name="item">A custom item.</param>
    public virtual void Parse(Item item)
    {
        Logger.Debug($"Parse {item.Serial}", ItemPlugin.Instance!.Config!.Debug);
        Logger.Debug(string.Join("\n", item.Base.gameObject.GetComponents<Component>().Select(x => x.name).ToArray()), ItemPlugin.Instance.Config!.PrintComponentOnChange);
        if (this is IModuleChangable changeable && item.Base is ModularAutosyncItem modularAutosync && modularAutosync != null)
            modularAutosync.ApplyChange(changeable);
        Logger.Debug(string.Join("\n", item.Base.gameObject.GetComponents<Component>().Select(x => x.name).ToArray()), ItemPlugin.Instance.Config!.PrintComponentOnChange);
    }

    /// <summary>
    /// Parsing <paramref name="pickup"/> to this custom item.
    /// </summary>
    /// <param name="pickup">A Custom Pickup</param>
    public virtual void Parse(Pickup pickup)
    {
        Logger.Debug($"Parse {pickup.Serial}", ItemPlugin.Instance!.Config!.Debug);
        if (!float.IsNaN(this.Weight))
            pickup.Weight = this.Weight;
    }

    /// <summary>
    /// Called when <see cref="LabApi.Events.Handlers.ServerEvents.MapGenerated"/> runs for every already made instance.
    /// </summary>
    public virtual void OnDistribute()
    {
        Logger.Debug($"OnDistribute {this.GetType()} {this.CustomItemName}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> changed to/from this Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="oldItem"></param>
    /// <param name="newItem"></param>
    /// <param name="changedToThisItem">Is player selected item or unselected it.</param>
    public virtual void OnChanged(Player player, Item? oldItem, Item? newItem, bool changedToThisItem)
    {
        Logger.Debug($"OnChanged {player.PlayerId} {oldItem?.Serial} {newItem?.Serial} {changedToThisItem}", ItemPlugin.Instance!.Config!.Debug);
        if (changedToThisItem && this.OverrideShowSelectHint)
            this.HintShow?.Invoke(player, string.Format(this.OverrideSelectedHint, this.DisplayName, this.Description));
    }

    /// <summary>
    /// This <paramref name="player"/> changing to/from this Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="oldItem"></param>
    /// <param name="newItem"></param>
    /// <param name="changedToThisItem">Is player selected item or unselected it.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnChanging(Player player, Item? oldItem, Item? newItem, bool changedToThisItem, bool isAllowed)
    {
        Logger.Debug($"OnChanging {player.PlayerId} {oldItem?.Serial} {newItem?.Serial} {changedToThisItem}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who currently dropped to current Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="pickup"></param>
    public virtual void OnDropped(Player player, Pickup pickup)
    {
        Logger.Debug($"OnDropped {player.PlayerId} {pickup.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who currently dropping to current Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="item"></param>
    /// <param name="isThrow">Can allow throw item from inventory.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnDropping(Player player, Item item, bool isThrow, bool isAllowed)
    {
        Logger.Debug($"OnDropping {player.PlayerId} {item.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who picked up the current Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="pickup"></param>
    public virtual void OnSearched(Player player, Pickup pickup)
    {
        Logger.Debug($"OnSearched {player.PlayerId} {pickup.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who searching the current Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function.</param>
    /// <param name="pickup">The pickup searching.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnSearching(Player player, Pickup pickup, bool isAllowed)
    {
        Logger.Debug($"OnSearching {player.PlayerId} {pickup.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who picked up the current Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="item">The item has been picked up.</param>
    public virtual void OnPicked(Player player, Item item)
    {
        Logger.Debug($"OnPicked {player.PlayerId} {item.Serial}", ItemPlugin.Instance!.Config!.Debug);
        if (this.OverrideShowPickedUpHint)
            this.HintShow?.Invoke(player, string.Format(this.OverridePickedUpHint, this.DisplayName, this.Description));
    }

    /// <summary>
    /// This <paramref name="player"/> who picking up the current Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function.</param>
    /// <param name="pickup">The pickup picking up</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnPicking(Player player, Pickup pickup, bool isAllowed)
    {
        Logger.Debug($"OnPicking {player.PlayerId} {pickup.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who threw up the current Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="pickup"></param>
    /// <param name="rigidbody">The rigidbody for the <see cref="Pickup"/></param>
    public virtual void OnThrew(Player player, Pickup pickup, Rigidbody rigidbody)
    {
        Logger.Debug($"OnThrew {player.PlayerId} {rigidbody}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who throwing the current Custom Item.
    /// </summary>
    /// <param name="player">Player who called this function.</param>
    /// <param name="pickup">The pickup to throw.</param>
    /// <param name="rigidbody">The rigidbody for the <paramref name="pickup"/></param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnThrowing(Player player, Pickup pickup, Rigidbody rigidbody, bool isAllowed)
    {
        Logger.Debug($"OnThrowing {player.PlayerId} {pickup.Serial} {rigidbody}", ItemPlugin.Instance!.Config!.Debug);
        if (!float.IsNaN(this.Weight))
            pickup.Weight = this.Weight;
    }

    /// <summary>
    /// Called when <paramref name="player"/> is processing <paramref name="item"/> on <paramref name="knobSetting"/> setting at 914.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="item">The currently processing item.</param>
    /// <param name="knobSetting">The know setting value.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnProcessingItem(Player player, Item item, Scp914KnobSetting knobSetting, bool isAllowed)
    {
        Logger.Debug($"OnProcessingItem {player.PlayerId} {item.Serial} {knobSetting}", ItemPlugin.Instance!.Config!.Debug);
        isAllowed = false;
    }

    /// <summary>
    /// Called when a <paramref name="pickup"/> is processing on <paramref name="knobSetting"/> setting at 914.
    /// </summary>
    /// <param name="pickup">The currently processing pickup.</param>
    /// <param name="knobSetting">The know setting value.</param>
    /// <param name="newPosition">New position for the pickup.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnProcessingPickup(Pickup pickup, Scp914KnobSetting knobSetting, Vector3 newPosition, bool isAllowed)
    {
        Logger.Debug($"OnProcessingPickup {pickup.Serial} {knobSetting}", ItemPlugin.Instance!.Config!.Debug);
        isAllowed = false;
    }

    /// <summary>
    /// This <paramref name="player"/> who removed the current Custom Item.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="itemBase">ItemBase</param>
    /// <param name="itemPickupBase">itemPickupBase</param>
    public virtual void OnRemoved(Player player, ItemBase? itemBase, ItemPickupBase? itemPickupBase)
    {
        Logger.Debug($"OnRemoved {player.PlayerId} {itemBase is null} {itemPickupBase is null}", ItemPlugin.Instance!.Config!.Debug);
        if (itemBase is not null && itemPickupBase is null)
        {
            ushort serial = itemBase.ItemSerial;
            Timing.CallDelayed(UnregisterTime, () =>
            {
                CustomItems.SerialToCustomItem.Remove(serial);
            });

        }
    }
}
