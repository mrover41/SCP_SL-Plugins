using Instinct.Admin.Models;
using Instinct.Core.Events.Args.Administration;
using LabApi.Loader.Features.Paths;

namespace Instinct.Admin.WarnSystem {
    internal static class WarnManager {
        public static void AddWarn(string steamID, string message, string? nickname, int playerID, out string response) {
            response = "Error :(";
            if (nickname != null && !Core.Events.Handles.Administration.OnAddingWarnEvent(new AddingWarnEventArg(steamID, message, nickname, playerID)).IsAllowed) return;

            string dataPath = Path.Combine(Path.GetDirectoryName(PathManager.Configs.ToString()) ?? string.Empty, "Instinct_WarnData", $"{steamID}.iad");
            if (!Directory.Exists(Path.GetDirectoryName(dataPath))) {
                Directory.CreateDirectory(Path.GetDirectoryName(dataPath) ?? string.Empty);
            }

            List<WarnData> warns = [];

            if (File.Exists(dataPath))
                warns = ParseFile(dataPath);

            warns.Add(new WarnData(steamID, nickname ?? steamID, message));
            DateTime now = DateTime.Now;

            List<string> lines = [];
            lines.AddRange(warns.Select(warn => $"{warn.Id}!{warn.Nickname}?{warn.Message}[Time: {now:HH:mm dd.MM.yyyy}]"));

            File.WriteAllLines(dataPath, lines);
            response = $"Warn added. Total warns: {warns.Count}/{Loader.Instance?.Config?.WarnLimit}, SteamID: {steamID}";
            
            Core.Events.Handles.Administration.OnAddWarnEvent(new AddWarnEventArg(steamID, message, nickname ?? steamID, playerID));
        }

        public static void ClearWarns(string? steamID) {
            string dataPath = Path.Combine(Path.GetDirectoryName(PathManager.Configs.ToString()) ?? string.Empty, "Corwarx_WarnData");
            if (Directory.Exists(dataPath)) {
                File.Delete(Path.Combine(dataPath, $"{steamID}.corwarxAPIdata"));
            }
        }

            public static List<WarnData> GetWarns(string? steamID) {
                string dataPath = Path.Combine(Path.GetDirectoryName(PathManager.Configs.ToString()) ?? string.Empty, "Corwarx_WarnData", $"{steamID}.corwarxAPIdata");
                return !File.Exists(dataPath) ? [] : ParseFile(dataPath);
            }

        private static List<WarnData> ParseFile(string filePath) {
            List<WarnData> list = [];

            foreach (string line in File.ReadLines(filePath)) {
                int exclIndex = line.IndexOf('!');
                int questIndex = line.IndexOf('?');

                if (exclIndex == -1 || questIndex == -1 || exclIndex > questIndex) {
                    Logger.Error("File format is broken!");
                    continue;
                }

                string id = line.Substring(0, exclIndex);
                string nickname = line.Substring(exclIndex + 1, questIndex - exclIndex - 1);
                string message = line.Substring(questIndex + 1);
                
                list.Add(new WarnData(id, nickname, message));
            }

            return list;
        }
    }
}
