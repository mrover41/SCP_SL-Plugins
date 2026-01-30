using CommandSystem;
using System.Text;
using Instinct.Admin.WarnSystem;

namespace Instinct.Admin.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class GetWarn : ICommand {
        public string Command => "GetWarn";

        public string[] Aliases => ["wg"];

        public string Description => "Get warn";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            StringBuilder sb = new();
            if (arguments.Count != 1) { 
                response = "Usage: GetWarn <playerSteamID>";
                return false;
            }
            
            WarnManager.GetWarns(arguments.First()).ForEach(warn => {
                sb.AppendLine($"ID: {warn.Id}, Nickname: {warn.Nickname}, Message: {warn.Message}");
            });
            
            response = sb.ToString();
            return true;
        }
    }

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class GetWarnPid : ICommand {
        public string Command => "GetWarnPID";
        public string[] Aliases => ["wgi"];
        public string Description => "Get warn plID";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            StringBuilder sb = new();
            if (arguments.Count != 1) { 
                response = "Usage: GetWarn <playerPlayerID>";
                return false;
            }
            
            Player? player = Player.Get(arguments.First());
            WarnManager.GetWarns(player?.UserId).ForEach(warn => {
                sb.AppendLine($"ID: {warn.Id}, Nickname: {warn.Nickname}, Message: {warn.Message}");
            });
            
            response = sb.ToString();
            return true;
        }
    }
}
