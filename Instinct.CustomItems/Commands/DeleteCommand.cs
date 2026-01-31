using CommandSystem;

namespace Instinct.CustomItems.Commands;

/// <summary>
/// Command for spawning custom item to the player.
/// </summary>
[CommandHandler(typeof(CustomItemsCommandBase))]
public sealed class DeleteCommand : ICommand, IUsageProvider
{
    /// <inheritdoc/>
    public string Command => "delete";

    /// <inheritdoc/>
    public string[] Aliases => ["delete"];

    /// <inheritdoc/>
    public string Description => "Delete custom item";

    /// <inheritdoc/>
    public string[] Usage => ["id"];

    /// <inheritdoc/>
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (!sender.CheckPermission(PlayerPermissions.GivingItems, out response))
        {
            return false;
        }
        if (arguments.Count < 1) {
            if (arguments.Array != null)
                response = "To execute this command provide at least 1 arguments!\nUsage: " + arguments.Array[0] + " " +
                           this.DisplayCommandUsage();
            return false;
        }
        if (!ushort.TryParse(arguments.At(0), out ushort id))
        {
            response = "Parsing failed!";
            return false;
        }
        if (Pickup.TryGet(id, out Pickup? pickup) && pickup.IsCustom())
        {
            pickup.Destroy();
        }
        if (Item.TryGet(id, out Item? item) && item.IsCustom())
        {
            item.Base.ServerDropItem(false).DestroySelf();
        }
        response = "Done!";
        return true;
    }
}
