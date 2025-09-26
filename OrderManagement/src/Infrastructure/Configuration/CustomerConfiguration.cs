using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.ValueObjects;

namespace OrderManagement.Infrastructure.Configuration;
public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Email, builder =>
        {

            builder.HasColumnType("nvarchar(255)");
        });


        
    //.HasColumnType("nvarchar(255)")
    //.HasMaxLength(300)
    //.HasConversion(
    //    v => v.ToString(),
    //    w => new Email(w))

    }
}
