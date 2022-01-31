using Microsoft.EntityFrameworkCore;
using Module4HW6.Entities;
using Module4HW6.EntityConfigurations;

namespace Module4HW6;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Artist> Artists { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Song> Songs { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArtistConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());
        modelBuilder.ApplyConfiguration(new SongConfiguration());
    }
}