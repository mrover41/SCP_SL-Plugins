using Instinct.CustomItems.Items;
using InventorySystem.Items.MicroHID.Modules;

namespace Instinct.CustomItems.Events;

public static class CustomMicroHIDEvents
{
    public static event Action<CustomMicroHidBase, MicroHIDItem, MicroHidPhase>? PhaseChanged;
    public static event Action<CustomMicroHidBase, MicroHIDItem>? Broken;

    public static void OnPhaseChanged(CustomMicroHidBase customMicro, MicroHIDItem microHIDItem, MicroHidPhase phase)
        => PhaseChanged?.Invoke(customMicro, microHIDItem, phase);

    public static void OnBroken(CustomMicroHidBase customMicro, MicroHIDItem microHIDItem)
        => Broken?.Invoke(customMicro, microHIDItem);
}
