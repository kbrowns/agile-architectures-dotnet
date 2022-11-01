using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AA.Domain.Model;

public abstract class DomainEntityMapping<T> : IEntityMapping
    where T : DomainEntity
{
    public void Map(ModelBuilder modelBuilder)
    {
        EntityTypeBuilder<T> builder = modelBuilder.Entity<T>();
        builder.ToTable(typeof(T).Name.FromPascalCaseToSnakeCase());

        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id);
        builder.Property(_ => _.ExternalId);
        
        this.MapEntity(builder);
    }

    protected abstract void MapEntity(EntityTypeBuilder<T> builder);
}