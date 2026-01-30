using CommandSystem;
using Instinct.Admin.WarnSystem;

namespace Instinct.Admin.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class AddWarn : ICommand {
        public string Command => "AddWarn";

        public string[] Aliases => ["w"];

        public string Description => "Add warn";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            if (arguments.Count < 2) { 
                response = "Usage: AddWarn <playerID> <reason>";
                return false;
            }
            
            Player? player = Player.Get(arguments.First());
            if (player is not null) {
                WarnManager.AddWarn(player.UserId, arguments.Last(), player.Nickname, player.PlayerId, out response);
                return true;
            }
            
            response = "Usage: AddWarn <playerID> <reason>";
            return false;
        }
    }
}
