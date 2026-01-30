using CommandSystem;

namespace Instinct.Admin.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class Drop : ICommand {
        public string Command => "Drop";

        public string[] Aliases => ["drop"];

        public string Description => "Drop items";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            int id = int.Parse(arguments.First());
            int count = int.Parse(arguments.Last());
            
            if (arguments.Count != 2) {
                response = "Usage: Drop <Item ID> <Count>";
                return false;
            }
            
            for (int i = 0; i < count; i++)
                Pickup.Create((ItemType)id, Player.Get(sender)!.Position);
            
            response = "Done";
            return true;
        }
    }
}
