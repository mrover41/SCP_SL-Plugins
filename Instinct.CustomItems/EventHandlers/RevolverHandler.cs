using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class RevolverHandler : CustomEventsHandler
{
    public override void OnPlayerSpinningRevolver(PlayerSpinningRevolverEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Revolver, out CustomRevolverBase cur_item))
            return;
        CustomRevolverEvents.OnSpinning(cur_item, ev.Player, ev.Revolver, ev.IsAllowed);
        cur_item.OnSpinning(ev.Player, ev.Revolver, ev.IsAllowed);
    }

    public override void OnPlayerSpinnedRevolver(PlayerSpinnedRevolverEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Revolver, out CustomRevolverBase cur_item))
            return;
        CustomRevolverEvents.OnSpinned(cur_item, ev.Player, ev.Revolver);
        cur_item.OnSpinned(ev.Player, ev.Revolver);
    }
}