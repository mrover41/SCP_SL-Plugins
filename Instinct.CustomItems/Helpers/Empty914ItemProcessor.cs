using LabApi.Features.Interfaces;
using Scp914;

namespace Instinct.CustomItems.Helpers;

/// <summary>
/// Empty processor for 914.
/// </summary>
public class Empty914ItemProcessor : IScp914ItemProcessor
{
    /// <inheritdoc/>
    public bool UsePickupMethodOnly => false;

    /// <inheritdoc/>
    public Scp914Result UpgradeItem(Scp914KnobSetting setting, Item item)
    {
        return new(item.Base);
    }

    /// <inheritdoc/>
    public Scp914Result UpgradePickup(Scp914KnobSetting setting, Pickup pickup)
    {
        return new(pickup.Base);
    }
}
