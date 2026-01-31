using InventorySystem.Items.Firearms.Modules.Scp127;

namespace Instinct.CustomItems.Overrides;

/// <summary>
/// Override class for <see cref="Scp127TierManagerModule"/>
/// </summary>
public class Scp127TierManagerModuleOverride : IOverride<Scp127TierManagerModule>
{
    /// <summary>
    /// Helps to ovverride <see cref="Scp127TierManagerModule.Thresholds"/>
    /// </summary>
    public Dictionary<Scp127Tier, float> TierToRequiredDamage = null;

    /// <inheritdoc/>
    public Type OverrideType => typeof(Scp127HumeModule);

    /// <inheritdoc/>
    public void Apply(ref Scp127TierManagerModule classToOverride)
    {
        if (this.TierToRequiredDamage == null)
            return;
        classToOverride.Thresholds = [.. this.TierToRequiredDamage.Select(x => new Scp127TierManagerModule.TierThreshold() { Tier = x.Key, RequiredDamage = x.Value })];
    }

    /// <inheritdoc/>
    public void Apply(ref object classToOverride)
    {
        if (classToOverride is not Scp127TierManagerModule)
            return;
        Scp127TierManagerModule overrides = (Scp127TierManagerModule)classToOverride;
        this.Apply(ref overrides);
    }
}
