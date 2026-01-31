using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class FirearmHandler : CustomEventsHandler
{
    #region DryFire
    public override void OnPlayerDryFiringWeapon(PlayerDryFiringWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnDryFiring(cur_item, ev.Player, ev.FirearmItem, ev.IsAllowed);
        cur_item.OnDryFiring(ev.Player, ev.FirearmItem, ev.IsAllowed);
    }
    public override void OnPlayerDryFiredWeapon(PlayerDryFiredWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnDryFired(cur_item, ev.Player, ev.FirearmItem);
        cur_item.OnDryFired(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Aim
    public override void OnPlayerAimedWeapon(PlayerAimedWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnAim(cur_item, ev.Player, ev.FirearmItem, ev.Aiming);
        cur_item.OnAim(ev.Player, ev.FirearmItem, ev.Aiming);
    }
    #endregion
    #region Reload
    public override void OnPlayerReloadingWeapon(PlayerReloadingWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnReloading(cur_item, ev.Player, ev.FirearmItem, ev.IsAllowed);
        cur_item.OnReloading(ev.Player, ev.FirearmItem, ev.IsAllowed);
    }
    public override void OnPlayerReloadedWeapon(PlayerReloadedWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnReloaded(cur_item, ev.Player, ev.FirearmItem);
        cur_item.OnReloaded(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Shoot
    public override void OnPlayerShootingWeapon(PlayerShootingWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnShooting(cur_item, ev.Player, ev.FirearmItem, ev.IsAllowed);
        cur_item.OnShooting(ev.Player, ev.FirearmItem, ev.IsAllowed);
    }
    public override void OnPlayerShotWeapon(PlayerShotWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnShot(cur_item, ev.Player, ev.FirearmItem);
        cur_item.OnShot(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Unload
    public override void OnPlayerUnloadingWeapon(PlayerUnloadingWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnUnloading(cur_item, ev.Player, ev.FirearmItem, ev.IsAllowed);
        cur_item.OnUnloading(ev.Player, ev.FirearmItem, ev.IsAllowed);
    }
    public override void OnPlayerUnloadedWeapon(PlayerUnloadedWeaponEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnUnloaded(cur_item, ev.Player, ev.FirearmItem);
        cur_item.OnUnloaded(ev.Player, ev.FirearmItem);
    }
    #endregion
    #region Toggle Flashlight
    public override void OnPlayerTogglingWeaponFlashlight(PlayerTogglingWeaponFlashlightEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnTogglingFlashlight(cur_item, ev.Player, ev.FirearmItem, ev.NewState, ev.IsAllowed);
        cur_item.OnTogglingFlashlight(ev.Player, ev.FirearmItem, ev.NewState, ev.IsAllowed);
    }
    public override void OnPlayerToggledWeaponFlashlight(PlayerToggledWeaponFlashlightEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnToggledFlashlight(cur_item, ev.Player, ev.FirearmItem, ev.NewState);
        cur_item.OnToggledFlashlight(ev.Player, ev.FirearmItem, ev.NewState);
    }
    #endregion
    #region Attachments
    public override void OnPlayerChangingAttachments(PlayerChangingAttachmentsEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnChangingAttachments(cur_item, ev.Player, ev.FirearmItem, ev.OldAttachments, ev.NewAttachments, ev.IsAllowed);
        cur_item.OnChangingAttachments(ev.Player, ev.FirearmItem, ev.OldAttachments, ev.NewAttachments, ev.IsAllowed);
    }

    public override void OnPlayerChangedAttachments(PlayerChangedAttachmentsEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.FirearmItem, out CustomFirearmBase cur_item))
            return;
        CustomFirearmEvents.OnChangedAttachments(cur_item, ev.Player, ev.FirearmItem, ev.OldAttachments, ev.NewAttachments);
        cur_item.OnChangedAttachments(ev.Player, ev.FirearmItem, ev.OldAttachments, ev.NewAttachments);
    }
    #endregion
}
