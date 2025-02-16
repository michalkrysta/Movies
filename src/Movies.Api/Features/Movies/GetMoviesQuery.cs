using MediatR;
using Movies.Api.Persistence;

namespace Movies.Api.Features.Movies;

public record GetMoviesQuery : IRequest<List<Movie>>;