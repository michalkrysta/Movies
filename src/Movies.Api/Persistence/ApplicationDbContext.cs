using Microsoft.EntityFrameworkCore;

namespace Movies.Api.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
}