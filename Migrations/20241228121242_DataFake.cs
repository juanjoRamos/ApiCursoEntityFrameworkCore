using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ApiCursoEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class DataFake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActorTable",
                columns: new[] { "Id", "Biografy", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tom Holland" },
                    { 2, null, new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samuel L. Jackson" },
                    { 3, null, new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert Downey Jr." },
                    { 4, null, new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris Evans" },
                    { 5, null, new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dwayne Johnson" },
                    { 6, null, new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Auli'i Cravalho" },
                    { 7, null, new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scarlet Johansson" },
                    { 8, null, new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keanu Reeves" }
                });

            migrationBuilder.InsertData(
                table: "FilmTable",
                columns: new[] { "Id", "GenreId", "InMovie", "Poster", "PremiereDate", "Title" },
                values: new object[,]
                {
                    { 1, null, false, "https://static.posters.cz/image/750/posters/avengers-one-sheet-i12720.jpg", new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avengers" },
                    { 2, null, false, "https://static.posters.cz/image/750/posters/coco-family-i56183.jpg", new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coco" },
                    { 3, null, false, "https://img.ecartelera.com/noticias/70100/70190-c.jpg", new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: No way home" },
                    { 4, null, false, "https://m.media-amazon.com/images/I/91B64g3nQfL.jpg", new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spider-Man: far from home" },
                    { 5, null, true, "https://www.dodmagazine.es/wp-content/uploads/2021/11/the-matrix-resurrection-poster-new.jpg", new DateTime(2100, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix Resurrections" }
                });

            migrationBuilder.InsertData(
                table: "GenreTable",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Animation" },
                    { 3, "Comedy" },
                    { 4, "Science fiction" },
                    { 5, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "MovieTable",
                columns: new[] { "Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, new NpgsqlTypes.NpgsqlPoint(18.482988400331013, -69.939744635201478), "Agora Mall" },
                    { 2, new NpgsqlTypes.NpgsqlPoint(18.482296323201627, -69.911554052933141), "Sambil" },
                    { 3, new NpgsqlTypes.NpgsqlPoint(18.506294943828209, -69.856479387357979), "Megacentro" },
                    { 4, new NpgsqlTypes.NpgsqlPoint(18.469753004268405, -69.938915513982195), "Acropolis" }
                });

            migrationBuilder.InsertData(
                table: "FilmsActorsTable",
                columns: new[] { "ActorId", "FilmId", "Character", "Order" },
                values: new object[,]
                {
                    { 3, 1, "Iron Man", 2 },
                    { 4, 1, "Capitán América", 1 },
                    { 7, 1, "Black Widow", 3 },
                    { 1, 3, "Peter Parker", 1 },
                    { 1, 4, "Peter Parker", 1 },
                    { 2, 4, "Samuel L. Jackson", 2 },
                    { 8, 5, "Neo", 1 }
                });

            migrationBuilder.InsertData(
                table: "FilmsGenreTable",
                columns: new[] { "FilmId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 4 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 3 },
                    { 4, 4 },
                    { 5, 1 },
                    { 5, 4 },
                    { 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "MovieTheaterTable",
                columns: new[] { "Id", "MovieId", "Price", "TypeMovieTheater" },
                values: new object[,]
                {
                    { 1, 1, 2.2m, 1 },
                    { 2, 1, 3.2m, 2 },
                    { 3, 2, 2m, 1 },
                    { 4, 2, 3m, 2 },
                    { 5, 3, 3m, 1 },
                    { 6, 3, 3.5m, 2 },
                    { 7, 3, 4.5m, 3 },
                    { 8, 4, 2.5m, 1 }
                });

            migrationBuilder.InsertData(
                table: "OfferMovieTable",
                columns: new[] { "Id", "EndDate", "MovieId", "PercentageDiscount", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 28, 0, 0, 0, 0, DateTimeKind.Local), 1, 10m, new DateTime(2024, 12, 28, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, new DateTime(2025, 12, 28, 0, 0, 0, 0, DateTimeKind.Local), 4, 15m, new DateTime(2024, 12, 28, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "FilmsMovieTheaterTable",
                columns: new[] { "FilmId", "MovieTheaterId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 5 },
                    { 5, 6 },
                    { 5, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActorTable",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ActorTable",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "FilmsActorsTable",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsActorsTable",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsActorsTable",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsActorsTable",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "FilmsActorsTable",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsActorsTable",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsActorsTable",
                keyColumns: new[] { "ActorId", "FilmId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsGenreTable",
                keyColumns: new[] { "FilmId", "GenreId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "FilmsMovieTheaterTable",
                keyColumns: new[] { "FilmId", "MovieTheaterId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "FilmsMovieTheaterTable",
                keyColumns: new[] { "FilmId", "MovieTheaterId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "FilmsMovieTheaterTable",
                keyColumns: new[] { "FilmId", "MovieTheaterId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "FilmsMovieTheaterTable",
                keyColumns: new[] { "FilmId", "MovieTheaterId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "FilmsMovieTheaterTable",
                keyColumns: new[] { "FilmId", "MovieTheaterId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "FilmsMovieTheaterTable",
                keyColumns: new[] { "FilmId", "MovieTheaterId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "FilmsMovieTheaterTable",
                keyColumns: new[] { "FilmId", "MovieTheaterId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "MovieTheaterTable",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OfferMovieTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OfferMovieTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActorTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ActorTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ActorTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ActorTable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ActorTable",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ActorTable",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "FilmTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FilmTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FilmTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FilmTable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FilmTable",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "GenreTable",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieTable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieTheaterTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieTheaterTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieTheaterTable",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MovieTheaterTable",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieTheaterTable",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieTheaterTable",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MovieTheaterTable",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MovieTable",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieTable",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieTable",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
