using Microsoft.EntityFrameworkCore;
using Module4HW6.Entities;

namespace Module4HW6.Queries;

public class QueryClass
{
    private readonly ApplicationContext _db;

    public QueryClass(ApplicationContext db)
    {
        _db = db;
    }

    // Вывести название песни, имя исполнителя, название жанра песни. Вывести только песни у которых есть жанр и которые поет существующий исполнитель.
    public async Task<IEnumerable<Song>> GetGenreSong()
    {
        var date = await _db.Songs
            .Include(s => s.Artists)
            .Include(s => s.Genre)
            .Where(s => s.Genre != null && s.Artists != null)
            .ToListAsync();

        return date;
    }

    // Вывести кол-во песен в каждом жанре
    public async Task<IEnumerable<string>> CountSongInGenre()
    {
        var date = await _db.Genres
            .Select(g => new
            {
                NameGenre = g.Title,
                SongsCount = g.Songs.Count
            }).ToListAsync();

        var result = date.Select(d => $"{d.NameGenre} {d.SongsCount}".ToString());

        return result.ToList();
    }

    // Вывести песни, которые были написаны (ReleasedDate) до рождения самого молодого исполнителя.
    public async Task<IEnumerable<Song>> GetSongsThanMinYearArtist()
    {
        var artist = await _db.Artists.MaxAsync(a => a.DateOfBirth);

        var date = await _db.Songs
            .Where(s => s.ReleasedDate < artist)
            .ToListAsync();

        return date;
    }
}