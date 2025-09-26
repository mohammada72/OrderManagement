using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Configuration;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.CreatedAtUtc).IsRequired();
        builder.Property(o => o.Status).HasConversion<int>();

        builder.OwnsMany(o => o.Items, items =>
        {
            items.Property(i => i.ProductName).HasMaxLength(200).IsRequired();
            items.Property(i => i.Quantity).IsRequired();
        });
    }
}
