using System.Reflection;
using Instinct.Core.Features.UpdateInjector.Attributies;
using LabApi.Loader.Features.Misc;
using LabApi.Loader.Features.Plugins;
using UnityEngine;

namespace Instinct.Core.Features.UpdateInjector;

public class Updater : MonoBehaviour {
    public static Updater? Instance;

    private static readonly List<Action> Updates = [];

    public void Init() {
        Logger.Debug("Updater initialized");
        foreach (Plugin plugin in LabApi.Loader.PluginLoader.EnabledPlugins) {
            Logger.Debug($"Processing assembly: {plugin.Name}");
            plugin.TryGetLoadedAssembly(out Assembly assembly);
            foreach (Type type in assembly.GetTypes()) {
                foreach (MethodInfo method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(x => x.GetCustomAttribute<UpdateAttribute>() != null)) {
                    Action action = (Action)Delegate.CreateDelegate(typeof(Action), method);
                    Updates.Add(action);
                    Logger.Raw($"[Instinct.Core] Register Method: {action.Method.Name}", ConsoleColor.Cyan);
                }
            }
        }
        Logger.Debug($"Registered methods: {Updates.Count}");
    }

    private void OnEnable() {
        Instance = this;
    }

    private void Update() {
        for (int i = 0; i < Updates.Count; i++)
            Updates[i]();
    }

    private void OnDisable() {
        Instance = null;
    }
}