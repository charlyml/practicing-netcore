using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.UseCollation("utf8mb4_unicode_ci");

        builder.Property(a => a.Name).IsRequired();
        
        builder.Property(a => a.Lastname).IsRequired();

        builder.HasMany(a => a.Books)
            .WithMany(a => a.Authors)
            .UsingEntity(t => t.ToTable("AuthorsBooks"));
    }
}
