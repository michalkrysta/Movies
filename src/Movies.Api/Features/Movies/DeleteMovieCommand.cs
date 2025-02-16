using MediatR;

namespace Movies.Api.Features.Movies;

public record DeleteMovieCommand(int Id) : IRequest<bool>;