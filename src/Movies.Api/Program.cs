using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Persistence;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
// Optionally, add the API explorer for minimal APIs
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

// Configure EF Core with an in-memory database (use your production provider as needed)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("MoviesDb"));

// Register MediatR and scan for handlers in the current assembly
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();