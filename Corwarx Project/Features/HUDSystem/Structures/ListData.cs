using Instinct.Core.Features.HUDSystem.Enums;

namespace Instinct.Core.Features.HUDSystem.Structures {
    public struct ListData {
        public List<string> Hint;
        public bool AutoStile;
        public Align Align;
        public int Size;
        public string Hex;
        public bool OverrideColor;
        public ListData(List<string> hint, bool autoStile = true, bool overrideColor = true, Align align = Align.right, int size = 15, string hex = "")  {
            this.Hint = hint;
            this.AutoStile = autoStile;
            this.Align = align;
            this.Size = size;
            this.Hex = hex;
            this.OverrideColor = overrideColor;
        }
    }
}
