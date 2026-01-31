using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class ThrowableItemHandler : CustomEventsHandler
{
    public override void OnPlayerThrowingProjectile(PlayerThrowingProjectileEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.ThrowableItem, out CustomThrowableBase? curItem))
            return;
        CustomThrowableEvents.OnThrowingProjectile(curItem, ev.Player, ev.ThrowableItem, ev.ProjectileSettings, ev.FullForce, ev.IsAllowed);
        curItem?.OnThrowingProjectile(ev.Player, ev.ThrowableItem, ev.ProjectileSettings, ev.FullForce, ev.IsAllowed);
    }

    public override void OnPlayerThrewProjectile(PlayerThrewProjectileEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.ThrowableItem, out CustomThrowableBase? curItem))
            return;
        CustomThrowableEvents.OnThrewProjectile(curItem, ev.Player, ev.ThrowableItem, ev.Projectile, ev.ProjectileSettings, ev.FullForce);
        curItem?.OnThrewProjectile(ev.Player, ev.ThrowableItem, ev.Projectile, ev.ProjectileSettings, ev.FullForce);
    }
}
