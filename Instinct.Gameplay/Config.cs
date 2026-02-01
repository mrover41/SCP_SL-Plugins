using System.ComponentModel;

namespace Instinct.Gameplay {
    public class Config {
        /*[Description("Bleeding Config")]
        public uint Damage { get; set; } = 10;
        public uint BleedingTime { get; set; } = 10;
        public uint CriticalDamage { get; set; } = 5;
        public string Message { get; set; } = "You are bleeding!";
        public string BroadcastMessage { get; set; } = "You are bleeding!";*/
        
        [Description("Lobby config")]
        public float X { get; set; } = -5f;

        public float Y { get; set; } = -5f;
        public float Z { get; set; } = -2.7f;
    }
}
