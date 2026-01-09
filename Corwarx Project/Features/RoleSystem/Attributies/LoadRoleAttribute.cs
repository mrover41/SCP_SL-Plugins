using System;

namespace Corwarx_Project.Features.RoleSystem.Attributies {
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class LoadRoleAttribute : Attribute {
        public Type ComponetType { get; private set; }

        public LoadRoleAttribute(Type componetType) {
            ComponetType = componetType;
        }
    }
    
    
}