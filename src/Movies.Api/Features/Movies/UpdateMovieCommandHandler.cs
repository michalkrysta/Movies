using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Persistence;

namespace Movies.Api.Features.Movies;

public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, Movie?>
{
    private readonly ApplicationDbContext _context;

    public UpdateMovieCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Movie?> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        if (movie is null) return null;

        movie.Title = request.Title;
        movie.ReleaseDate = request.ReleaseDate;
        await _context.SaveChangesAsync(cancellationToken);
        return movie;
    }
}