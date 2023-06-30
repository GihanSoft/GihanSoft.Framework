using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GihanSoft.Framework.EntityFrameworkCore;

public class ConcurrencyEntityConfig<TEntity, TId, TToken> : IEntityTypeConfiguration<TEntity>
    where TEntity : ConcurrencyEntity<TId, TToken>
    where TId : IEquatable<TId>
    where TToken : IEquatable<TToken>
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        _ = builder ?? throw new ArgumentNullException(nameof(builder));
        builder.Property(x => x.ConcurrencyToken).IsRowVersion();
    }
}
