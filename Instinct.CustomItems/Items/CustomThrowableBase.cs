using InventorySystem.Items;
using PSettings = InventorySystem.Items.ThrowableProjectiles.ThrowableItem.ProjectileSettings;

namespace Instinct.CustomItems.Items;

/// <summary>
/// Custom <see cref="ThrowableItem"/> base.
/// </summary>
public abstract class CustomThrowableBase : CustomItemBase
{
    public virtual float FuzeTime { get; } = 10;

    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item is not ThrowableItem throwableItem)
            throw new ArgumentException("ThrowableItem must not be null!");
    }
    
    /// <summary>
    /// This <paramref name="player"/> who threw this projectile.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="throwableItem">The Custom Throwable Item</param>
    /// <param name="projectile">The new projectile object created.</param>
    /// <param name="settings">The projectile Settings</param>
    /// <param name="fullForce">Is used full force to throw</param>
    public virtual void OnThrewProjectile(Player player, ThrowableItem throwableItem, Projectile projectile, PSettings settings, bool fullForce)
    {
        Logger.Debug($"OnThrewProjectile {player.PlayerId} {throwableItem.Serial} {projectile.Serial} {settings} {fullForce}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// This <paramref name="player"/> who throwing this projectile.
    /// </summary>
    /// <param name="player">The Player who called this function.</param>
    /// <param name="throwableItem">The Custom Throwable Item</param>
    /// <param name="settings">The projectile Settings</param>
    /// <param name="isFullForce">Is using full force to throw</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnThrowingProjectile(Player player, ThrowableItem throwableItem, PSettings settings, bool isFullForce, bool isAllowed)
    {
        Logger.Debug($"OnThrowingProjectile {player.PlayerId} {throwableItem.Serial} {settings.ToString()} {isFullForce}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// Called when a new <paramref name="projectile"/> spawned.
    /// </summary>
    /// <param name="projectile"></param>
    public virtual void OnProjectileSpawned(Projectile projectile)
    {
        Logger.Debug($"OnProjectileSpawned {projectile}", ItemPlugin.Instance!.Config!.Debug);
    }
}
