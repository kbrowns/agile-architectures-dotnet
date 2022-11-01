using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AA.Domain.Model;

public class OrderItemMapping : DomainEntityMapping<OrderItem>
{
    protected override void MapEntity(EntityTypeBuilder<OrderItem> builder)
    {
        builder.Property(_ => _.Amount);
        builder.Property(_ => _.Discount);
        builder.Property(_ => _.Tax);
        builder.HasOne(_ => _.Order);
        builder.HasOne(_ => _.Product);
    }
}