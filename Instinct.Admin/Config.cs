using System.ComponentModel;

namespace Instinct.Admin {
    public class Config {
        [Description("Warn config")]
        public uint WarnLimit { get; set; } = 3;
    }
}
