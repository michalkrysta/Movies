using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Persistence;

namespace Movies.Api.Features.Movies;

public class GetMovieByIdQueryHandler(ApplicationDbContext context) : IRequestHandler<GetMovieByIdQuery, Movie?>
{
    public async Task<Movie?> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        return await context.Movies.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);
    }
}