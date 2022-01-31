namespace Module4HW6.Entities;

public class Song
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public TimeSpan Duration { get; set; }
    public DateTimeOffset ReleasedDate { get; set; }
    public int GenreId { get; set; }
    public Genre Genre { get; set; } = null!;

    public List<Artist> Artists { get; set; } = new List<Artist>();
}