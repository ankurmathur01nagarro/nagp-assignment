using Microsoft.AspNetCore.Mvc;
using NAGP.Api.Data.DataModels;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();

var api = app.MapGroup("/api");

api.MapGet("/movies", async ([FromServices] IMovieService movieService) =>
{
    return await movieService.GetMoviesAsync();
})
.WithName("GetMovies");

api.MapGet("/movie/{movieId}", async (int movieId, [FromServices] IMovieService movieService) =>
{
    return await movieService.GetMovieByIdAsync(movieId);
})
.WithName("GetMovie");

api.MapPost("/movie", async ([FromBody] Movie m, [FromServices] IMovieService movieService) =>
{
    Movie addedMovie;
    if (m.Id > 0)
    {
        addedMovie = await movieService.UpdateMovieAsync(m);
    }
    else
    {
        addedMovie = await movieService.AddMovieAsync(m);
    }
    return addedMovie.Id;
})
.WithName("AddMovie");

app.Run();