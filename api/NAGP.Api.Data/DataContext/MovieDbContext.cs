using Microsoft.EntityFrameworkCore;
using NAGP.Api.Data.DataModels;

namespace NAGP.Api.Data;

public class MovieDbContext(DbContextOptions options)
    : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
}