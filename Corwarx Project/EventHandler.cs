using Corwarx_Project.Events.Args.Administration;
using Corwarx_Project.Events.Args.Modules;
using Corwarx_Project.Events.Args.Plugin;
using Corwarx_Project.Events.Args.Roles;
using Corwarx_Project.Events.Handles;
using Corwarx_Project.Extensions;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Console;

namespace Corwarx_Project {
    internal class EventHandler {
        public void OnPlayerJoined(PlayerJoinedEventArgs ev) {
            Logger.Debug($"Connected: {ev.Player.Nickname}");
        }

        public void RegisterEvents() {
            Roles.SpawnAllRoles += OnSpawnAllRoles;
            Roles.SpawnRole += OnSpawnRole;

            Plugin.LoadPlugin += OnLodadPlugin;
            Plugin.UnLoadPlugin += OnUnLoadPlugin;

            Module.RegModuleEvent += OnRegModule;
            Module.EnabledModuleEvent += OnEnabledModule;
            Module.DisableModuleEvent += OnDisableModule;
            Module.UnregisterModuleEvent += OnUnregisterModule;

            Administration.AddWarnEvent += OnAddWarn;
        }

        public void UnRegisterEvents() {
            Roles.SpawnAllRoles -= OnSpawnAllRoles;
            Roles.SpawnRole -= OnSpawnRole;

            Plugin.LoadPlugin -= OnLodadPlugin;
            Plugin.UnLoadPlugin -= OnUnLoadPlugin;

            Module.RegModuleEvent -= OnRegModule;
            Module.EnabledModuleEvent -= OnEnabledModule;
            Module.DisableModuleEvent -= OnDisableModule;
            Module.UnregisterModuleEvent -= OnUnregisterModule;

            Administration.AddWarnEvent -= OnAddWarn;
        }

        private void OnSpawnAllRoles(SpawnAllRolesEventArg ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Spawning all roles");
        }

        private void OnSpawnRole(SpawnRoleEventArg ev) {
            Logger.Debug("===EVENT===");
            //Logger.Debug($"Spawning role: {ev.Role.Name}");
        }

        private void OnLodadPlugin(LoadPluginEventArgs ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Loading plugin: {ev.Name}");
        }

        private void OnUnLoadPlugin(UnLoadPluginEventArgs ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Unloading plugin: {ev.Name}");
        }

        private void OnRegModule(RegModuleEventArg ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Registering module: {ev.Module.Name}");
        }

        private void OnEnabledModule(EnabledModuleEventArg ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Enabled module: {ev.Module.Name}");
        }

        private void OnDisableModule(DisableModuleEventArg ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Disabling module: {ev.Module.Name}");
        }

        private void OnUnregisterModule(UnregisterModuleEventArg ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Unregistering module: {ev.Module.Name}");
        }

        private void OnAddWarn(AddWarnEventArg ev) {
            Logger.Debug("===EVENT===");
            Logger.Debug($"Adding warn: {ev.Message} to player: {ev.PlayerID} / {ev.SteamID}");
        }
    }
}
