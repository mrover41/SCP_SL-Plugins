using Instinct.Core.Events.Args.Administration;
using Instinct.Core.Features.ModuleSystem.Attributies;
using Instinct.Core.Features.ModuleSystem.BaseClass;

namespace Instinct.Admin.Modules {
    [LoadModule]
    internal class WarnMessage : ModuleBase {
        public override void OnEnable() {
            Core.Events.Handles.Administration.AddWarnEvent += this.OnWarnAdded;
            base.OnEnable();
        }

        public override void OnDisable() {
            Core.Events.Handles.Administration.AddWarnEvent -= this.OnWarnAdded;
            base.OnDisable();
        }

        private void OnWarnAdded(AddWarnEventArg ev) {
            Player? player = Player.Get(ev.PlayerID);
            player?.SendBroadcast($"<color=#ff0000>Вам выданно предупреждение по причине:<color=#ff7700><b> {ev.Message}</b></color>", 5);
        }
    }
}
