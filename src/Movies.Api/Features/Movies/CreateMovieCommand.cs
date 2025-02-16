using MediatR;
using Movies.Api.Persistence;

namespace Movies.Api.Features.Movies;

public record CreateMovieCommand(string Title, DateTimeOffset ReleaseDate) : IRequest<Movie>;