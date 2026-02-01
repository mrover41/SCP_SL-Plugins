using System.ComponentModel;

namespace Instinct.Core {
    public class Config {
        public List<string> BlackListModules { get; set; } = [
            "Example module 1",
            "Example module 2"
        ];
        
        public List<string> BlackListModulesNameof { get; set; } = [
            "ExampleModule_1",
            "ExampleModule_2"
        ];
    }

}
