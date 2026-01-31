using System.ComponentModel;

namespace Instinct.CustomItems;

internal sealed class Config {
    public bool Debug { get; set; } = false;
    public bool PrintComponentOnChange { get; set; }
    public bool EasyCompare { get; set; } = true;
    public bool ShowPickedUpHint { get; set; } = true;
    [Description("Hint when you picked up the custom item. {0}: DisplayName {1}: Description.")]
    public string PickedUpHint { get; set; } = "You picked up {0}\n{1}";
    public bool ShowSelectedHint { get; set; } = true;
    [Description("Hint when you selected a the custom item. {0}: DisplayName {1}: Description.")]
    public string SelectedHint { get; set; } = "You selected {0}\n{1}";
}