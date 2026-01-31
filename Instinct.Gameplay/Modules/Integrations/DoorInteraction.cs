using Instinct.Core.Features.ModuleSystem.Attributies;
using Instinct.Core.Features.ModuleSystem.BaseClass;
using Interactables.Interobjects.DoorButtons;
using Interactables.Interobjects.DoorUtils;
using LabApi.Events.Arguments.PlayerEvents;
using UnityEngine;

namespace Instinct.Gameplay.Modules.Integrations {
    [LoadModule]
    internal class DoorInteraction : ModuleBase {
        private float _lTime = 5f;

        public override void OnEnable() {
            LabApi.Events.Handlers.PlayerEvents.ShootingWeapon += ShootingWeapon;
            base.OnEnable();
        }

        public override void OnDisable() {
            LabApi.Events.Handlers.PlayerEvents.ShootingWeapon -= ShootingWeapon;
            base.OnDisable();
        }

        private void ShootingWeapon(PlayerShootingWeaponEventArgs ev) {
            if (!Physics.Raycast(ev.Player.Camera.position, ev.Player.Camera.forward, out RaycastHit raycastHit, 70f)) return; //~(1 << 1 | 1 << 13 | 1 << 16 | 1 << 28)
            if (raycastHit.transform.gameObject.GetComponentInParent<BasicDoorButton>() is not { } button)
                return;
            
            Door door = Door.Get(button.GetComponentInParent<DoorVariant>());
            if (door.Permissions == DoorPermissionFlags.None || door.IsLocked || door.IsDestroyed || !door.CanInteract) return;
            
            door.IsOpened = !door.IsOpened;
            ev.Player.SendHitMarker(0.5f);
        }
    }
}
