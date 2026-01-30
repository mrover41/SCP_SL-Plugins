using UnityEngine;

namespace Corwarx_Project.Events.Args._Player {
    public class PlayerMovingEventArgs {
        public PlayerMovingEventArgs(LabApi.API.Features.Player player, Vector3 position) {
            Player = player;
            Position = position;
            isAlloved = true;
        }

        public LabApi.API.Features.Player Player { get; }
        public Vector3 Position { get; }
        public bool isAlloved { get; set; }
    }
}
