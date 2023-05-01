namespace GihanSoft.Framework.Bootstrap.Initializers;

public interface IInitializer
{
    static abstract int Priority { get; }

    Task InitializeAsync();
}
