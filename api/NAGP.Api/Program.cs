using Microsoft.AspNetCore.Mvc;
using NAGP.Api.Data.DataModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

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
    var addedMovie = await movieService.AddMovieAsync(m);
    return addedMovie.Id;
})
.WithName("AddMovie");

app.Run();