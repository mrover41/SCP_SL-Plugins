using InventorySystem.Items.ThrowableProjectiles;

namespace Instinct.CustomItems.Overrides;

/// <summary>
/// Override class for <see cref="TimeGrenade"/>.
/// </summary>
public class TimeGrenadeOverride : IOverride<TimeGrenade>
{
    /// <summary>
    /// Changes <see cref="TimeGrenade._fuseTime"/>.
    /// </summary>
    public float FuseTime;

    /// <inheritdoc/>
    public virtual Type OverrideType => typeof(TimeGrenade);

    /// <inheritdoc/>
    public virtual void Apply(ref TimeGrenade classToOverride)
    {
        classToOverride._fuseTime = this.FuseTime;
    }

    /// <inheritdoc/>
    public virtual void Apply(ref object classToOverride)
    {
        if (classToOverride.GetType() != this.OverrideType)
            return;
        TimeGrenade overrides = (TimeGrenade)classToOverride;
        this.Apply(ref overrides);
    }
}
