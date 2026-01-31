using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using InventorySystem.Items.Firearms.Modules.Scp127;
using LabApi.Events.Arguments.Scp127Events;
using LabApi.Events.CustomHandlers;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class Scp127Handler : CustomEventsHandler
{
    public override void OnScp127GainingExperience(Scp127GainingExperienceEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        CustomScp127Events.OnGainingExperience(cur_item, ev.Scp127Item, ev.ExperienceGain, ev.IsAllowed);
        cur_item.OnGainingExperience(ev.Scp127Item, ev.ExperienceGain, ev.IsAllowed);
    }

    public override void OnScp127GainExperience(Scp127GainExperienceEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        CustomScp127Events.OnGainExperience(cur_item, ev.Scp127Item, ev.ExperienceGain);
        cur_item.OnGainExperience(ev.Scp127Item, ev.ExperienceGain);
    }

    public override void OnScp127LevellingUp(Scp127LevellingUpEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        CustomScp127Events.OnLevellingUp(cur_item, ev.Scp127Item, ev.Tier, ev.IsAllowed);
        cur_item.OnLevellingUp(ev.Scp127Item, ev.Tier, ev.IsAllowed);
    }

    public override void OnScp127LevelUp(Scp127LevelUpEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        CustomScp127Events.OnLevelUp(cur_item, ev.Scp127Item, ev.Tier);
        cur_item.OnLevelUp(ev.Scp127Item, ev.Tier);
    }

    public override void OnScp127Talking(Scp127TalkingEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        CustomScp127Events.OnTalking(cur_item, ev.Scp127Item, ev.VoiceLine, ev.Priority, ev.IsAllowed);
        cur_item.OnTalking(ev.Scp127Item, ev.VoiceLine, ev.Priority, ev.IsAllowed);
    }

    public override void OnScp127Talked(Scp127TalkedEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.Scp127Item, out CustomScp127Base cur_item))
            return;
        CustomScp127Events.OnTalked(cur_item, ev.Scp127Item, ev.VoiceLine, ev.Priority);
        cur_item.OnTalked(ev.Scp127Item, ev.VoiceLine, ev.Priority);
    }
}