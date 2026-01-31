using CommandSystem;
using CommandSystem.Commands.RemoteAdmin;
using HarmonyLib;
using Utils;

namespace Instinct.Core.Patches;

[HarmonyPatch(typeof(SetGroupCommand), nameof(SetGroupCommand.Execute))]
internal static class SetGroupCommandPatch {
    internal static bool Prefix(SetGroupCommand __instance, ArraySegment<string> arguments,
        ICommandSender sender, ref string response) {
        if (!sender.CheckPermission(PlayerPermissions.SetGroup, out response)) {
            return true;
        }

        if (arguments.Count < 2) {
            return true;
        }

        List<ReferenceHub> playersToAffect = RAUtils.ProcessPlayerIdOrNamesList(arguments, 0, out string[] array);
        if (playersToAffect.Count <= 1) return true;
        
        response = "Вы не можете выдать группу больше чем одному человеку за раз";
        return false;

    }
}