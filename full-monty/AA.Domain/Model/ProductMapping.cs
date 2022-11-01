using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AA.Domain.Model;

public class ProductMapping : DomainEntityMapping<Product>
{
    protected override void MapEntity(EntityTypeBuilder<Product> builder)
    {
        builder.Property(_ => _.Name).IsRequired();
        builder.Property(_ => _.Description);
        builder.Property(_ => _.Price);
    }
}