using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.Name).IsRequired();

        builder.Property(c => c.LastName).IsRequired();

        builder.Property(c => c.Email).IsRequired();

        builder.HasIndex(c => c.Email).IsUnique();
        
        builder.Property(c => c.Address).IsRequired();

        builder.Property(c => c.PhoneNumber).IsRequired();
        
        builder.Property(u => u.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("current_timestamp()");

        builder.HasMany(c => c.Loans)
            .WithOne(l => l.Customer)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
