using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NAGP.Api.Data;

var builder = Host.CreateDefaultBuilder()
    .ConfigureLogging(o =>
    {
        o.AddConsole();
    });

builder.ConfigureServices((app, services) =>
{
    services.AddDbContext<MovieDbContext>(o =>
    {
        o.UseNpgsql(
            app.Configuration.GetConnectionString("PostgresConnString"),
            pg =>
            {
                pg.SetPostgresVersion(17, 0);
            });
    })
    .AddTransient<Migrator>();
});

var app = builder.Build();

var loggerFactory = app.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger<Migrator>();
logger.LogInformation("Started");
var migrator = app.Services.GetRequiredService<Migrator>();
await migrator.Migrate();