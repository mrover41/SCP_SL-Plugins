using CommandSystem;
using Exiled.API.Features;
using System;
using System.Linq;
using System.Text;
using Administration.WarnSystem;

namespace Administration.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class GetWarn : ICommand {
        public string Command => "GetWarn";

        public string[] Aliases => new[] { "wg" };

        public string Description => "Get warn";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            StringBuilder sb = new StringBuilder();
            if (arguments.Count != 1) { 
                response = "Usage: GetWarn <playerSteamID>";
                return false;
            }
            WarnManager.GetWarns(arguments.First()).ForEach(warn => {
                sb.AppendLine($"ID: {warn.ID}, Nickname: {warn.Nickname}, Message: {warn.Message}");
            });
            response = sb.ToString();
            return true;
        }
    }

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class GetWarnPID : ICommand {
        public string Command => "GetWarnPID";

        public string[] Aliases => new[] { "wgi" };

        public string Description => "Get warn plID";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            StringBuilder sb = new StringBuilder();
            if (arguments.Count != 1) { 
                response = "Usage: GetWarn <playerPlayerID>";
                return false;
            }
            Player player = Player.Get(arguments.First());
            WarnManager.GetWarns(player.UserId.ToString()).ForEach(warn => {
                sb.AppendLine($"ID: {warn.ID}, Nickname: {warn.Nickname}, Message: {warn.Message}");
            });
            response = sb.ToString();
            return true;
        }
    }
}
