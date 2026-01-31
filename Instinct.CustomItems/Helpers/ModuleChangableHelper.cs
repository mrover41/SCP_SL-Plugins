using Instinct.CustomItems.Interfaces;
using InventorySystem.Items.Autosync;
using UnityEngine;

namespace Instinct.CustomItems.Helpers;

/// <summary>
/// Helper Extension for <see cref="IModuleChangable"/>.
/// </summary>
public static class ModuleChangableHelper
{
    /// <summary>
    /// Apply <paramref name="moduleChangable"/> for <paramref name="item"/>.
    /// </summary>
    /// <param name="item">Item to change its Modules.</param>
    /// <param name="moduleChangable">The Changable interface.</param>
    public static void ApplyChange(this ModularAutosyncItem item, IModuleChangable moduleChangable)
    {
        if (moduleChangable.ReplaceModules.Count == 0 && moduleChangable.AddModules.Count == 0)
            return;

        item.OnAdded(null);
        List<SubcomponentBase> subcomponents = [];
        foreach (SubcomponentBase subcomponent in item.AllSubcomponents)
        {
            KeyValuePair<ModuleChanger, Type> KVToReplace = moduleChangable.ReplaceModules.FirstOrDefault(x => x.Key.ModuleType == subcomponent.GetType());
            if (KVToReplace.Value != default)
            {
                // Getting the child if exists (must be duh! otherwise use the main object)
                GameObject child = GetGameObjectChild(item.gameObject, KVToReplace.Key);

                // Here we find it and remove it!
                Transform? realComponent = child.transform.Find(subcomponent.name);
                realComponent.parent = null;
                GameObject.Destroy(realComponent);

                // Creating new GameObject with the Components that we have
                GameObject myObject = new(KVToReplace.Value.Name, [KVToReplace.Value]);
                // Adding that to the child transform (re-parenting)
                myObject.transform.SetParent(child.transform, false);
                // getting the component and adding into the subcomponents.
                SubcomponentBase new_component = myObject.GetComponent<SubcomponentBase>();
                subcomponents.Add(new_component);
            }
            else if (!subcomponents.Contains(subcomponent))
                subcomponents.Add(subcomponent);

        }
        item.AllSubcomponents = [.. subcomponents];
        AddSubmodules(item, moduleChangable.AddModules);
        item.OnAdded(null);
    }


    private static void AddSubmodules(this ModularAutosyncItem item, List<ModuleChanger> addModules)
    {
        List<SubcomponentBase> subcomponents = [];
        foreach (ModuleChanger? moduleChanger in addModules)
        {
            // Getting the child if exists (must be duh! otherwise use the main object)
            GameObject child = GetGameObjectChild(item.gameObject, moduleChanger);

            // Creating new GameObject with the Components that we have
            GameObject myObject = new(moduleChanger.ModuleType.Name, [moduleChanger.ModuleType]);
            // Adding that to the child transform (re-parenting)
            myObject.transform.SetParent(child.transform, false);
            // getting the component and adding into the subcomponents.
            SubcomponentBase new_component = myObject.GetComponent<SubcomponentBase>();
            subcomponents.Add(new_component);
        }
        item.AllSubcomponents = [.. item.AllSubcomponents, .. subcomponents];
    }

    /// <summary>
    /// Getting the <paramref name="gameObject"/>'s Child with <paramref name="moduleChanger"/>.
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="moduleChanger"></param>
    /// <returns></returns>
    public static GameObject GetGameObjectChild(this GameObject gameObject, ModuleChanger moduleChanger)
    {
        GameObject child = gameObject;
        if (moduleChanger.ChildId != -1)
            child = gameObject.transform.GetChild(moduleChanger.ChildId).gameObject;
        if (!string.IsNullOrEmpty(moduleChanger.ChildName))
            child = gameObject.transform.Find(moduleChanger.ChildName).gameObject;
        return child;
    }
}
