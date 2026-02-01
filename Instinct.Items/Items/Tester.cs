using Instinct.CustomItems.Items;
using LabApi.Features.Wrappers;
using UnityEngine;

namespace Instinct.Items.Items {
    public class Component_Tester : CustomFirearmBase
    {
        public override string CustomItemName { get; set; } = "Component_Tester";
        public override string Description { get; set; } = "Инструмент для разработчика";
        public override float Weight { get; } = 2f;
        public override ItemType Type { get; } = ItemType.GunCOM18;
        public override float Damage { get; } = 0;
        public override short ClipSize { get; } = 250;

        public override void OnShooting(Player player, FirearmItem weapon, bool isAllowedHelper)
        {
            if (Physics.Raycast(player.Camera.position, Vector3.forward, out RaycastHit raycastHit)) {
                Component[] componentsP = raycastHit.transform.GetComponentsInParent<Component>();
                Component[] componentsC = raycastHit.transform.GetComponentsInChildren<Component>();
                //DisplayCore displayCore = DisplayCore.Get(ev.Player.ReferenceHub);
                string cp = "<align=left><size=15>ComponentInParent\n", cc = "<align=right><size=15>ComponentsInChildren\n";

                foreach (Component component in componentsP) {
                    cp += $"{component.GetType().Name}\n";
                }

                foreach (Component component in componentsC) {
                    cc += $"{component.GetType().Name}\n";
                }

                LabApi.Features.Console.Logger.Info(raycastHit.transform.gameObject);
                LabApi.Features.Console.Logger.Info("++++++++++++++++++++++++++++++");
                LabApi.Features.Console.Logger.Info(cp);
                LabApi.Features.Console.Logger.Info("===============================");
                LabApi.Features.Console.Logger.Info(cc);

                //var elementReference_1 = new TimedElemRef<SetElement>();
                //displayCore.SetElemTemp(cp, 900, TimeSpan.FromSeconds(5), elementReference_1);

                //var elementReference_2 = new TimedElemRef<SetElement>();
                //displayCore.SetElemTemp(cc, 900, TimeSpan.FromSeconds(5), elementReference_2);
            }
            
            base.OnShooting(player, weapon, isAllowedHelper);
        }
    }
}