using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class UsableItemHandler : CustomEventsHandler
{
    #region Cancel
    public override void OnPlayerCancellingUsingItem(PlayerCancellingUsingItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.UsableItem, out CustomUsableBase cur_item))
            return;
        CustomUsableEvents.OnCancelling(cur_item, ev.Player, ev.UsableItem, ev.IsAllowed);
        cur_item?.OnCancelling(ev.Player, ev.UsableItem, ev.IsAllowed);
    }
    public override void OnPlayerCancelledUsingItem(PlayerCancelledUsingItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.UsableItem, out CustomUsableBase cur_item))
            return;
        CustomUsableEvents.OnCancelled(cur_item, ev.Player, ev.UsableItem);
        cur_item.OnCancelled(ev.Player, ev.UsableItem);
    }
    #endregion
    #region Use
    public override void OnPlayerUsingItem(PlayerUsingItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.UsableItem, out CustomUsableBase cur_item))
            return;
        CustomUsableEvents.OnUsing(cur_item, ev.Player, ev.UsableItem, ev.IsAllowed);
        cur_item?.OnUsing(ev.Player, ev.UsableItem, ev.IsAllowed);
    }
    public override void OnPlayerUsedItem(PlayerUsedItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.UsableItem, out CustomUsableBase cur_item))
            return;
        CustomUsableEvents.OnUsed(cur_item, ev.Player, ev.UsableItem);
        cur_item.OnUsed(ev.Player, ev.UsableItem);
    }
    #endregion
}
