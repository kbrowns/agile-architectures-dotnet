using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AA.Domain.Model;

public class OrderMapping : DomainEntityMapping<Order>
{
    protected override void MapEntity(EntityTypeBuilder<Order> builder)
    {
        builder.HasOne(_ => _.Customer);
        builder.HasMany(_ => _.Items).WithOne(_ => _.Order);
    }
}