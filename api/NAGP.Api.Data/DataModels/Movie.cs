
namespace NAGP.Api.Data.DataModels;

public class Movie
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Synopsis { get; set; }

    public DateTimeOffset ReleaseDate { get; set; }

    public string? ImageUrl { get; set; }

    public int Rating { get; set; }
}