using Instinct.CustomItems.Events;
using Instinct.CustomItems.Items;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Events.CustomHandlers;

namespace Instinct.CustomItems.EventHandlers;

internal sealed class KeyCardItemHandler : CustomEventsHandler
{
    #region Interact Door
    public override void OnPlayerInteractingDoor(PlayerInteractingDoorEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeycardBase customKeyCardBase))
            return;
        CustomKeycardEvents.OnInteractingDoor(customKeyCardBase, ev.Player, item, ev.Door, ev.CanOpen, ev.IsAllowed);
        customKeyCardBase.OnInteractingDoor(ev.Player, item, ev.Door, ev.CanOpen, ev.IsAllowed);
    }

    public override void OnPlayerInteractedDoor(PlayerInteractedDoorEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeycardBase customKeyCardBase))
            return;
        CustomKeycardEvents.OnInteractedDoor(customKeyCardBase, ev.Player, item, ev.Door, ev.CanOpen);
        customKeyCardBase.OnInteractedDoor(ev.Player, item, ev.Door, ev.CanOpen);
    }
    #endregion
    #region Interact Generator
    public override void OnPlayerInteractingGenerator(PlayerInteractingGeneratorEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeycardBase customKeyCardBase))
            return;
        CustomKeycardEvents.OnInteractingGenerator(customKeyCardBase, ev.Player, item, ev.Generator, ev.ColliderId, ev.IsAllowed);
        customKeyCardBase.OnInteractingGenerator(ev.Player, item, ev.Generator, ev.ColliderId, ev.IsAllowed);
    }

    public override void OnPlayerInteractedGenerator(PlayerInteractedGeneratorEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeycardBase customKeyCardBase))
            return;
        CustomKeycardEvents.OnInteractedGenerator(customKeyCardBase, ev.Player, item, ev.Generator, ev.ColliderId);
        customKeyCardBase.OnInteractedGenerator(ev.Player, item, ev.Generator, ev.ColliderId);
    }
    #endregion
    #region Interact Locker
    public override void OnPlayerInteractingLocker(PlayerInteractingLockerEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeycardBase customKeyCardBase))
            return;
        CustomKeycardEvents.OnInteractingLocker(customKeyCardBase, ev.Player, item, ev.Locker, ev.Chamber, ev.CanOpen, ev.IsAllowed);
        customKeyCardBase.OnInteractingLocker(ev.Player, item, ev.Locker, ev.Chamber, ev.CanOpen, ev.IsAllowed);
    }

    public override void OnPlayerInteractedLocker(PlayerInteractedLockerEventArgs ev)
    {
        Item? item = ev.Player.CurrentItem;
        if (item == null)
            return;
        if (!CustomItems.TryGetCustomItem(item, out CustomKeycardBase customKeyCardBase))
            return;
        CustomKeycardEvents.OnInteractedLocker(customKeyCardBase, ev.Player, item, ev.Locker, ev.Chamber, ev.CanOpen);
        customKeyCardBase?.OnInteractedLocker(ev.Player, item, ev.Locker, ev.Chamber, ev.CanOpen);
    }
    #endregion
    #region Inspect Keycard
    public override void OnPlayerInspectingKeycard(PlayerInspectingKeycardEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.KeycardItem, out CustomKeycardBase cur_item))
            return;
        CustomKeycardEvents.OnInspectingKeycard(cur_item, ev.Player, ev.KeycardItem, ev.IsAllowed);
        cur_item.OnInspectingKeycard(ev.Player, ev.KeycardItem, ev.IsAllowed);
    }

    public override void OnPlayerInspectedKeycard(PlayerInspectedKeycardEventArgs ev)
    {
        if (!CustomItems.TryGetCustomItem(ev.KeycardItem, out CustomKeycardBase cur_item))
            return;
        CustomKeycardEvents.OnInspectedKeycard(cur_item, ev.Player, ev.KeycardItem);
        cur_item.OnInspectedKeycard(ev.Player, ev.KeycardItem);
    }
    #endregion
}
