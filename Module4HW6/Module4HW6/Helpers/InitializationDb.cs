using Microsoft.EntityFrameworkCore;
using Module4HW6.Entities;

namespace Module4HW6.Helpers;

public class InitializationDb
{
    private readonly ApplicationContext _db;

    public InitializationDb(ApplicationContext db)
    {
        _db = db;
    }

    public async Task Init()
    {
        if (!(await _db.Genres.AnyAsync()))
        {
            await InitGenre();
        }

        if (!(await _db.Songs.AnyAsync()))
        {
            await InitSong();
        }

        if (!(await _db.Artists.AnyAsync()))
        {
            await InitArtist();
        }
    }

    private async Task InitGenre()
    {
        var genres = new List<Genre>();

        genres.Add(new Genre()
        {
            Title = "Genre1"
        });

        genres.Add(new Genre()
        {
            Title = "Genre2"
        });

        genres.Add(new Genre()
        {
            Title = "Genre3"
        });

        genres.Add(new Genre()
        {
            Title = "Genre4"
        });

        genres.Add(new Genre()
        {
            Title = "Genre5"
        });

        await _db.Genres.AddRangeAsync(genres);
        await _db.SaveChangesAsync();
    }

    private async Task<IEnumerable<Song>> InitSong()
    {
        var songs = new List<Song>();

        songs.Add(new Song()
        {
            Title = "Song1",
            Duration = new TimeSpan(0, 3, 48),
            ReleasedDate = new DateTimeOffset(new DateTime(2003, 8, 14)),
            GenreId = 1
        });

        songs.Add(new Song()
        {
            Title = "Song2",
            Duration = new TimeSpan(0, 2, 16),
            ReleasedDate = new DateTimeOffset(new DateTime(2018, 12, 1)),
            GenreId = 3
        });

        songs.Add(new Song()
        {
            Title = "Song3",
            Duration = new TimeSpan(0, 4, 30),
            ReleasedDate = new DateTimeOffset(new DateTime(1999, 7, 18)),
            GenreId = 2
        });

        songs.Add(new Song()
        {
            Title = "Song4",
            Duration = new TimeSpan(0, 5, 12),
            ReleasedDate = new DateTimeOffset(new DateTime(2001, 1, 27)),
            GenreId = 4
        });

        songs.Add(new Song()
        {
            Title = "Song5",
            Duration = new TimeSpan(0, 1, 59),
            ReleasedDate = new DateTimeOffset(new DateTime(2013, 7, 11)),
            GenreId = 4
        });

        songs.Add(new Song()
        {
            Title = "Song6",
            Duration = new TimeSpan(0, 3, 19),
            ReleasedDate = new DateTimeOffset(new DateTime(1976, 2, 8)),
            GenreId = 3
        });

        songs.Add(new Song()
        {
            Title = "Song7",
            Duration = new TimeSpan(0, 2, 49),
            ReleasedDate = new DateTimeOffset(new DateTime(2018, 4, 19)),
            GenreId = 4
        });

        await _db.Songs.AddRangeAsync(songs);
        await _db.SaveChangesAsync();

        return songs;
    }

    private async Task InitArtist()
    {
        var artists = new List<Artist>();

        var songs = (List<Song>)await InitSong();

        artists.Add(new Artist()
        {
            Name = "Artist1",
            DateOfBirth = new DateTimeOffset(new DateTime(1995, 12, 6)),
            Phone = "0995322354",
            Email = "email1@gmail.com",
            InstagramUrl = "instagram1",
            Songs = new List<Song>()
            {
                songs[1],
                songs[2]
            }
        });

        artists.Add(new Artist()
        {
            Name = "Artist2",
            DateOfBirth = new DateTimeOffset(new DateTime(2001, 1, 30)),
            Phone = "0995322354",
            Email = "email2@gmail.com",
            Songs = new List<Song>()
            {
                songs[3],
                songs[4]
            }
        });

        artists.Add(new Artist()
        {
            Name = "Artist3",
            DateOfBirth = new DateTimeOffset(new DateTime(1978, 8, 27)),
            Songs = new List<Song>()
            {
                songs[1],
                songs[4]
            }
        });

        artists.Add(new Artist()
        {
            Name = "Artist4",
            DateOfBirth = new DateTimeOffset(new DateTime(1990, 5, 12)),
            Phone = "0995322354",
            InstagramUrl = "instagram4",
            Songs = new List<Song>()
            {
                songs[5]
            }
        });

        artists.Add(new Artist()
        {
            Name = "Artist5",
            DateOfBirth = new DateTimeOffset(new DateTime(1986, 3, 7)),
            Phone = "0995322354",
            Email = "email5@gmail.com",
            InstagramUrl = "instagram5",
            Songs = new List<Song>()
            {
                songs[6],
                songs[7]
            }
        });

        await _db.Artists.AddRangeAsync(artists);
        await _db.SaveChangesAsync();
    }
}