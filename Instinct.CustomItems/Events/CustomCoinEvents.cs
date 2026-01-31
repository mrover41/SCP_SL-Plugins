using Instinct.CustomItems.Items;

namespace Instinct.CustomItems.Events;

/// <summary>
/// Events for calling methods for <see cref="CustomCoinBase"/>.
/// </summary>
public static class CustomCoinEvents
{
    public static event Action<CustomCoinBase, Player, CoinItem, bool, bool>? Flipping;
    public static event Action<CustomCoinBase, Player, CoinItem, bool>? Flipped;

    public static void OnFlipping(CustomCoinBase? customItem, Player player, CoinItem coin, bool isTails, bool isAllowed)
        => Flipping?.Invoke(customItem, player, coin, isTails, isAllowed);

    public static void OnFlipped(CustomCoinBase? customItem, Player player, CoinItem coin, bool isTails)
        => Flipped?.Invoke(customItem, player, coin, isTails);
}