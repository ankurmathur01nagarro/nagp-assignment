using Microsoft.EntityFrameworkCore;
using NAGP.Api.Data;

public class Migrator
{
    private readonly MovieDbContext movieDbContext;

    public Migrator(MovieDbContext movieDbContext)
    {
        this.movieDbContext = movieDbContext;
    }

    public async Task Migrate()
    {
        await this.movieDbContext.Database.MigrateAsync();
    }
}