using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Persistence;

namespace Movies.Api.Features.Movies;

public class DeleteMovieCommandHandler(ApplicationDbContext context) : IRequestHandler<DeleteMovieCommand, bool>
{
    public async Task<bool> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
        if (movie is null) return false;

        context.Movies.Remove(movie);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }
}