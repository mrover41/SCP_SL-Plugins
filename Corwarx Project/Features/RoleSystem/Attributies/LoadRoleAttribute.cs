namespace Instinct.Core.Features.RoleSystem.Attributies {
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class LoadRoleAttribute(Type componentType) : Attribute {
        public Type ComponentType { get; private set; } = componentType;
    }
}