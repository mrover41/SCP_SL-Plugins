using Instinct.CustomItems.Helpers;
using Instinct.CustomItems.Interfaces;
using InventorySystem.Items.MicroHID.Modules;

namespace Instinct.CustomItems.Items;

/// <summary>
/// Custom <see cref="MicroHIDItem"/> base.
/// </summary>
public abstract class CustomMicroHidBase : CustomItemBase, IModuleChangable
{
    /// <inheritdoc/>
    public virtual Dictionary<ModuleChanger, Type> ReplaceModules { get; } = [];
    /// <inheritdoc/>
    public virtual List<ModuleChanger> AddModules { get; } = [];

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Type != ItemType.MicroHID)
            throw new ArgumentOutOfRangeException(nameof(item), item.Type, "Invalid MicroHID type.");
        if (item is not MicroHIDItem)
            throw new ArgumentException("MicroHIDItem must not be null!");
    }

    /// <summary>
    /// Called when this <paramref name="microHidItem"/>'s <see cref="MicroHidPhase"/> changed.
    /// </summary>
    /// <param name="microHidItem"></param>
    /// <param name="phase"></param>
    public virtual void OnPhaseChanged(MicroHIDItem microHidItem, MicroHidPhase phase)
    {
        Logger.Debug($"OnPhaseChanged {phase}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// Called when this <paramref name="microHidItem"/> is broken by <see cref="BrokenSyncModule"/>.
    /// </summary>
    /// <param name="microHidItem"></param>
    public virtual void OnBroken(MicroHIDItem microHidItem)
    {
        Logger.Debug($"OnBroken {microHidItem.Serial}", ItemPlugin.Instance!.Config!.Debug);
    }
}
