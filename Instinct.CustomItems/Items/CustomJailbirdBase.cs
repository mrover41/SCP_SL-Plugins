using Instinct.CustomItems.Helpers;
using Instinct.CustomItems.Interfaces;
using Instinct.CustomItems.Overrides;

namespace Instinct.CustomItems.Items;

/// <summary>
/// Custom <see cref="JailbirdItem"/> base.
/// </summary>
public abstract class CustomJailbirdBase : CustomItemBase, IModuleChangable
{
    /// <inheritdoc/>
    public virtual Dictionary<ModuleChanger, Type> ReplaceModules { get; } = [];
    /// <inheritdoc/>
    public virtual List<ModuleChanger> AddModules { get; } = [];

    /// <summary>
    /// Changable values for <see cref="InventorySystem.Items.Jailbird.JailbirdItem"/>
    /// </summary>
    public readonly JailbirdItemOverride JailbirdItemOverride = new();

    /// <inheritdoc/>
    public override void Parse(Item item)
    {
        base.Parse(item);
        if (item.Type != ItemType.Jailbird)
            throw new ArgumentOutOfRangeException(nameof(item), item.Type, "Invalid Jailbird type.");
        if (item is not JailbirdItem jailbird)
            throw new ArgumentException("JailbirdItem must not be null!");

        InventorySystem.Items.Jailbird.JailbirdItem jailbirdItemBase = jailbird.Base;
        this.JailbirdItemOverride.Apply(ref jailbirdItemBase);
    }

    /// <summary>
    /// Called Server processed a <paramref name="message"/> from <paramref name="jailbirdItem"/>.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="jailbirdItem"></param>
    /// <param name="message"></param>
    public virtual void OnProcessedJailbirdMessage(Player player, JailbirdItem jailbirdItem, InventorySystem.Items.Jailbird.JailbirdMessageType message)
    {
        Logger.Debug($"ProcessedJailbirdMessage {player.PlayerId} {jailbirdItem.Serial} {message}", ItemPlugin.Instance!.Config!.Debug);
    }

    /// <summary>
    /// Called Server processing a <paramref name="message"/> from <paramref name="jailbirdItem"/>.
    /// </summary>
    /// <param name="player"></param>
    /// <param name="jailbirdItem"></param>
    /// <param name="message"></param>
    /// <param name="allowInspectHelper"></param>
    /// <param name="allowAttackHelper"></param>
    /// <param name="isAllowedHelper"></param>
    public virtual void OnProcessingJailbirdMessage(Player player, JailbirdItem jailbirdItem, InventorySystem.Items.Jailbird.JailbirdMessageType message, bool allowInspectHelper, bool allowAttackHelper, bool isAllowedHelper)
    {
        Logger.Debug($"ProcessingJailbirdMessage {player.PlayerId} {jailbirdItem.Serial} {message} {allowAttackHelper} {allowInspectHelper}", ItemPlugin.Instance!.Config!.Debug);
    }
}
