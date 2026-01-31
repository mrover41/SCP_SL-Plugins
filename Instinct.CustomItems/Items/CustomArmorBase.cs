using System.ComponentModel;
using Instinct.CustomItems.Extensions;
using InventorySystem.Items.Armor;

namespace Instinct.CustomItems.Items;

/// <summary>
/// Custom Armor Base for <see cref="ItemCategory.Armor"/>
/// </summary>
public abstract class CustomArmorBase : CustomItemBase
{
    /// <summary>
    /// Currently not used ingame.
    /// Range: 0.0f to 100f
    /// </summary>
    public virtual int HelmetEfficacy { get; } = 0;

    /// <summary>
    /// Used to alter efficacy for 939 Claw and Explosion Damage
    /// Range: 0.0f to 100f
    /// </summary>
    public virtual int VestEfficacy { get; } = 0;

    /// <summary>
    /// Use to alter stamina usage.
    /// Range: 1f to 2f
    /// </summary>
    public virtual int StaminaUseMultiplier { get; } = 0;

    /// <summary>
    /// Use to alter movement speed.
    /// Range: 0.0f to 1f
    /// </summary>
    public virtual int MovementSpeedMultiplier { get; } = 0;

    /// <summary>
    /// List of Ammo limits this item changes/provide.
    /// </summary>
    [Description("If null do not change any limit. Otherwise changes limits to it. Make sure you only select Ammo otherwise will be skipped")]
    public virtual List<BodyArmor.ArmorAmmoLimit> AmmoLimits { get; } = [];

    /// <summary>
    /// List of <see cref="ItemCategory"/> limits this item changes/provide.
    /// </summary>
    [Description("If null do not change any limit. Otherwise changes limits to it")]
    public virtual List<BodyArmor.ArmorCategoryLimitModifier> CategoryLimits { get; } = [];

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Category != ItemCategory.Armor)
            throw new ArgumentOutOfRangeException(nameof(item), item.Type, "Invalid Armor type.");
        if (item is not BodyArmorItem body)
            throw new ArgumentException("Body must not be null!");
        
        body.Base.HelmetEfficacy = this.HelmetEfficacy;
        body.Base.VestEfficacy = this.VestEfficacy;
        body.Base._staminaUseMultiplier = this.StaminaUseMultiplier;
        body.Base._movementSpeedMultiplier = this.MovementSpeedMultiplier;
        
        List<BodyArmor.ArmorAmmoLimit> validLimits = new(this.AmmoLimits.Count);
        validLimits.AddRange(this.AmmoLimits.Where(limiter => limiter.AmmoType.IsAmmo()));
        
        body.Base.AmmoLimits = [.. validLimits];
        body.Base.CategoryLimits = [.. this.CategoryLimits];
    }
}
