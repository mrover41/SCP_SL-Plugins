using CommandSystem;
using Instinct.Core.Features.UpdateInjector.Attributies;
using MEC;
using UnityEngine;

namespace Instinct.Admin.Commands {
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    internal class Hivorot : ICommand {
        public string Command => "Huivorot";

        public string[] Aliases => ["hv"];

        public string Description => "Хуиворот предметов";
        
        private static Player? _player;
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            int time = int.Parse(arguments.First());
            if (arguments.Count != 1) {
                response = "Usage: hv <time>";
                return false;
            }

            _player = Player.Get(sender);
            Timing.CallDelayed(time, () => { _player = null; });
            response = "Done";
            return true;
        }

        [Update]
        private static void Phys() {
            foreach (Pickup pickup in Pickup.List.Where(x => _player != null && Vector3.Distance(x.Transform.position, _player.Position) < 10)) {
                if (_player == null) continue;
                Vector3 pos = _player.Position - pickup.Position;
                pos.Normalize();
                pos *= 50 * Time.deltaTime;
                pickup.Rigidbody?.useGravity = false;
                pickup.Rigidbody?.AddForce(pos);
            }
        }
    }
}
