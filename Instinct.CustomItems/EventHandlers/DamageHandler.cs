using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;
using PlayerStatsSystem;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class DamageHandler : CustomEventsHandler
{
    public override void OnPlayerHurting(PlayerHurtingEventArgs ev)
    {
        if (ev.Attacker == null)
            return;
        if (ev.Attacker == ev.Player)
            return;
        if (ev.DamageHandler is not FirearmDamageHandler firearmDamageHandler)
            return;
        if (firearmDamageHandler.Firearm == null)
            return;
        if (!CustomItems.TryGetCustomItem(firearmDamageHandler.Firearm.ItemSerial, out CustomFirearmBase? curItem))
            return;
        CustomFirearmEvents.OnHurting(curItem, ev.Player, ev.Attacker, firearmDamageHandler, ev.IsAllowed);
        curItem?.OnHurting(ev.Player, ev.Attacker, firearmDamageHandler, ev.IsAllowed);
    }

    public override void OnPlayerHurt(PlayerHurtEventArgs ev)
    {
        if (ev.Attacker == null)
            return;
        if (ev.Attacker == ev.Player)
            return;
        if (ev.DamageHandler is not FirearmDamageHandler firearmDamageHandler)
            return;
        if (firearmDamageHandler.Firearm == null)
            return;
        if (!CustomItems.TryGetCustomItem(firearmDamageHandler.Firearm.ItemSerial, out CustomFirearmBase? curItem))
            return;
        CustomFirearmEvents.OnHurt(curItem, ev.Player, ev.Attacker, firearmDamageHandler);
        curItem?.OnHurt(ev.Player, ev.Attacker, firearmDamageHandler);
    }
}
