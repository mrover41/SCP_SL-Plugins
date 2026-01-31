using Instinct.CustomItems.Extensions;
using Instinct.CustomItems.Helpers;
using Instinct.CustomItems.Interfaces;
using Instinct.CustomItems.Overrides;
using InventorySystem.Items.Firearms.Attachments;
using PlayerStatsSystem;

namespace Instinct.CustomItems.Items;

/// <summary>
/// Custom <see cref="FirearmItem"/> base.
/// </summary>
public abstract class CustomFirearmBase : CustomItemBase, IModuleChangable
{
    /// <inheritdoc/>
    public virtual Dictionary<ModuleChanger, Type> ReplaceModules { get; } = [];

    /// <inheritdoc/>
    public virtual List<ModuleChanger> AddModules { get; } = [];

    /// <summary>
    /// The <see cref="FirearmItem"/>'s Damage.
    /// </summary>
    public virtual float Damage { get; } = 0;

    /// <summary>
    /// Override certain Loggerasses.
    /// </summary>
    public virtual List<IOverride> Overrides { get; } = [];

    /// <summary>
    /// Sets the Attachment of the gun.
    /// </summary>
    public virtual List<AttachmentName> AttachmentNames { get; } = [];

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item is not FirearmItem firearmItem)
            throw new ArgumentException("FirearmItem must not be null!");
        firearmItem.AttachmentsCode = firearmItem.GetCodeFromAttachmentNamesRaw([..this.AttachmentNames]);
        
        foreach (IOverride? @override in this.Overrides) {
            if (firearmItem.Base.TryGetModule(@override.OverrideType, out object module, false))
                @override.Apply(ref module);
        }
    }

    /// <inheritdoc/>
    public override void Parse(Pickup pickup)
    {
        base.Parse(pickup);
        if (pickup is not FirearmPickup firearmPickup)
            throw new ArgumentException("FirearmPickup must not be null!");
        firearmPickup.AttachmentCode = FirearmItem.Get(firearmPickup.Base.Template).GetCodeFromAttachmentNamesRaw([.. this.AttachmentNames]);
    }

    /// <summary>
    /// This <paramref name="player"/> who aimed.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="aiming">Is aiming or not</param>
    public virtual void OnAim(Player player, FirearmItem weapon, bool aiming)
    {
        Logger.Debug($"OnAim {player.PlayerId} {weapon.Serial} {aiming}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who dry fired.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    public virtual void OnDryFired(Player player, FirearmItem weapon)
    {
        Logger.Debug($"OnDryFired {player.PlayerId} {weapon.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who dry firing.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnDryFiring(Player player, FirearmItem weapon, bool isAllowedHelper)
    {
        Logger.Debug($"OnDryFiring {player.PlayerId} {weapon.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who reloaded.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    public virtual void OnReloaded(Player player, FirearmItem weapon)
    {
        Logger.Debug($"OnReloaded {player.PlayerId} {weapon.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who reloading.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnReloading(Player player, FirearmItem weapon, bool isAllowedHelper)
    {
        Logger.Debug($"OnReloading {player.PlayerId} {weapon.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who shot.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    public virtual void OnShot(Player player, FirearmItem weapon)
    {
        Logger.Debug($"OnShot {player.PlayerId} {weapon.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who shooting.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnShooting(Player player, FirearmItem weapon, bool isAllowedHelper)
    {
        Logger.Debug($"OnShooting {player.PlayerId} {weapon.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who toggled the flashlight.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="newState">State of flashlight</param>
    public virtual void OnToggledFlashlight(Player player, FirearmItem weapon, bool newState)
    {
        Logger.Debug($"OnToggledFlashlight {player.PlayerId} {weapon.Serial} {newState}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who toggling the flashlight.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="newState">State of flashlight</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnTogglingFlashlight(Player player, FirearmItem weapon, bool newState, bool isAllowedHelper)
    {
        Logger.Debug($"OnAim {player.PlayerId} {weapon.Serial} {newState}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who unloaded.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    public virtual void OnUnloaded(Player player, FirearmItem weapon)
    {
        Logger.Debug($"OnUnloaded {player.PlayerId} {weapon.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who unloading.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="weapon">The weapon</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnUnloading(Player player, FirearmItem weapon, bool isAllowedHelper)
    {
        Logger.Debug($"OnUnloading {player.PlayerId} {weapon.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who got hurt.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="attacker">The Player who attacker the <paramref name="player"/></param>
    /// <param name="firearmDamage">Firearm Damage</param>
    public virtual void OnHurt(Player player, Player attacker, FirearmDamageHandler firearmDamage)
    {
        Logger.Debug($"OnHurt {player.PlayerId} {attacker.PlayerId} {firearmDamage.Damage}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who got hurt.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="attacker">The Player who attacker the <paramref name="player"/></param>
    /// <param name="firearmDamage">Firearm Damage</param>
    /// <param name="isAllowedHelper">Can allow this action.</param>
    public virtual void OnHurting(Player player, Player attacker, FirearmDamageHandler firearmDamage, bool isAllowedHelper)
    {
        Logger.Debug($"OnHurting (Before) {player.PlayerId} {attacker.PlayerId} {firearmDamage.Damage}", ItemPlugin.Instance!.Config!.Debug);
        firearmDamage.Damage = this.Damage;
        Logger.Debug($"OnHurting (After) {player.PlayerId} {attacker.PlayerId} {firearmDamage.Damage}", ItemPlugin.Instance.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> changed <paramref name="firearmItem"/> attachment from <paramref name="oldAttachments"/> to <paramref name="newAttachments"/>.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="firearmItem"></param>
    /// <param name="oldAttachments"></param>
    /// <param name="newAttachments"></param>
    public virtual void OnChangedAttachments(Player player, FirearmItem firearmItem, uint oldAttachments, uint newAttachments)
    {
        Logger.Debug($"OnChangedAttachments {player.PlayerId} {firearmItem.Serial} {oldAttachments} {newAttachments}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> changing <paramref name="firearmItem"/> attachment from <paramref name="oldAttachments"/> to <paramref name="newState"/>.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="firearmItem"></param>
    /// <param name="oldAttachments"></param>
    /// <param name="newState"></param>
    /// <param name="isAllowedHelper"></param>
    public virtual void OnChangingAttachments(Player player, FirearmItem firearmItem, uint oldAttachments, uint newState, bool isAllowedHelper)
    {
        Logger.Debug($"OnChangedAttachments {player.PlayerId} {firearmItem.Serial} {oldAttachments} {newState}", ItemPlugin.Instance!.Config!.Debug);
    }
}
