using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Persistence;

namespace Movies.Api.Features.Movies;

public class GetMoviesQueryHandler(ApplicationDbContext context) : IRequestHandler<GetMoviesQuery, List<Movie>>
{
    public async Task<List<Movie>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
    {
        return await context.Movies.ToListAsync(cancellationToken);
    }
}