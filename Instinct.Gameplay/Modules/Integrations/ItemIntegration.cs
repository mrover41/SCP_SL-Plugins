using Instinct.Core.Features.ModuleSystem.Attributies;
using Instinct.Core.Features.ModuleSystem.BaseClass;
using InventorySystem.Items.Pickups;
using LabApi.Events.Arguments.PlayerEvents;
using UnityEngine;

namespace Instinct.Gameplay.Modules.Integrations {
    //[LoadModule]
    /*internal class ItemIntegration : ModuleBase {
        public override string Name => "Item Integration";

        public override void OnEnable() {
            LabApi.Events.Handlers.PlayerEvents.ShotWeapon += Interact;
            base.OnEnable();
        }

        public override void OnDisable() {
            LabApi.Events.Handlers.PlayerEvents.ShotWeapon += Interact;
            base.OnDisable();
        }

        private void Interact(PlayerShotWeaponEventArgs ev) {
            if (Physics.Linecast(ev.Player.Camera.position, ev.Player.Camera.position + ev.Player.Camera.forward * 10, out RaycastHit hitInfo)) {
                if (hitInfo.transform.TryGetComponent(out ItemPickupBase itemPickupBase)) {
                    Pickup pickup = Pickup.Get(itemPickupBase);
                    Vector3 d = pickup.Position - ev.Player.Camera.position;
                    d.Normalize();
                    switch (pickup.Type) {
                        case ItemType.GrenadeFlash:
                            pickup.Destroy();
                            Map./*i dont know what(pickup.Position, LabApi.API.Enums.ProjectileType.Flashbang, pickup.PreviousOwner);
                            break;
                        case ItemType.GrenadeHE:
                            pickup.Destroy();
                            Map.Explode(pickup.Position, LabApi.API.Enums.ProjectileType.FragGrenade, pickup.PreviousOwner);
                            break;
                        default:
                            pickup.Rigidbody.AddForceAtPosition(d * 200, hitInfo.point);
                            break;
                    }
                    ev.Player.ShowHitMarker(0.5f);
                }
            }
        }
    }*/
}
