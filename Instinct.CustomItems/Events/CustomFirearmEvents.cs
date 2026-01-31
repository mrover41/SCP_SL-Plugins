using Instinct.CustomItems.Items;
using PlayerStatsSystem;

namespace Instinct.CustomItems.Events;

/// <summary>
/// Events for calling methods for <see cref="CustomFirearmBase"/>.
/// </summary>
public static class CustomFirearmEvents
{
    public static event Action<CustomFirearmBase, Player, FirearmItem, bool>? Aim;
    public static event Action<CustomFirearmBase, Player, FirearmItem>? DryFired;
    public static event Action<CustomFirearmBase, Player, FirearmItem, bool>? DryFiring;
    public static event Action<CustomFirearmBase, Player, FirearmItem>? Reloaded;
    public static event Action<CustomFirearmBase, Player, FirearmItem, bool>? Reloading;
    public static event Action<CustomFirearmBase, Player, FirearmItem>? Shot;
    public static event Action<CustomFirearmBase, Player, FirearmItem, bool>? Shooting;
    public static event Action<CustomFirearmBase, Player, FirearmItem, bool>? ToggledFlashlight;
    public static event Action<CustomFirearmBase, Player, FirearmItem, bool, bool>? TogglingFlashlight;
    public static event Action<CustomFirearmBase, Player, FirearmItem>? Unloaded;
    public static event Action<CustomFirearmBase, Player, FirearmItem, bool>? Unloading;
    public static event Action<CustomFirearmBase, Player, Player, FirearmDamageHandler>? Hurt;
    public static event Action<CustomFirearmBase, Player, Player, FirearmDamageHandler, bool>? Hurting;
    public static event Action<CustomFirearmBase, Player, FirearmItem, uint, uint>? ChangedAttachments;
    public static event Action<CustomFirearmBase, Player, FirearmItem, uint, uint, bool>? ChangingAttachments;

    public static void OnAim(CustomFirearmBase customItem, Player player, FirearmItem weapon, bool aiming) 
        => Aim?.Invoke(customItem, player, weapon, aiming);
    public static void OnDryFired(CustomFirearmBase customItem, Player player, FirearmItem weapon) 
        => DryFired?.Invoke(customItem, player, weapon);
    public static void OnDryFiring(CustomFirearmBase customItem, Player player, FirearmItem weapon, bool isAllowedHelper)
        => DryFiring?.Invoke(customItem, player, weapon, isAllowedHelper);
    public static void OnReloaded(CustomFirearmBase customItem, Player player, FirearmItem weapon) 
        => Reloaded?.Invoke(customItem, player, weapon);
    public static void OnReloading(CustomFirearmBase customItem, Player player, FirearmItem weapon, bool isAllowedHelper) 
        => Reloading?.Invoke(customItem, player, weapon, isAllowedHelper);
    public static void OnShot(CustomFirearmBase customItem, Player player, FirearmItem weapon)
        => Shot?.Invoke(customItem, player, weapon);
    public static void OnShooting(CustomFirearmBase customItem, Player player, FirearmItem weapon, bool isAllowedHelper) 
        => Shooting?.Invoke(customItem, player, weapon, isAllowedHelper);
    public static void OnToggledFlashlight(CustomFirearmBase customItem, Player player, FirearmItem weapon, bool newState) 
        => ToggledFlashlight?.Invoke(customItem, player, weapon, newState);
    public static void OnTogglingFlashlight(CustomFirearmBase customItem, Player player, FirearmItem weapon, bool newState, bool isAllowedHelper) 
        => TogglingFlashlight?.Invoke(customItem, player, weapon, newState, isAllowedHelper);
    public static void OnUnloaded(CustomFirearmBase customItem, Player player, FirearmItem weapon)
        => Unloaded?.Invoke(customItem, player, weapon);
    public static void OnUnloading(CustomFirearmBase customItem, Player player, FirearmItem weapon, bool isAllowedHelper) 
        => Unloading?.Invoke(customItem, player, weapon, isAllowedHelper);
    public static void OnHurt(CustomFirearmBase? customItem, Player player, Player attacker, FirearmDamageHandler firearmDamage)
        => Hurt?.Invoke(customItem, player, attacker, firearmDamage);
    public static void OnHurting(CustomFirearmBase? customItem, Player player, Player attacker, FirearmDamageHandler firearmDamage, bool isAllowedHelper)
        => Hurting?.Invoke(customItem, player, attacker, firearmDamage, isAllowedHelper);
    public static void OnChangedAttachments(CustomFirearmBase customItem, Player player, FirearmItem weapon, uint oldAttachments, uint newAttachments) 
        => ChangedAttachments?.Invoke(customItem, player, weapon, oldAttachments, newAttachments);
    public static void OnChangingAttachments(CustomFirearmBase customItem, Player player, FirearmItem weapon, uint oldAttachments, uint newAttachments, bool isAllowedHelper) 
        => ChangingAttachments?.Invoke(customItem, player, weapon, oldAttachments, newAttachments, isAllowedHelper);
}
