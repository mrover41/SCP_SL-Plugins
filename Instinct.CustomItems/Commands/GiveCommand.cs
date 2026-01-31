using CommandSystem;
using Instinct.CustomItems.Items;
using Utils;

namespace Instinct.CustomItems.Commands;

/// <summary>
/// Command for giving custom item to the player.
/// </summary>
[CommandHandler(typeof(CustomItemsCommandBase))]
public sealed class GiveCommand : ICommand, IUsageProvider
{
    /// <inheritdoc/>
    public string Command => "give";

    /// <inheritdoc/>
    public string[] Aliases => ["give"];

    /// <inheritdoc/>
    public string Description => "Give item to player(s)";

    /// <inheritdoc/>
    public string[] Usage => ["itemname", "%player% (Optional)"];

    /// <inheritdoc/>
    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (!sender.CheckPermission(PlayerPermissions.GivingItems, out response))
        {
            return false;
        }
        List<Player> players = [];
        Player? player = Player.Get(sender);
        if (arguments.Count == 1 && player == null) {
            if (arguments.Array != null)
                response = "To execute this command provide at least 2 arguments!\nUsage: " + arguments.Array[0] + " " +
                           this.DisplayCommandUsage();
            return false;
        }

        if (player != null) players.Add(player);
        string itemname = arguments.At(0);
        StringComparison comparison = ItemPlugin.Instance!.Config!.EasyCompare ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase;
        if (!CustomItems.IsItemNameExist(itemname, comparison))
        {
            response = "ItemName not exists!";
            return false;
        }
        if (arguments.Count == 2)
        {
            players = [.. RAUtils.ProcessPlayerIdOrNamesList(arguments, 1, out _).Select(Player.Get)];
        }
        if (players.Count == 0)
        {
            response = "No players!";
            return false;
        }
        foreach (Player p in players)
        {
            CustomItemBase? customitem = CustomItems.CreateItem(itemname);
            if (customitem != null)
                CustomItems.AddCustomItem(customitem, p);
        }
        response = "Done!";
        return true;
    }
}
