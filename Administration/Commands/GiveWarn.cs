using CommandSystem;
using Exiled.API.Features;
using System;
using System.Linq;
using Administration.WarnSystem;

namespace Administration.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class AddWarn : ICommand {
        public string Command => "AddWarn";

        public string[] Aliases => new[] { "w" };

        public string Description => "Add warn";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            if (arguments.Count < 2) { 
                response = "Usage: AddWarn <playerID> <reason>";
                return false;
            }
            Player player = Player.Get(arguments.First());
            WarnManager.AddWarn(player.UserId.ToString(), arguments.Last(), player.Nickname, player.Id, out response);
            return true;
        }
    }
}
