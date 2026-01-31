using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class ArmorHandler : CustomEventsHandler
{
    public override void OnPlayerPickingUpArmor(PlayerPickingUpArmorEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.BodyArmorPickup, out CustomItemBase? curItem))
            return;
        CustomItemEvents.OnPicking(curItem, ev.Player, ev.BodyArmorPickup, ev.IsAllowed);
        curItem?.OnPicking(ev.Player, ev.BodyArmorPickup, ev.IsAllowed);
    }

    public override void OnPlayerPickedUpArmor(PlayerPickedUpArmorEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.BodyArmorItem, out CustomItemBase? curItem))
            return;
        CustomItemEvents.OnPicked(curItem, ev.Player, ev.BodyArmorItem);
        curItem?.OnPicked(ev.Player, ev.BodyArmorItem);
    }

    public override void OnPlayerSearchingArmor(PlayerSearchingArmorEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.BodyArmorPickup, out CustomItemBase? curItem))
            return;
        CustomItemEvents.OnSearching(curItem, ev.Player, ev.BodyArmorPickup, ev.IsAllowed);
        curItem?.OnSearching(ev.Player, ev.BodyArmorPickup, ev.IsAllowed);
    }

    public override void OnPlayerSearchedArmor(PlayerSearchedArmorEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.BodyArmorPickup, out CustomItemBase? curItem))
            return;
        CustomItemEvents.OnSearched(curItem, ev.Player, ev.BodyArmorPickup);
        curItem?.OnSearched(ev.Player, ev.BodyArmorPickup);
    }
}
