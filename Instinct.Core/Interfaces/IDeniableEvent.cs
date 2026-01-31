namespace Instinct.Core.Interfaces;

public interface IDeniableEvent {
    bool IsAllowed { get; set; }    
}