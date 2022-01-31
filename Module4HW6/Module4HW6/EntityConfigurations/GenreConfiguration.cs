using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Entities;

namespace Module4HW6.EntityConfigurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.ToTable("Genre").HasKey(g => g.Id);
        builder.Property(g => g.Id).HasColumnName("GenreId").ValueGeneratedOnAdd();
        builder.Property(g => g.Title).IsRequired().HasMaxLength(30);
    }
}