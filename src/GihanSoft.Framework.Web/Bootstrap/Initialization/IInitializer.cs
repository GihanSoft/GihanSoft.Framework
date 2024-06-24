namespace GihanSoft.Framework.Web.Bootstrap.Initialization;

/// <summary>
/// Initializer <see langword="interface"/>
/// </summary>
public interface IInitializer
{
    /// <summary>
    /// priority for running order. higher means sooner
    /// </summary>
    int Priority { get; }

    /// <summary>
    /// Initialization method
    /// </summary>
    /// <returns></returns>
    Task InitializeAsync();
}
