using InventorySystem.Items.Firearms.Modules.Scp127;

namespace Instinct.CustomItems.Items;

/// <summary>
/// Custom <see cref="Scp127Firearm"/> base.
/// </summary>
public abstract class CustomScp127Base : CustomFirearmBase
{
    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item is not Scp127Firearm)
            throw new ArgumentException("scp127Firearm must not be null!");
    }

    /// <summary>
    /// The <paramref name="scp127Firearm"/> that gained <paramref name="experienceGain"/> amount of experience.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/></param>
    /// <param name="experienceGain">How many experience gained</param>
    public virtual void OnGainExperience(Scp127Firearm scp127Firearm, float experienceGain)
    {
        Logger.Debug($"OnGainExperience {scp127Firearm.Serial} {experienceGain}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// The <paramref name="scp127Firearm"/> that gaining <paramref name="experienceGain"/> amount of experience.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/></param>
    /// <param name="experienceGain">How many experience gained</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnGainingExperience(Scp127Firearm scp127Firearm, float experienceGain, bool isAllowed)
    {
        Logger.Debug($"OnGainingExperience {scp127Firearm.Serial} {experienceGain}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// The <paramref name="scp127Firearm"/> that leveled up to tier <paramref name="tier"/>.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/> item</param>
    /// <param name="tier">The <see cref="Scp127Tier"/> to level up</param>
    public virtual void OnLevelUp(Scp127Firearm scp127Firearm, Scp127Tier tier)
    {
        Logger.Debug($"OnLevelUp {scp127Firearm.Serial} {tier}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// The <paramref name="scp127Firearm"/> that leveling up to tier <paramref name="tier"/>.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/> item</param>
    /// <param name="tier">The <see cref="Scp127Tier"/> to level up</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnLevellingUp(Scp127Firearm scp127Firearm, Scp127Tier tier, bool isAllowed)
    {
        Logger.Debug($"OnLevellingUp {scp127Firearm.Serial} {tier}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// The <paramref name="scp127Firearm"/> that talked.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/></param>
    /// <param name="voiceLine">The <see cref="Scp127VoiceLinesTranslation"/> will play.</param>
    /// <param name="priority">The voice line <see cref="Scp127VoiceTriggerBase.VoiceLinePriority"/>.</param>
    public virtual void OnTalked(Scp127Firearm scp127Firearm, Scp127VoiceLinesTranslation voiceLine, Scp127VoiceTriggerBase.VoiceLinePriority priority)
    {
        Logger.Debug($"OnTalked {scp127Firearm.Serial} {voiceLine} {priority}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// The <paramref name="scp127Firearm"/> that talking.
    /// </summary>
    /// <param name="scp127Firearm">The <see cref="Scp127Firearm"/></param>
    /// <param name="voiceLine">The <see cref="Scp127VoiceLinesTranslation"/> will play.</param>
    /// <param name="priority">The voice line <see cref="Scp127VoiceTriggerBase.VoiceLinePriority"/>.</param>
    /// <param name="isAllowed">Can allow this action.</param>
    public virtual void OnTalking(Scp127Firearm scp127Firearm, Scp127VoiceLinesTranslation voiceLine, Scp127VoiceTriggerBase.VoiceLinePriority priority, bool isAllowed)
    {
        Logger.Debug($"OnTalking {scp127Firearm.Serial} {voiceLine} {priority}", ItemPlugin.Instance!.Config!.Debug);
    }
}
