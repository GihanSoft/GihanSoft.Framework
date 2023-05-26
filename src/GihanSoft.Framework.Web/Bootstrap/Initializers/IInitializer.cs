namespace GihanSoft.Framework.Web.Bootstrap.Initializers;

public interface IInitializer
{
    static abstract int Priority { get; }

    Task InitializeAsync();
}
