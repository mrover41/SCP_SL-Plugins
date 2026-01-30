using Instinct.Core.Events.Args.Administration;

namespace Instinct.Core.Events.Handles {
    public static class Administration {
        public static event Action<AddingWarnEventArg> AddingWarnEvent;
        public static event Action<AddWarnEventArg> AddWarnEvent;

        public static AddingWarnEventArg OnAddingWarnEvent(AddingWarnEventArg arg) {
            AddingWarnEvent?.Invoke(arg);
            return arg;
        }

        public static AddWarnEventArg OnAddWarnEvent(AddWarnEventArg arg) {
            AddWarnEvent?.Invoke(arg);
            return arg;
        }
    }
}
