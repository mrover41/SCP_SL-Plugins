using InventorySystem.Items.Firearms.Modules;

namespace Instinct.CustomItems.Overrides;

/// <summary>
/// Override class for <see cref="DisruptorHitregModule"/>
/// </summary>
public class DisruptorHitregModuleOverride : IOverride<DisruptorHitregModule>
{
    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._singleShotBaseDamage"/>.
    /// </summary>
    public float SingleShotBaseDamage;

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._singleShotFalloffDistance"/>.
    /// </summary>
    public float SingleShotFalloffDistance;

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._singleShotDivisionPerTarget"/>.
    /// </summary>
    public float SingleShotDivisionPerTarget;

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._singleShotThickness"/>.
    /// </summary>
    public float SingleShotThickness;

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._singleShotExplosionSettings"/>.
    /// </summary>
    public ExplosionGrenadeOverride SingleShotExplosionSettings = new();

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._rapidFireBaseDamage"/>.
    /// </summary>
    public float RapidFireBaseDamage;

    /// <summary>
    /// Changes <see cref="DisruptorHitregModule._rapidFireFalloffDistance"/>.
    /// </summary>
    public float RapidFireFalloffDistance;

    /// <inheritdoc/>
    public Type OverrideType => typeof(DisruptorHitregModule);

    /// <inheritdoc/>
    public void Apply(ref DisruptorHitregModule disruptorHitregModule)
    {
        disruptorHitregModule._singleShotBaseDamage = this.SingleShotBaseDamage;
        disruptorHitregModule._singleShotFalloffDistance = this.SingleShotFalloffDistance;
        disruptorHitregModule._singleShotDivisionPerTarget =this.SingleShotDivisionPerTarget;
        disruptorHitregModule._singleShotThickness = this.SingleShotThickness;
        this.SingleShotExplosionSettings.Apply(ref disruptorHitregModule._singleShotExplosionSettings);
        disruptorHitregModule._rapidFireBaseDamage = this.RapidFireBaseDamage;
        disruptorHitregModule._rapidFireFalloffDistance = this.RapidFireFalloffDistance;
    }

    /// <inheritdoc/>
    public void Apply(ref object classToOverride)
    {
        if (classToOverride is not DisruptorHitregModule)
            return;
        DisruptorHitregModule overrides = (DisruptorHitregModule)classToOverride;
        this.Apply(ref overrides);
    }
}
