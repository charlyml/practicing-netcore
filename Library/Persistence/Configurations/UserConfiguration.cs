using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.UseCollation("utf8mb4_unicode_ci");
        
        builder.Property(u => u.Username)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(u => u.Username).IsUnique();

        builder.Property(u => u.Email).IsRequired();

        builder.HasIndex(u => u.Email).IsUnique();

        builder.Property(u => u.Password).IsRequired();

        builder.Property(u => u.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("current_timestamp()");

        builder.HasMany(u => u.Loans)
            .WithOne(l => l.User)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

    }
}
