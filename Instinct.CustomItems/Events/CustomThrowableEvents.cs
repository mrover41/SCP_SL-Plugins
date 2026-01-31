using Instinct.CustomItems.Items;
using PSettings = InventorySystem.Items.ThrowableProjectiles.ThrowableItem.ProjectileSettings;

namespace Instinct.CustomItems.Events;

public static class CustomThrowableEvents
{
    public static event Action<CustomThrowableBase, Player, ThrowableItem, Projectile, PSettings, bool>? ThrewProjectile;
    public static event Action<CustomThrowableBase, Player, ThrowableItem, PSettings, bool, bool>? ThrowingProjectile;
    public static event Action<CustomThrowableBase, Projectile>? ProjectileSpawned;

    public static void OnThrewProjectile(CustomThrowableBase? custom, Player player, ThrowableItem throwableItem, Projectile projectile, PSettings settings, bool fullForce)
        => ThrewProjectile?.Invoke(custom, player, throwableItem, projectile, settings, fullForce);

    public static void OnThrowingProjectile(CustomThrowableBase? custom, Player player, ThrowableItem throwableItem, PSettings settings, bool isFullForce, bool isAllowed)
        => ThrowingProjectile?.Invoke(custom, player, throwableItem, settings, isFullForce ,isAllowed);

    public static void OnProjectileSpawned(CustomThrowableBase curItem, Projectile labProjectile)
        => ProjectileSpawned?.Invoke(curItem, labProjectile);
}
