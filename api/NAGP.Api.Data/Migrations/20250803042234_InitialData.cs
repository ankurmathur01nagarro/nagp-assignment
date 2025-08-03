using Microsoft.EntityFrameworkCore.Migrations;
using NAGP.Api.Data.DataModels;

#nullable disable

namespace NAGP.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var movies = new[]
            {
                new Movie
                {
                    Id = 1,
                    Name = "Inception",
                    Synopsis = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.",
                    ReleaseDate = new DateTimeOffset(new DateTime(2010, 7, 16)),
                    ImageUrl = "https://example.com/inception.jpg",
                    Rating = 8
                },
                new Movie
                {
                    Id = 2,
                    Name = "The Matrix",
                    Synopsis = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                    ReleaseDate = new DateTimeOffset(new DateTime(1999, 3, 31)),
                    ImageUrl = "https://example.com/matrix.jpg",
                    Rating = 9
                },
                new Movie
                {
                    Id = 3,
                    Name = "Interstellar",
                    Synopsis = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.",
                    ReleaseDate = new DateTimeOffset(new DateTime(2014, 11, 7)),
                    ImageUrl = "https://example.com/interstellar.jpg",
                    Rating = 10
                },
                new Movie
                {
                    Id = 4,
                    Name = "The Dark Knight",
                    Synopsis = "Batman faces the Joker, a criminal mastermind who wants to plunge Gotham City into anarchy.",
                    ReleaseDate = new DateTimeOffset(new DateTime(2008, 7, 18)),
                    ImageUrl = "https://example.com/darkknight.jpg",
                    Rating = 9
                },
                new Movie
                {
                    Id = 5,
                    Name = "Forrest Gump",
                    Synopsis = "The presidencies of Kennedy and Johnson, the Vietnam War, and other history unfold through the perspective of an Alabama man with a low IQ.",
                    ReleaseDate = new DateTimeOffset(new DateTime(1994, 7, 6)),
                    ImageUrl = "https://example.com/forrestgump.jpg",
                    Rating = 8
                },
                new Movie
                {
                    Id = 6,
                    Name = "The Shawshank Redemption",
                    Synopsis = "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
                    ReleaseDate = new DateTimeOffset(new DateTime(1994, 9, 23)),
                    ImageUrl = "https://example.com/shawshank.jpg",
                    Rating = 10
                },
                new Movie
                {
                    Id = 7,
                    Name = "Pulp Fiction",
                    Synopsis = "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                    ReleaseDate = new DateTimeOffset(new DateTime(1994, 10, 14)),
                    ImageUrl = "https://example.com/pulpfiction.jpg",
                    Rating = 9
                },
                new Movie
                {
                    Id = 8,
                    Name = "Avengers: Endgame",
                    Synopsis = "After the devastating events of Infinity War, the Avengers assemble once more to reverse Thanos' actions and restore balance.",
                    ReleaseDate = new DateTimeOffset(new DateTime(2019, 4, 26)),
                    ImageUrl = "https://example.com/endgame.jpg",
                    Rating = 8
                },
                new Movie
                {
                    Id = 9,
                    Name = "Gladiator",
                    Synopsis = "A former Roman General sets out to exact vengeance against the corrupt emperor who murdered his family and sent him into slavery.",
                    ReleaseDate = new DateTimeOffset(new DateTime(2000, 5, 5)),
                    ImageUrl = "https://example.com/gladiator.jpg",
                    Rating = 8
                },
                new Movie
                {
                    Id = 10,
                    Name = "Titanic",
                    Synopsis = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.",
                    ReleaseDate = new DateTimeOffset(new DateTime(1997, 12, 19)),
                    ImageUrl = "https://example.com/titanic.jpg",
                    Rating = 8
                }
            };

            foreach (var movie in movies)
            {
                migrationBuilder.InsertData(
                    table: "Movies",
                    columns: ["Id", "Name", "Synopsis", "ReleaseDate", "ImageUrl", "Rating"],
                    values: [movie.Id, movie.Name, movie.Synopsis, movie.ReleaseDate, movie.ImageUrl, movie.Rating]
                );
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
