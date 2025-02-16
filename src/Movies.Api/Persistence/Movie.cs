namespace Movies.Api.Persistence;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required DateTimeOffset ReleaseDate { get; set; }
}