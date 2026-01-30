using InventorySystem.Items.Pickups;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Instinct.Core.Extensions {
    public static class PlayerExtensions {
        extension(Player? player) {
            public bool PickUpKeyCard(float dist = 4) {
                if (!Physics.Linecast(player!.Camera.position, player.Camera.position + player.Camera.forward * dist, out RaycastHit hit)) return false;
                Logger.Info($"Hit: {hit.collider.gameObject.name}");
                ItemPickupBase pickup = hit.collider.gameObject.GetComponentInParent<ItemPickupBase>();
                
                if (pickup == null) return false;
                if (Pickup.Get(pickup).Type is not (ItemType.KeycardJanitor or ItemType.KeycardScientist
                    or ItemType.KeycardResearchCoordinator or ItemType.KeycardZoneManager or ItemType.KeycardGuard
                    or ItemType.KeycardMTFPrivate or ItemType.KeycardContainmentEngineer
                    or ItemType.KeycardMTFOperative or ItemType.KeycardMTFCaptain or ItemType.KeycardFacilityManager
                    or ItemType.KeycardChaosInsurgency or ItemType.KeycardO5)) return false;
                
                player.AddItem(Pickup.Get(pickup));
                Object.Destroy(pickup.gameObject);
                
                return true;
            }

            public Player? GetFromView(float lenght) {
                return !Physics.Raycast(player!.Camera.position, player.Camera.forward, out RaycastHit hit, lenght) ? null : Player.Get(hit.transform.GetComponentInParent<ReferenceHub>());
            }

            public string ToShortString() => player is null || player.IsHost ? "Server" : $"{player.Nickname} ({player.PlayerId}|{player.UserId})";
            public List<Player> FindNearby(float distance) => Player.List.Where(x => Vector3.Distance(player!.Position, x.Position) <= distance && x != player).ToList();
        }
    }
}
