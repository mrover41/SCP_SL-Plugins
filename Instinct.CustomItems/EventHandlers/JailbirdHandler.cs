using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using InventorySystem.Items.Jailbird;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class JailbirdHandler : CustomEventsHandler
{
    public override void OnPlayerProcessingJailbirdMessage(PlayerProcessingJailbirdMessageEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.JailbirdItem, out CustomJailbirdBase? curItem))
            return;
        CustomJailbirdEvents.OnProcessingJailbirdMessage(curItem, ev.Player, ev.JailbirdItem, ev.Message, ev.AllowAttack, ev.AllowAttack, ev.IsAllowed);
        curItem.OnProcessingJailbirdMessage(ev.Player, ev.JailbirdItem, ev.Message, ev.AllowInspect, ev.AllowAttack, ev.IsAllowed);
    }

    public override void OnPlayerProcessedJailbirdMessage(PlayerProcessedJailbirdMessageEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.JailbirdItem, out CustomJailbirdBase? curItem))
            return;
        CustomJailbirdEvents.OnProcessedJailbirdMessage(curItem, ev.Player, ev.JailbirdItem, ev.Message);
        curItem.OnProcessedJailbirdMessage(ev.Player, ev.JailbirdItem, ev.Message);
    }
}
