using CommandSystem;
using MEC;

namespace Instinct.Admin.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class LoadSchene : ICommand {
        public string Command => "LoadSchene";
        public string[] Aliases => ["ls"];
        public string Description => "ахалай-махалай";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            int playerID = int.Parse(arguments.First());

            Player? player = Player.Get(playerID);

            //player?.SendFakeSceneLoading(LabApi.Features.Enums.Sce.MainMenuRemastered);

            //Timing.CallDelayed(5, () => { player?.SendFakeSceneLoading(LabApi.API.Enums.ScenesType.PreLoader); });

            response = "Done";
            return true;
        }
    }
}
