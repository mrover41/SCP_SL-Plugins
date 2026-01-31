namespace Instinct.CustomItems.Helpers;

/// <summary>
/// Helper to add/change the <see cref="InventorySystem.Items.Autosync.ModularAutosyncItem"/>'s <see cref="InventorySystem.Items.Autosync.ModularAutosyncItem.AllSubcomponents"/>.
/// </summary>
public class ModuleChanger
{
    /// <summary>
    /// The Module Type to replace from.
    /// </summary>
    public Type ModuleType;
    /// <summary>
    /// The Child Id that the Module is in.
    /// </summary>
    public int ChildId = -1;
    /// <summary>
    /// The Child Name that the Module is in.
    /// </summary>
    public string ChildName;

    /// <summary>
    /// Create a new Empty <see cref="ModuleChanger"/>.
    /// </summary>
    public ModuleChanger()
    {

    }

    /// <summary>
    /// Create a new <see cref="ModuleChanger"/> with the parameters.
    /// </summary>
    /// <param name="moduleType"></param>
    /// <param name="childId"></param>
    public ModuleChanger(Type moduleType, int childId)
    {
        this.ModuleType = moduleType;
        this.ChildId = childId;
    }

    /// <summary>
    /// Create a new <see cref="ModuleChanger"/> with the parameters.
    /// </summary>
    /// <param name="moduleType"></param>
    /// <param name="childName"></param>
    public ModuleChanger(Type moduleType, string childName)
    {
        this.ModuleType = moduleType;
        this.ChildName = childName;
    }

    /// <summary>
    /// Create a new <see cref="ModuleChanger"/> with the parameters.
    /// </summary>
    /// <param name="moduleType"></param>
    /// <param name="childId"></param>
    /// <param name="childName"></param>
    public ModuleChanger(Type moduleType, int childId, string childName)
    {
        this.ModuleType = moduleType;
        this.ChildId = childId;
        this.ChildName = childName;
    }
}
