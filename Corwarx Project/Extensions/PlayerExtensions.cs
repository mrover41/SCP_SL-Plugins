using Corwarx_Project.Features.Components.PlayerComponents;
using InventorySystem.Items.Pickups;
using LabApi.Features.Wrappers;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Logger = LabApi.Features.Console.Logger;

namespace Corwarx_Project.Extensions {
    public static class PlayerExtensions {
        public static PlayerMovement GetPlayerMovement(this Player pl) {
            if (pl.GameObject.TryGetComponent(out PlayerMovement obj))
                return obj;
            return null;
        }
       

        public static bool PickUpKeyCard(this Player player, float dist = 4) {
            if (UnityEngine.Physics.Linecast(player.Camera.position, player.Camera.position + player.Camera.forward * dist, out RaycastHit hit)) { 
                Logger.Info($"Hit: {hit.collider.gameObject.name}");
                ItemPickupBase pickup = hit.collider.gameObject.GetComponentInParent<ItemPickupBase>();
                if (pickup != null) {

                    if (Pickup.Get(pickup).Type is ItemType.KeycardJanitor or ItemType.KeycardScientist or ItemType.KeycardResearchCoordinator or ItemType.KeycardZoneManager or ItemType.KeycardGuard or ItemType.KeycardMTFPrivate or ItemType.KeycardContainmentEngineer or ItemType.KeycardMTFOperative or ItemType.KeycardMTFCaptain or ItemType.KeycardFacilityManager or ItemType.KeycardChaosInsurgency or ItemType.KeycardO5)
                    {
                        player.AddItem(Pickup.Get(pickup));
                        GameObject.Destroy(pickup.gameObject);
                        return true;
                    }
                }
            }
            return false;
        }

        public static Player GetFromView(this Player owner, float lenght) {
            if (!Physics.Raycast(owner.Camera.position, owner.Camera.forward, out var hit, lenght)) return null;

            return Player.Get(hit.transform.GetComponentInParent<ReferenceHub>());
        }

        public static string ToShortString(this Player pl) => pl is null || pl.IsHost ? "Server" : $"{pl.Nickname} ({pl.PlayerId}|{pl.UserId})";
        public static List<Player> FindNearby(this Player pl, float distance) => Player.List.Where(x => Vector3.Distance(pl.Position, x.Position) <= distance && x != pl).ToList();
    }
}
