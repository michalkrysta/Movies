using MediatR;
using Movies.Api.Persistence;

namespace Movies.Api.Features.Movies;

public class CreateMovieCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateMovieCommand, Movie>
{
    public async Task<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = new Movie
        {
            Title = request.Title,
            ReleaseDate = request.ReleaseDate
        };

        context.Movies.Add(movie);
        await context.SaveChangesAsync(cancellationToken);
        return movie;
    }
}