using InventorySystem.Items.Firearms.Modules.Scp127;

namespace Instinct.CustomItems.Overrides;

/// <summary>
/// Override class for <see cref="Scp127HumeModule"/>
/// </summary>
public class Scp127HumeModuleOverride : IOverride<Scp127HumeModule>
{
    /// <summary>
    /// Helps to ovverride <see cref="Scp127HumeModule._maxPerTier"/>
    /// </summary>
    public Dictionary<Scp127Tier, float> TierToMaxShield = null;

    /// <inheritdoc/>
    public Type OverrideType => typeof(Scp127HumeModule);

    /// <inheritdoc/>
    public void Apply(ref Scp127HumeModule classToOverride)
    {
        if (this.TierToMaxShield == null)
            return;
        classToOverride._maxPerTier = [.. this.TierToMaxShield.Select(x => new Scp127HumeModule.MaxHumeTierPair() { Tier = x.Key, MaxShield = x.Value })];
    }

    /// <inheritdoc/>
    public void Apply(ref object classToOverride)
    {
        if (classToOverride is not Scp127HumeModule)
            return;
        Scp127HumeModule overrides = (Scp127HumeModule)classToOverride;
        this.Apply(ref overrides);
    }
}
