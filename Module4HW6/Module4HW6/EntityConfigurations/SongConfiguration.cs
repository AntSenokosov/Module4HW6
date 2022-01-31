using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Entities;

namespace Module4HW6.EntityConfigurations;

public class SongConfiguration : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.ToTable("Song").HasKey(s => s.Id);
        builder.Property(s => s.Id).HasColumnName("SongId").ValueGeneratedOnAdd();
        builder.Property(s => s.Title).IsRequired().HasMaxLength(100);
        builder.Property(s => s.Duration).IsRequired();
        builder.Property(s => s.ReleasedDate).IsRequired();

        builder.HasOne(s => s.Genre)
            .WithMany(g => g.Songs)
            .HasForeignKey(f => f.GenreId);
    }
}