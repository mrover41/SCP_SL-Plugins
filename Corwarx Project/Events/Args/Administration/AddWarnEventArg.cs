namespace Instinct.Core.Events.Args.Administration {
    public class AddWarnEventArg {
        public AddWarnEventArg(string steamID, string message, string nickname, int player_id) {
            this.SteamID = steamID;
            this.Message = message;
            this.Nickname = nickname;
            this.PlayerID = player_id;
        }

        public string SteamID;
        public string Message;
        public string Nickname;
        public int PlayerID;
    }
}
