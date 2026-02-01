using System;
using System.Linq;
using CommandSystem;
using Instinct.Core.Features.RoleSystem.Managers;
using LabApi.Features.Wrappers;

namespace Instinct.Roles.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class GiveRole : ICommand { //THIS A TEST COMMAND
        public string Command => "GiveRole";

        public string[] Aliases => new string[] { "gc" };

        public string Description => "give custom role for u";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            Player? executer = Player.Get(sender);

            if (executer == null)
            {
                response = "bruh, this is not a player";
                return false;
            }


            if (arguments.Count < 1) {
                executer.RemoveRole();
            }
            executer.AddRole(int.Parse(arguments.First()));

            response = executer.HasCRole(short.Parse(arguments.First())).ToString();
            return executer.HasCRole(short.Parse(arguments.First()));
        }
    }
}