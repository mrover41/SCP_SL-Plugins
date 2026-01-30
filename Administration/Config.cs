using LabApi.API.Interfaces;
using System.ComponentModel;

namespace Administration {
    public class Config : IConfig {
        [Description("Plugin config")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; }

        [Description("Warn config")]
        public uint WarnLimit { get; set; } = 3;
    }
}
