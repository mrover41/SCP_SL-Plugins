using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.Components.PlayerComponents;
using Corwarx_Project.Features.Components.SCP049Components;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Wrappers;
using PlayerRoles;
using UnityEngine;

using Logger = LabApi.Features.Console.Logger;
using Object = UnityEngine.Object;

namespace Corwarx_Project.Modules {
    [LoadModule]
    internal class MonoLoad : ModuleBase {
        public override string Name => "Mono Loader";

        public override void OnEnable() {
            Logger.Debug($"[MonoLoad] Enabled module: {Name} (ID: {Id})");
            LabApi.Events.Handlers.PlayerEvents.ChangingRole += OnChangingRole;
            base.OnEnable();
        }

        public override void OnDisable() {
            Logger.Debug($"[MonoLoad] Disabled module: {Name} (ID: {Id})");
            LabApi.Events.Handlers.PlayerEvents.ChangingRole -= OnChangingRole;
            base.OnDisable();
        }

        private void OnChangingRole(PlayerChangingRoleEventArgs ev) {
            Logger.Debug($"[MonoLoad] Handling role change for {ev.Player.Nickname} ({ev.Player.Role}) → {ev.NewRole}");

            RemoveComponent<PlayerMovement>(ev.Player);
            RemoveComponent<SCP049Component>(ev.Player);

            if (ev.NewRole.IsHuman()) {
                AddComponent<PlayerMovement>(ev.Player);
            }
            else if (ev.NewRole == RoleTypeId.Scp049) {
                AddComponent<SCP049Component>(ev.Player);
            }
        }

        private void AddComponent<T>(Player player) where T : Component {
            Component added = player.GameObject.AddComponent<T>();
            Logger.Debug($"[MonoLoad] Added component: {typeof(T).Name} to {player.Nickname}");
        }


        private void RemoveComponent<T>(Player player) where T : Component {
            if (player.GameObject.TryGetComponent(out T existing)) {
                Object.Destroy(existing);
                Logger.Debug($"[MonoLoad] Removed component: {typeof(T).Name} from {player.Nickname}");
            }
        }
    }
}
