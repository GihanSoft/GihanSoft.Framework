namespace GihanSoft.Framework.EntityFrameworkCore;

public interface IConcurrencyEntity<TId, TToken> : IEntity<TId>
    where TId : IEquatable<TId>
    where TToken : IEquatable<TToken>
{
    public TToken ConcurrencyToken { get; init; }
}

public abstract class ConcurrencyEntity<TId, TToken> : IConcurrencyEntity<TId, TToken>
    where TId : IEquatable<TId>
    where TToken : IEquatable<TToken>
{
    public required TId Id { get; init; }
    public required TToken ConcurrencyToken { get; init; }
}
