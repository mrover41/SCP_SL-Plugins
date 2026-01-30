using System;
using System.Reflection;
using LabApi.Loader.Features.Plugins;

namespace Instinct.UI {
    public class Loader : Plugin {
        public static Loader Instance { get; private set; }

        public override string Name => throw new NotImplementedException();

        public override string Description => throw new NotImplementedException();

        public override string Author => throw new NotImplementedException();

        public override Version Version => throw new NotImplementedException();

        public override Version RequiredApiVersion => throw new NotImplementedException();


        public Loader() => Instance = this;

        public override void Enable()
        {

            ModuleManager.RegisterModules(Assembly.GetExecutingAssembly());
        }

        public override void Disable()
        {
        }

    }
}
