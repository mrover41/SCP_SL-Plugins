using Corwarx_Project.Core.Features.ModuleSystem.Atributies;
using Corwarx_Project.Features.ModuleSystem.BaseClass;
using LabApi.API.Features;
using LabApi.API.Features.Pickups;
using LabApi.Events.EventArgs.Player;
using InventorySystem.Items.Pickups;
using UnityEngine;

namespace Gameplay.Modules.Integrations {
    //[LoadModule]
    internal class ItemIntegration : ModuleBase {
        public override string Name => "Item Integration";

        public override void OnEnable() {
            LabApi.Events.Handlers.Player.Shot += Interact;
            base.OnEnable();
        }

        public override void OnDisable() {
            LabApi.Events.Handlers.Player.Shot += Interact;
            base.OnDisable();
        }

        void Interact(ShotEventArgs ev) {
            if (Physics.Linecast(ev.Player.CameraTransform.position, ev.RaycastHit.point, out RaycastHit hitInfo)) {
                if (hitInfo.transform.TryGetComponent(out ItemPickupBase itemPickupBase)) {
                    Pickup pickup = Pickup.Get(hitInfo.transform.gameObject);
                    Vector3 d = pickup.Position - ev.Player.CameraTransform.position;
                    d.Normalize();
                    switch (pickup.Type) {
                        case ItemType.GrenadeFlash:
                            pickup.Destroy();
                            Map.Explode(pickup.Position, LabApi.API.Enums.ProjectileType.Flashbang, pickup.PreviousOwner);
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
    }
}
