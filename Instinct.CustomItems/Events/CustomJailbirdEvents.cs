using Instinct.CustomItems.Items;

namespace Instinct.CustomItems.Events;

public static class CustomJailbirdEvents
{
    public static event Action<CustomJailbirdBase, Player, JailbirdItem, InventorySystem.Items.Jailbird.JailbirdMessageType, bool, bool, bool>? ProcessingJailbirdMessage;
    public static event Action<CustomJailbirdBase, Player, JailbirdItem, InventorySystem.Items.Jailbird.JailbirdMessageType>? ProcessedJailbirdMessage;

    public static void OnProcessingJailbirdMessage(CustomJailbirdBase customItem, Player player, JailbirdItem jailbirdItem, InventorySystem.Items.Jailbird.JailbirdMessageType message, bool allowInspectHelper, bool allowAttackHelper, bool isAllowedHelper)
        => ProcessingJailbirdMessage?.Invoke(customItem, player, jailbirdItem, message, allowInspectHelper, allowAttackHelper, isAllowedHelper);

    public static void OnProcessedJailbirdMessage(CustomJailbirdBase? customItem, Player player, JailbirdItem jailbirdItem, InventorySystem.Items.Jailbird.JailbirdMessageType message)
        => ProcessedJailbirdMessage?.Invoke(customItem, player, jailbirdItem, message);
}
