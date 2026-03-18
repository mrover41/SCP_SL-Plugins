using System;
using System.Linq;
using CommandSystem;
using Corwarx_Project.Extensions;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using InventorySystem.Items.Pickups;
using PlayerRoles;
using UnityEngine;

namespace Gameplay.Commands.Client {
    [CommandHandler(typeof(ClientCommandHandler))]
    internal class Take : ICommand {
        public string Command => "Take";
        public string[] Aliases => new string[] { "t", "up" };
        public string Description => "Підібрати картку";
        
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response) {
            if (sender == null) {
                response = "Ви не гравець";
                return false;
            }
            
            Player player = Player.Get(sender);
            if (player.Role != RoleTypeId.Scp049) {
                response = "У вас немає ручок ;)";
                return false;
            }
            
            if (Physics.Linecast(player.CameraTransform.gameObject.transform.position, player.CameraTransform.position + player.CameraTransform.forward * 10, out RaycastHit info)) {
                if (info.transform.TryGetComponent(out ItemPickupBase pickupBase)) {
                    if (pickupBase.NetworkInfo.ItemId.IsKeycard()) {
                        player.ClearInventory();
                        player.AddItem(pickupBase.NetworkInfo.ItemId);
                        player.CurrentItem = player.Items.First();
                        //player.PickUpKeyCard();
                        //player.CurrentItem = pickupBase.Info.ItemId.GetItemBase();
                        pickupBase.DestroySelf();
                        response = "Ви підняли ключ карту";
                        return true;
                    } else {
                        response = "Це не ключ карта";
                        return false;
                    }
                } else {
                    response = "Це не предмет";
                    return false;
                }
            }
            
            response = "Чтото вызывает скриптовые ошибки";
            return false;
        }
    }
}