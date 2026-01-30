namespace Instinct.Core.Events.Args.Administration {
    public class AddingWarnEventArg {
        public AddingWarnEventArg(string steamID, string message, string nickname, int player_id) {
            this.SteamID = steamID;
            this.Message = message;
            this.Nickname = nickname;
            this.PlayerID = player_id;
            this.IsAllowed = true;
        }

        public string SteamID { get; }
        public string Message { get; }
        public string Nickname { get; }
        public int PlayerID { get; }
        public bool IsAllowed { get; }
    }
}
