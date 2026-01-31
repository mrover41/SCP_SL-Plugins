using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class CoinHandler : CustomEventsHandler
{
    public override void OnPlayerFlippingCoin(PlayerFlippingCoinEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.CoinItem, out CustomCoinBase? curItem))
            return;
        CustomCoinEvents.OnFlipping(curItem, ev.Player, ev.CoinItem, ev.IsTails, ev.IsAllowed);
        curItem?.OnFlipping(ev.Player, ev.CoinItem, ev.IsTails, ev.IsAllowed);
    }

    public override void OnPlayerFlippedCoin(PlayerFlippedCoinEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.CoinItem, out CustomCoinBase? curItem))
            return;
        CustomCoinEvents.OnFlipped(curItem, ev.Player, ev.CoinItem, ev.IsTails);
        curItem?.OnFlipped(ev.Player, ev.CoinItem, ev.IsTails);
    }
}