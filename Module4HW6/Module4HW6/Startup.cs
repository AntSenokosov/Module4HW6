using Module4HW6.Helpers;
using Module4HW6.Queries;

namespace Module4HW6;

public class Startup
{
    public async Task Run(string[] args)
    {
        await using (var db = new SampleContextFactory().CreateDbContext(args))
        {
            var dates = new InitializationDb(db);
            await dates.Init();

            var queries = new QueryClass(db);

            Console.WriteLine("Вывести название песни, имя исполнителя, название жанра песни. Вывести только песни у которых есть жанр и которые поет существующий исполнитель.");
            var query1 = await TransactionDb.Transaction(() => queries.GetGenreSong(), args);

            foreach (var song in query1)
            {
                Console.WriteLine($"{song.Title} {song.Genre.Title}");
                foreach (var artist in song.Artists)
                {
                    Console.Write($"{artist.Name}");
                }
            }

            Console.WriteLine("Вывести кол-во песен в каждом жанре");
            var query2 = await TransactionDb.Transaction(() => queries.CountSongInGenre(), args);

            foreach (var song in query2)
            {
                Console.WriteLine(song);
            }

            Console.WriteLine("Вывести песни, которые были написаны (ReleasedDate) до рождения самого молодого исполнителя.");
            var query3 = await TransactionDb.Transaction(() => queries.GetSongsThanMinYearArtist(), args);

            foreach (var song in query3)
            {
                Console.WriteLine($"{song.Title} {song.ReleasedDate}");
            }
        }
    }
}