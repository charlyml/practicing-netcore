using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.Configurations;

public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.Property(p => p.Name).IsRequired();

        builder.Property(p => p.Address).IsRequired();

        builder.HasMany(p => p.Books)
            .WithOne(b => b.Publisher)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}
