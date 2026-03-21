using System;
using System.Collections.Generic;
using Corwarx_Project.Extensions;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;

namespace Corwarx_Roles.Roles.InstanceComponents {
    public class SCP035InstanceComponent : RoleInstanceComponentBase {
        public SCP035InstanceComponent(RoleBase role, Player player) : base(role, player) {
        }

        private static readonly ushort Damage = 2;
        //private CoroutineHandle _coroutineHandle;

        public override void OnAdd() {
            Exiled.Events.Handlers.Player.Hurting += HurtingPlayer;
            Exiled.Events.Handlers.Player.PickingUpItem += OnUpItem;
            
            Timing.RunCoroutine(HealthCorutine(), $"SCP035_{Player.UserId}");
            Player.CustomInfo = "<color=red>SCP-035</color>";
            base.OnAdd();
        }

        public override void OnRemove() {
            Exiled.Events.Handlers.Player.Hurting -= HurtingPlayer;
            Exiled.Events.Handlers.Player.PickingUpItem -= OnUpItem;
            
            Timing.KillCoroutines($"SCP035_{Player.UserId}");
            Player.CustomInfo = String.Empty;
            base.OnRemove();
        }

        private void HurtingPlayer(HurtingEventArgs ev) {
            if (ev.Attacker == null || ev.Player == null) return;
            if (ev.Player == Player && ev.DamageHandler.Type == DamageType.Scp) ev.IsAllowed = false; 
        }

        private void OnUpItem(PickingUpItemEventArgs ev) {
            if (ev.Player != Player) return;
            switch (ev.Pickup.Type) {
                case ItemType.SCP1509:
                    ev.IsAllowed = false;
                    break;
            }
        }
        
        IEnumerator<float> HealthCorutine() {
            for (;;) {
                yield return Timing.WaitForSeconds(1);
                Player.Hurt(Damage, DamageType.Bleeding);
                //Player.Health -= Damage;
                //if (Player.Health <= 0) Player.Kill(DamageType.ParticleDisruptor);
            }
        }
    }
}