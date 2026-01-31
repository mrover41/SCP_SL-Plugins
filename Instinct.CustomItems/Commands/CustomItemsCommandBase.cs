using CommandSystem;

namespace Instinct.CustomItems.Commands;

/// <summary>
/// Parent command base for every Custom Item Command.
/// </summary>
[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class CustomItemsCommandBase : ParentCommand, IUsageProvider
{
    /// <inheritdoc/>
    public override string Command => "lci";

    /// <inheritdoc/>
    public override string[] Aliases => ["labapicustomitems"];

    /// <inheritdoc/>
    public override string Description => "Interacting with Custom Items";

    /// <inheritdoc/>
    public string[] Usage => ["give/spawn/list/delete"];

    /// <inheritdoc/>
    public override void LoadGeneratedCommands()
    {
        RegisterCommand(new GiveCommand());
        RegisterCommand(new SpawnCommand());
        RegisterCommand(new ListCommand());
        RegisterCommand(new DeleteCommand());
    }

    /// <inheritdoc/>
    protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        response = $"Please specify a valid subcommand!\n- {this.Command} list\n- {this.Command} give ItemName %player%\n- {this.Command} spawn ItemName x y z\n- {this.Command} delete id";
        return false;
    }

}
