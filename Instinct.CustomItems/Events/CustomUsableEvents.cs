using Instinct.CustomItems.Items;

namespace Instinct.CustomItems.Events;

public static class CustomUsableEvents
{
    public static event Action<CustomUsableBase, Player, UsableItem>? Cancelled;
    public static event Action<CustomUsableBase, Player, UsableItem, bool>? Cancelling;
    public static event Action<CustomUsableBase, Player, UsableItem>? Used;
    public static event Action<CustomUsableBase, Player, UsableItem, bool>? Using;

    public static void OnCancelled(CustomUsableBase custom, Player player, UsableItem usableItem)
        => Cancelled?.Invoke(custom, player, usableItem);
    public static void OnCancelling(CustomUsableBase custom, Player player, UsableItem usableItem, bool isAllowed)
        => Cancelling?.Invoke(custom, player, usableItem, isAllowed);

    public static void OnUsed(CustomUsableBase custom, Player player, UsableItem usableItem)
        => Used?.Invoke(custom, player, usableItem);
    public static void OnUsing(CustomUsableBase custom, Player player, UsableItem usableItem, bool isAllowed)
        => Using?.Invoke(custom, player, usableItem, isAllowed);
}

