using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class CommonItemHandler : CustomEventsHandler
{
    #region Change
    public override void OnPlayerChangingItem(PlayerChangingItemEventArgs ev)
    {
        if (CustomItems.TryGetCustomItem(ev.OldItem, out CustomItemBase? prevItem))
        {
            CustomItemEvents.OnChanging(prevItem, ev.Player, ev.OldItem, ev.NewItem, false, ev.IsAllowed);
            prevItem?.OnChanging(ev.Player, ev.OldItem, ev.NewItem, false, ev.IsAllowed);
        }

        if (CustomItems.TryGetCustomItem(ev.NewItem, out CustomItemBase? curItem))
        {
            CustomItemEvents.OnChanging(curItem, ev.Player, ev.OldItem, ev.NewItem, true, ev.IsAllowed);
            curItem?.OnChanging(ev.Player, ev.OldItem, ev.NewItem, true, ev.IsAllowed);
        }
    }

    public override void OnPlayerChangedItem(PlayerChangedItemEventArgs ev)
    {
        if (CustomItems.TryGetCustomItem(ev.OldItem, out CustomItemBase? prevItem))
        {
            CustomItemEvents.OnChanged(prevItem, ev.Player, ev.OldItem, ev.NewItem, false);
            prevItem?.OnChanged(ev.Player, ev.OldItem, ev.NewItem, false);
        }

        if (CustomItems.TryGetCustomItem(ev.NewItem, out CustomItemBase? curItem))
        {
            CustomItemEvents.OnChanged(curItem, ev.Player, ev.OldItem, ev.NewItem, true);
            curItem?.OnChanged(ev.Player, ev.OldItem, ev.NewItem, true);
        }
    }
    #endregion

    #region Drop
    public override void OnPlayerDroppingItem(PlayerDroppingItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Item, out CustomItemBase? curItem))
            return;

        CustomItemEvents.OnDropping(curItem, ev.Player, ev.Item, ev.Throw, ev.IsAllowed);
        curItem?.OnDropping(ev.Player, ev.Item, ev.Throw, ev.IsAllowed);
    }

    public override void OnPlayerDroppedItem(PlayerDroppedItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase? curItem))
            return;

        CustomItemEvents.OnDropped(curItem, ev.Player, ev.Pickup);
        curItem?.OnDropped(ev.Player, ev.Pickup);
    }
    #endregion

    #region Pick
    public override void OnPlayerPickingUpItem(PlayerPickingUpItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase? curItem))
            return;

        CustomItemEvents.OnPicking(curItem, ev.Player, ev.Pickup, ev.IsAllowed);
        curItem?.OnPicking(ev.Player, ev.Pickup, ev.IsAllowed);
    }

    public override void OnPlayerPickedUpItem(PlayerPickedUpItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Item, out CustomItemBase? curItem))
            return;

        CustomItemEvents.OnPicked(curItem, ev.Player, ev.Item);
        curItem?.OnPicked(ev.Player, ev.Item);
    }
    #endregion

    #region Throw
    public override void OnPlayerThrowingItem(PlayerThrowingItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase? curItem))
            return;

        CustomItemEvents.OnThrowing(curItem, ev.Player, ev.Pickup, ev.Rigidbody, ev.IsAllowed);
        curItem?.OnThrowing(ev.Player, ev.Pickup, ev.Rigidbody, ev.IsAllowed);
    }

    public override void OnPlayerThrewItem(PlayerThrewItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase? curItem))
            return;

        CustomItemEvents.OnThrew(curItem, ev.Player, ev.Pickup, ev.Rigidbody);
        curItem?.OnThrew(ev.Player, ev.Pickup, ev.Rigidbody);
    }
    #endregion

    public override void OnPlayerSearchingPickup(PlayerSearchingPickupEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase? curItem))
            return;

        CustomItemEvents.OnSearching(curItem, ev.Player, ev.Pickup, ev.IsAllowed);
        curItem?.OnSearching(ev.Player, ev.Pickup, ev.IsAllowed);
    }

    public override void OnPlayerSearchedPickup(PlayerSearchedPickupEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase? curItem))
            return;

        CustomItemEvents.OnSearched(curItem, ev.Player, ev.Pickup);
        curItem?.OnSearched(ev.Player, ev.Pickup);
    }
}