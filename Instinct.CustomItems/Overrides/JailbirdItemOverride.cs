using JailbirdItem = InventorySystem.Items.Jailbird.JailbirdItem;

namespace Instinct.CustomItems.Overrides;

/// <summary>
/// Override class for <see cref="JailbirdItem"/>
/// </summary>
public class JailbirdItemOverride : IOverride<JailbirdItem>
{
    /// <summary>
    /// Changes <see cref="JailbirdItem._meleeDelay"/>.
    /// </summary>
    public float MeleeDelay;

    /// <summary>
    /// Changes <see cref="JailbirdItem._meleeCooldown"/>.
    /// </summary>
    public float MeleeCooldown;

    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeDuration"/>.
    /// </summary>
    public float ChargeDuration;

    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeReadyTime"/>.
    /// </summary>
    public float ChargeReadyTime;

    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeMovementSpeedMultiplier"/>.
    /// </summary>
    public float ChargeMovementSpeedMultiplier;

    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeMovementSpeedLimiter"/>.
    /// </summary>
    public float ChargeMovementSpeedLimiter;

    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeCancelVelocitySqr"/>.
    /// </summary>
    public float ChargeCancelVelocitySqr;

    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeAutoengageTime"/>.
    /// </summary>
    public float ChargeAutoEngageTime;

    /// <summary>
    /// Changes <see cref="JailbirdItem._chargeDetectionDelay"/>.
    /// </summary>
    public float ChargeDetectionDelay;

    /// <summary>
    /// Changes <see cref="JailbirdItem._brokenRemoveTime"/>.
    /// </summary>
    public float BrokenRemoveTime;

    /// <summary>
    /// How much damage should the melee attack deal
    /// </summary>
    public float DamageMelee;

    /// <summary>
    /// How much damage should the charge attack deal
    /// </summary>
    public float DamageCharge;

    /// <summary>
    /// How long in seconds the 'concussed' effect is applied for on attacked targets
    /// </summary>
    public float ConcussionDuration;

    /// <summary>
    /// How long in seconds the 'flashed' effect is applied for on attacked targets
    /// </summary>
    public float FlashedDuration;

    /// <inheritdoc/>
    public Type OverrideType => typeof(JailbirdItem);

    /// <inheritdoc/>
    public void Apply(ref JailbirdItem jailbirdItem)
    {
        jailbirdItem.MeleeDamage = this.DamageMelee;
        jailbirdItem._chargeDamage = this.DamageCharge;
        jailbirdItem._concussionDuration = this.ConcussionDuration;
        jailbirdItem._flashedDuration = this.FlashedDuration;
        jailbirdItem._meleeDelay = this.MeleeDelay;
        jailbirdItem._meleeCooldown = this.MeleeCooldown;
        jailbirdItem._chargeDuration = this.ChargeDuration;
        jailbirdItem._chargeReadyTime = this.ChargeReadyTime;
        jailbirdItem._chargeMovementSpeedMultiplier = this.ChargeMovementSpeedMultiplier;
        jailbirdItem._chargeMovementSpeedLimiter = this.ChargeMovementSpeedLimiter;
        jailbirdItem._chargeCancelVelocitySqr = this.ChargeCancelVelocitySqr;
        jailbirdItem._chargeAutoengageTime = this.ChargeAutoEngageTime;
        jailbirdItem._chargeDetectionDelay = this.ChargeDetectionDelay;
        jailbirdItem._brokenRemoveTime = this.BrokenRemoveTime;
    }

    /// <inheritdoc/>
    public void Apply(ref object classToOverride)
    {
        if (classToOverride is not JailbirdItem overrides)
            return;
        this.Apply(ref overrides);
    }
}
