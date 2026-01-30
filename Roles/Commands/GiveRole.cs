using System;
using System.Linq;
using CommandSystem;
using Corwarx_Project.Features.RoleSystem.Managers;
using LabApi.API.Features;

namespace Corwarx_Roles.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class GiveRole : ICommand { //THIS A TEST COMMAND
        public string Command => "GiveRole";

        public string[] Aliases => new string[] { "gc" };

        public string Description => "give custom role for u";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            Player executer = Player.Get(sender);

            if (arguments.Count < 1) {
                executer.RemoveRole();
            }
            executer.AddRole(int.Parse(arguments.First()));

            response = "Done";
            return true;
        }
    }
}