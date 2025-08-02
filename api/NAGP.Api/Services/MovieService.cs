using Microsoft.EntityFrameworkCore;
using NAGP.Api.Data;
using NAGP.Api.Data.DataModels;

public interface IMovieService
{
    Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken token = default);
    Task<Movie> AddMovieAsync(Movie movie, CancellationToken token = default);
    Task<Movie?> GetMovieByIdAsync(int movieId, CancellationToken token = default);
}

public class MovieService : IMovieService
{
    private readonly MovieDbContext movieDbContext;

    public MovieService(MovieDbContext movieDbContext)
    {
        this.movieDbContext = movieDbContext;
    }

    public async Task<Movie> AddMovieAsync(Movie movie, CancellationToken token = default)
    {
        this.movieDbContext.Add(movie);
        await this.movieDbContext.SaveChangesAsync(token);
        return movie;
    }

    public async Task<Movie?> GetMovieByIdAsync(int movieId, CancellationToken token = default)
    {
        return await this.movieDbContext.FindAsync<Movie>(movieId);
    }

    public async Task<IEnumerable<Movie>> GetMoviesAsync(CancellationToken token = default)
    {
        await this.movieDbContext.Database.EnsureCreatedAsync(token);
        var movies = await this.movieDbContext.Movies.ToListAsync();
        return movies;
    }
}