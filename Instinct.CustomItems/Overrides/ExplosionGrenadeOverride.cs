using InventorySystem.Items.ThrowableProjectiles;
using UnityEngine;

namespace Instinct.CustomItems.Overrides;

/// <summary>
/// Override class for <see cref="ExplosionGrenade"/>
/// </summary>
public class ExplosionGrenadeOverride : TimeGrenadeOverride, IOverride<ExplosionGrenade>
{
    /// <summary>
    /// Changes <see cref="ExplosionGrenade.DetectionMask"/>.
    /// </summary>
    public LayerMask? DetectionMask { get; } = null;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade.MaxRadius"/>.
    /// </summary>
    public float MaxRadius { get; } = 0;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade.ScpDamageMultiplier"/>.
    /// </summary>
    public float ScpDamageMultiplier { get; } = 0;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._playerDamageOverDistance"/>.
    /// </summary>
    public AnimationCurve? PlayerDamageOverDistance { get; } = null;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._effectDurationOverDistance"/>.
    /// </summary>
    public AnimationCurve? FffectDurationOverDistance { get; } = null;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._doorDamageOverDistance"/>.
    /// </summary>
    public AnimationCurve? DoorDamageOverDistance { get; } = null;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._shakeOverDistance"/>.
    /// </summary>
    public AnimationCurve? ShakeOverDistance { get; } = null;

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._burnedDuration"/>.
    /// </summary>
    public float BurnedDuration { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._deafenedDuration"/>.
    /// </summary>
    public float DeafenedDuration { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._concussedDuration"/>.
    /// </summary>
    public float ConcussedDuration { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._minimalDuration"/>.
    /// </summary>
    public float MinimalDuration { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._rigidbodyBaseForce"/>.
    /// </summary>
    public float RigidbodyBaseForce { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._rigidbodyLiftForce"/>.
    /// </summary>
    public float RigidbodyLiftForce { get; } = new();

    /// <summary>
    /// Changes <see cref="ExplosionGrenade._humeShieldMultipler"/>.
    /// </summary>
    public float HumeShieldMultipler { get; } = new();


    /// <inheritdoc/>
    public override Type OverrideType => typeof(ExplosionGrenade);

    /// <inheritdoc/>
    public void Apply(ref ExplosionGrenade classToOverride)
    {
        if (this.DetectionMask.HasValue)
            classToOverride.DetectionMask = this.DetectionMask.Value;
        classToOverride.MaxRadius = this.MaxRadius;
        classToOverride.ScpDamageMultiplier = this.ScpDamageMultiplier;
        if (this.PlayerDamageOverDistance != null)
            classToOverride._playerDamageOverDistance = this.PlayerDamageOverDistance;
        if (this.FffectDurationOverDistance != null)
            classToOverride._playerDamageOverDistance = this.FffectDurationOverDistance;
        if (this.DoorDamageOverDistance != null)
            classToOverride._doorDamageOverDistance = this.DoorDamageOverDistance;
        if (this.ShakeOverDistance != null)
            classToOverride._shakeOverDistance = this.ShakeOverDistance;
        classToOverride._burnedDuration = this.BurnedDuration;
        classToOverride._deafenedDuration = this.DeafenedDuration;
        classToOverride._concussedDuration = this.ConcussedDuration;
        classToOverride._minimalDuration = this.MinimalDuration;
        classToOverride._rigidbodyBaseForce = this.RigidbodyBaseForce;
        classToOverride._rigidbodyLiftForce = this.RigidbodyLiftForce;
        classToOverride._humeShieldMultipler = this.HumeShieldMultipler;
    }

    /// <inheritdoc/>
    public override void Apply(ref object classToOverride)
    {
        base.Apply(ref classToOverride);
        if (classToOverride is not ExplosionGrenade overrides)
            return;
        this.Apply(ref overrides);
    }
}
