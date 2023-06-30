namespace GihanSoft.Framework.EntityFrameworkCore;

public interface IEntity<TId>
    where TId : IEquatable<TId>
{
    public TId Id { get; init; }
}

public abstract class Entity<TId> : IEntity<TId>
    where TId : IEquatable<TId>
{
    public required TId Id { get; init; }
}
