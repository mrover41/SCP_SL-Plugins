using InventorySystem.Items.Firearms;
using InventorySystem.Items.Firearms.Modules;

namespace Instinct.CustomItems.Extensions;

///
public static class FirearmExtension
{
    ///
    public static bool TryGetModule(this Firearm firearm, Type type, out object module, bool ignoreSubmodules = true)
    {
        ModuleBase[] modules = firearm.Modules;
        foreach (ModuleBase moduleBase in modules)
        {
            if ((!ignoreSubmodules || !moduleBase.IsSubmodule) && moduleBase.GetType() == type)
            {
                module = moduleBase;
                return true;
            }
        }

        module = default;
        return false;
    }
}
