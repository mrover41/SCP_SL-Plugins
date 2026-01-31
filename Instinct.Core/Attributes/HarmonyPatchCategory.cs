namespace Instinct.Core.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public abstract class HarmonyPatchCategory(string category) : Attribute {
    public string Category { get; } = category;
}