using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.UseCollation("utf8mb4_unicode_ci");

        builder.Property(b => b.Pages).IsRequired();

        builder.Property(b => b.Code)
            .HasMaxLength(50)
            .IsUnicode(false)
            .IsRequired();

        builder.Property(b => b.Title).IsRequired();

        builder.Property(b => b.Isbn)
            .HasMaxLength(18)
            .IsRequired();

        builder.Property(b => b.Editorial).IsRequired();

        builder.Property(b => b.PublicationDate).IsRequired();

        builder.HasMany(b => b.Loans)
            .WithOne(l => l.Book)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}
