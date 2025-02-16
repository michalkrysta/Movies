using MediatR;
using Movies.Api.Persistence;

namespace Movies.Api.Features.Movies;

public record GetMovieByIdQuery(int Id) : IRequest<Movie?>;