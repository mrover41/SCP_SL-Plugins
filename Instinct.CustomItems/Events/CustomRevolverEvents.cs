using Instinct.CustomItems.Items;

namespace Instinct.CustomItems.Events;

public static class CustomRevolverEvents
{
    public static event Action<CustomRevolverBase, Player, RevolverFirearm>? Spinned;
    public static event Action<CustomRevolverBase, Player, RevolverFirearm, bool>? Spinning;

    public static void OnSpinned(CustomRevolverBase custom, Player player, RevolverFirearm revolver)
        => Spinned?.Invoke(custom, player, revolver);

    public static void OnSpinning(CustomRevolverBase custom, Player player, RevolverFirearm revolver, bool isAllowed)
        => Spinning?.Invoke(custom, player, revolver, isAllowed);
}
