using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Entities;

namespace Module4HW6.EntityConfigurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.ToTable("Artist").HasKey(a => a.Id);
        builder.Property(a => a.Id).HasColumnName("ArtistId").ValueGeneratedOnAdd();
        builder.Property(a => a.Name).IsRequired().HasMaxLength(255);
        builder.Property(a => a.DateOfBirth).IsRequired();
        builder.Property(a => a.Phone).HasMaxLength(20);
        builder.Property(a => a.Email).HasMaxLength(50);
        builder.Property(a => a.InstagramUrl).HasMaxLength(255);

        builder.HasMany(a => a.Songs)
            .WithMany(s => s.Artists)
            .UsingEntity<Dictionary<string, object>>(
                "ArtistSong",
                j => j
                    .HasOne<Song>()
                    .WithMany()
                    .HasForeignKey("SongId"),
                j => j
                    .HasOne<Artist>()
                    .WithMany()
                    .HasForeignKey("ArtistId"));
    }
}