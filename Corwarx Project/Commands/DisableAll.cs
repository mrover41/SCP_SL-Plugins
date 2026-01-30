using CommandSystem;

namespace Instinct.Core.Commands {
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    internal class DisableAll : ICommand {
        public string Command => "DisablePlugin";
        public string[] Aliases => [];
        public string Description => "disable all";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            Loader.Instance?.Disable();

            response = "Done";
            return true;
        }
    }
}
