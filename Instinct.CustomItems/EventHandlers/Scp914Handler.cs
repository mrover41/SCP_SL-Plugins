using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using LabApi.Events.Arguments.Scp914Events;
using LabApi.Events.CustomHandlers;
using Scp914;
using UnityEngine;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class Scp914Handler : CustomEventsHandler
{
    public override void OnScp914ProcessingInventoryItem(Scp914ProcessingInventoryItemEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Item, out CustomItemBase cur_item))
            return;
        CustomItemEvents.OnProcessingItem(cur_item, ev.Player, ev.Item, ev.KnobSetting, ev.IsAllowed);
        cur_item.OnProcessingItem(ev.Player, ev.Item, ev.KnobSetting, ev.IsAllowed);
    }

    public override void OnScp914ProcessingPickup(Scp914ProcessingPickupEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Pickup, out CustomItemBase cur_item))
            return;
        CustomItemEvents.OnProcessingPickup(cur_item, ev.Pickup, ev.KnobSetting, ev.NewPosition, ev.IsAllowed);
        cur_item.OnProcessingPickup(ev.Pickup, ev.KnobSetting, ev.NewPosition, ev.IsAllowed);
    }
}
