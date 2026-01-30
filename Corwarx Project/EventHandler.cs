using Instinct.Core.Events.Args.Administration;
using Instinct.Core.Events.Args.Modules;
using Instinct.Core.Events.Args.Plugin;
using Instinct.Core.Events.Args.Roles;
using Instinct.Core.Events.Handles;
using LabApi.Events.Arguments.PlayerEvents;

namespace Instinct.Core {
    internal class EventHandler {
        public static void OnPlayerJoined(PlayerJoinedEventArgs ev) {
            Logger.Debug($"Connected: {ev.Player.Nickname}");
        }

        public static void RegisterEvents() {
            Roles.SpawnAllRoles += OnSpawnAllRoles;
            Roles.SpawnRole += OnSpawnRole;

            Plugin.LoadPlugin += OnLoadPlugin;
            Plugin.UnLoadPlugin += OnUnLoadPlugin;

            Module.RegModuleEvent += OnRegModule;
            Module.EnabledModuleEvent += OnEnabledModule;
            Module.DisableModuleEvent += OnDisableModule;
            Module.UnregisterModuleEvent += OnUnregisterModule;

            Administration.AddWarnEvent += OnAddWarn;
        }

        public static void UnRegisterEvents() {
            Roles.SpawnAllRoles -= OnSpawnAllRoles;
            Roles.SpawnRole -= OnSpawnRole;

            Plugin.LoadPlugin -= OnLoadPlugin;
            Plugin.UnLoadPlugin -= OnUnLoadPlugin;

            Module.RegModuleEvent -= OnRegModule;
            Module.EnabledModuleEvent -= OnEnabledModule;
            Module.DisableModuleEvent -= OnDisableModule;
            Module.UnregisterModuleEvent -= OnUnregisterModule;

            Administration.AddWarnEvent -= OnAddWarn;
        }

        private static void OnSpawnAllRoles() {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Spawning all roles");
        }

        private static void OnSpawnRole(SpawnRoleEventArg ev) {
            Logger.Debug("===EVENT===");
            //Logger.Debug($"Spawning role: {ev.Role.Name}");
        }

        private static void OnLoadPlugin(LoadPluginEventArgs ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Loading plugin: {ev.Name}");
        }

        private static void OnUnLoadPlugin(UnLoadPluginEventArgs ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Unloading plugin: {ev.Name}");
        }

        private static void OnRegModule(RegModuleEventArg ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Registering module: {ev.Module.Name}");
        }

        private static void OnEnabledModule(EnabledModuleEventArg ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Enabled module: {ev.Module.Name}");
        }

        private static void OnDisableModule(DisableModuleEventArg ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Disabling module: {ev.Module.Name}");
        }

        private static void OnUnregisterModule(UnregisterModuleEventArg ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Unregistering module: {ev.Module.Name}");
        }

        private static void OnAddWarn(AddWarnEventArg ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Adding warn: {ev.Message} to player: {ev.PlayerID} / {ev.SteamID}");
        }
    }
}
