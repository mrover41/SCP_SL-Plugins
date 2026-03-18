using System;
using System.Collections.Generic;
using Corwarx_Project.Features.RoleSystem.BaseClass.Role;
using Exiled.API.Features;
using MEC;

namespace Corwarx_Roles.Roles.InstanceComponents {
    public class SCP035InstanceComponent : RoleInstanceComponentBase {
        public SCP035InstanceComponent(RoleBase role, Player player) : base(role, player) {
        }

        private static readonly ushort Damage = 3;
        //private CoroutineHandle _coroutineHandle;

        public override void OnAdd() {
            Timing.RunCoroutine(HealthCorutine(), $"SCP035_{Player.UserId}");
            Player.CustomInfo = "<color=red>SCP-035</color>";
            base.OnAdd();
        }

        public override void OnRemove() {
            Timing.KillCoroutines($"SCP035_{Player.UserId}");
            Player.CustomInfo = String.Empty;
            base.OnRemove();
        }

        IEnumerator<float> HealthCorutine() {
            for (;;) {
                yield return Timing.WaitForSeconds(1);
                Player.Hurt(Damage);
            }
        }
    }
}