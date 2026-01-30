namespace Instinct.Admin.Models {
    internal class WarnData(string id, string nickname, string message) {
        public string Id = id;
        public string Nickname = nickname;
        public string Message = message;

        public override string ToString() => $"Id: {this.Id}, Nickname: {this.Nickname}, Message: {this.Message}";
    }
}