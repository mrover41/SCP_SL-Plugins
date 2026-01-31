using Instinct.CustomItems.Helpers;
using InventorySystem.Items.Autosync;

namespace Instinct.CustomItems.Interfaces;

/// <summary>
/// Module changer for <see cref="ModularAutosyncItem"/>.
/// </summary>
public interface IModuleChangable
{
    /// <summary>
    /// Modules to replace the Base to our Custom One. (ONLY CUSTOM!)
    /// </summary>
    public Dictionary<ModuleChanger, Type> ReplaceModules { get; }

    /// <summary>
    /// Add modules to the custom item.
    /// </summary>
    public List<ModuleChanger> AddModules { get; }
}
