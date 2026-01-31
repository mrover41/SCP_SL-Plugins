namespace Instinct.CustomItems.Overrides;

/// <summary>
/// Used in places where can something be easily overriden.
/// </summary>
public interface IOverride
{
    /// <summary>
    /// Type to override.
    /// </summary>
    public Type OverrideType { get; }

    /// <summary>
    /// Apply override class for <paramref name="classToOverride"/>.
    /// </summary>
    /// <param name="classToOverride"></param>
    public void Apply(ref object classToOverride);
}

/// <summary>
/// Used in places where can something be easily overriden.
/// </summary>
/// <typeparam name="T">Any type to override.</typeparam>
public interface IOverride<T> : IOverride
{
    /// <summary>
    /// Apply override class for <paramref name="classToOverride"/>.
    /// </summary>
    /// <param name="classToOverride"></param>
    public void Apply(ref T classToOverride);
}