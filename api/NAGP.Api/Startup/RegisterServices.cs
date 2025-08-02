using Microsoft.EntityFrameworkCore;
using NAGP.Api.Data;

public static class StartupExtensions
{
    public static void RegisterServices(this IHostApplicationBuilder app)
    {
        var services = app.Services;
        var isDev = app.Environment.IsDevelopment();
        services.AddDbContextPool<MovieDbContext>(o =>
        {
            o.UseNpgsql(
                app.Configuration.GetConnectionString("PostgresConnString"),
                pg =>
                {
                    pg.SetPostgresVersion(17, 0);
                })
            .EnableDetailedErrors(isDev)
            .EnableSensitiveDataLogging(isDev);
        })
        .AddTransient<IMovieService, MovieService>();
    }
}