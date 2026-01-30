using System.Reflection;
using Instinct.Core.Features.ModuleSystem.Attributies;
using Instinct.Core.Features.ModuleSystem.BaseClass;

namespace Instinct.Core.Features.ModuleSystem.Manager {
    public static class ModuleManager {
        public static List<ModuleBase> Modules { get; private set; } = [];

        [Obsolete("Pleas use attributies")]
        private static void RegisterModule(ModuleBase? module, bool isEnabled = true) {
            if (module != null && !Modules.Contains(module)) {
                Modules.Add(module);
                
                if (module.Id == -1)
                    module.Id = Modules.Count + 1;
                
                Events.Handles.Module.OnRegModuleEvent(new Events.Args.Modules.RegModuleEventArg(module));
                
                if (!isEnabled) return;
                
                if (!Events.Handles.Module.OnEnableModuleEvent(new Events.Args.Modules.EnableModuleEventArg(module)).IsAllowed)
                    return;
                
                module.OnEnable();
                Events.Handles.Module.OnEnabledModuleEventArg(new Events.Args.Modules.EnabledModuleEventArg(module));
            } 
            else {
                Logger.Error($"Module {module?.Name} with ID {module?.Id} is null or already registered.");
            }
        }

        public static void RegisterModules(Assembly asm, bool enableModules = true) {
            foreach (Type type in asm.GetTypes()) {
                if (type.GetCustomAttribute<LoadModuleAttribute>() == null) continue;
                
                if (!typeof(ModuleBase).IsAssignableFrom(type))
                    throw new Exception($"Error in class: {type.FullName}\n Can`t load module");
                
                ModuleBase instance = (ModuleBase)Activator.CreateInstance(type);
                RegisterModule(instance, false);
                
                if (enableModules)
                    instance.OnEnable();
            }

            Events.Handles.Module.OnRegisterAssembly();
        }

        internal static void EnableAllModules() {
            foreach (ModuleBase module in Modules.Where(module => !module.IsEnabled).Where(module => Events.Handles.Module.OnEnableModuleEvent(new Events.Args.Modules.EnableModuleEventArg(module)).IsAllowed)) {
                module.OnEnable();
                module.IsEnabled = true;

                Events.Handles.Module.OnEnabledModuleEventArg(new Events.Args.Modules.EnabledModuleEventArg(module));
            }
        }

        public static void EnableModule(uint id) {
            ModuleBase? module = Modules.FirstOrDefault(m => m.Id == id);

            if (module != null) {
                if (module.IsEnabled)
                    return;
                
                if (!Events.Handles.Module.OnEnableModuleEvent(new Events.Args.Modules.EnableModuleEventArg(module)).IsAllowed)
                    return;
                
                module.OnEnable();
                module.IsEnabled = true;
                
                Events.Handles.Module.OnEnabledModuleEventArg(new Events.Args.Modules.EnabledModuleEventArg(module));
            } 
            else {
                Logger.Error($"Module with ID {id} not found.");
            }
        }

        public static void DisableModule(uint id) {
            ModuleBase? module = Modules.FirstOrDefault(m => m.Id == id);

            if (module != null) {
                if (!module.IsEnabled)
                    return;
                
                module.OnDisable();
                module.IsEnabled = false;
                
                Events.Handles.Module.OnDisableModuleEventArg(new Events.Args.Modules.DisableModuleEventArg(module));
            } 
            else {
                Logger.Error($"Module with ID {id} not found.");
            }
        }

        internal static void DisableAllModules() {
            foreach (ModuleBase module in Modules) {
                if (!module.IsEnabled)
                    return;

                module.OnDisable();
                module.IsEnabled = false;
                Events.Handles.Module.OnDisableModuleEventArg(new Events.Args.Modules.DisableModuleEventArg(module));
            }
        }

        public static void UnregisterModule(ModuleBase? module) {
            if (module != null && Modules.Contains(module)) {
                Modules.Remove(module);
                Events.Handles.Module.OnUnregisterModuleEventArg(new Events.Args.Modules.UnregisterModuleEventArg(module));
            } 
            else {
                Logger.Error($"Module {module.Name} with ID {module.Id} is null or not registered.");
            }
        }

        public static void UnregisterModule(uint id) {
            ModuleBase? module = Modules.FirstOrDefault(m => m.Id == id);
            
            if (module != null && Modules.Contains(module)) {
                Modules.Remove(module);
                Events.Handles.Module.OnUnregisterModuleEventArg(new Events.Args.Modules.UnregisterModuleEventArg(module));
            } 
            else {
                Logger.Error($"Module {module?.Name} with ID {module?.Id} is null or not registered.");
            }
        }
    }
}
