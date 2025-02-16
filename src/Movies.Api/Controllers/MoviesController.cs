using MediatR;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Features.Movies;
using Movies.Api.Persistence;

namespace Movies.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController(IMediator mediator) : ControllerBase
{
    // GET: api/movies
    [HttpGet]
    public async Task<ActionResult<List<Movie>>> Get()
    {
        return Ok(await mediator.Send(new GetMoviesQuery()));
    }

    // GET: api/movies/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Movie>> GetById(int id)
    {
        var movie = await mediator.Send(new GetMovieByIdQuery(id));
        return movie is null ? NotFound() : Ok(movie);
    }

    // POST: api/movies
    [HttpPost]
    public async Task<ActionResult<Movie>> Create(CreateMovieCommand command)
    {
        var movie = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
    }

    // PUT: api/movies/{id}
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Movie>> Update(int id, UpdateMovieCommand command)
    {
        if (id != command.Id) return BadRequest("Mismatched movie id.");

        var updatedMovie = await mediator.Send(command);
        return updatedMovie is null ? NotFound() : Ok(updatedMovie);
    }

    // DELETE: api/movies/{id}
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteMovieCommand(id));
        return result ? NoContent() : NotFound();
    }
}