using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AA.Domain.Model;

public class CustomerMapping : DomainEntityMapping<Customer>
{
    protected override void MapEntity(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(_ => _.Name);
        builder.Property(_ => _.EmailAddress);
        builder.Property(_ => _.Status).HasConversion<string>();
        builder.HasMany(_ => _.Orders).WithOne(_ => _.Customer);
    }
}
