using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using LabApi.Events.CustomHandlers;
using MEC;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class NonItemRelatedHandler : CustomEventsHandler
{
    public override void OnServerWaitingForPlayers()
    {
        CustomItems.ClearSerials();
        Timing.CallDelayed(3, () =>
        {
            // Map should be generated at this point
            foreach (CustomItemBase? item in CustomItems.CustomItemBaseList)
            {
                CustomItemEvents.OnDistribute(item);
                item.OnDistribute();
            }
        });
    }
}
