using InventorySystem.Items.Firearms.Modules;

namespace Instinct.CustomItems.Overrides;

/// <summary>
/// Override class for <see cref="A7BurnEffectModule"/>.
/// </summary>
public class A7BurnEffectModuleOverride : IOverride<A7BurnEffectModule>
{
    /// <summary>
    /// Max duration for the Burned effect.
    /// </summary>
    public int MaxDuration;

    /// <summary>
    /// Per shot duration.
    /// </summary>
    public int PerShotDuration;

    /// <summary>
    /// Forward offset for checking the range.
    /// </summary>
    public float ForwardOffset;

    /// <summary>
    /// Radius for checking the hit range.
    /// </summary>
    public float Radius;

    /// <inheritdoc/>
    public Type OverrideType => typeof(A7BurnEffectModule);


    /// <inheritdoc/>
    public void Apply(ref A7BurnEffectModule burnEffectModule) {
        burnEffectModule._maxDuration = this.MaxDuration;
        burnEffectModule._perShotDuration = this.PerShotDuration;
        burnEffectModule._forwardOffset = this.ForwardOffset;
        burnEffectModule._radius = this.Radius;
    }

    /// <inheritdoc/>
    public void Apply(ref object classToOverride)
    {
        if (classToOverride is not A7BurnEffectModule overrides)
            return;
        this.Apply(ref overrides);
    }
}
