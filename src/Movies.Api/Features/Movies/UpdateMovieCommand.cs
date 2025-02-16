using MediatR;
using Movies.Api.Persistence;

namespace Movies.Api.Features.Movies;

public record UpdateMovieCommand(int Id, string Title, DateTimeOffset ReleaseDate) : IRequest<Movie?>;