using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCursoEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class FilmsMovieTheaterAndConventionToDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaterTable_FilmTable_FilmId",
                table: "MovieTheaterTable");

            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropIndex(
                name: "IX_MovieTheaterTable_FilmId",
                table: "MovieTheaterTable");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "MovieTheaterTable");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "PeopleTable",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "FilmTable",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilmsMovieTheaterTable",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "integer", nullable: false),
                    MovieTheaterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsMovieTheaterTable", x => new { x.FilmId, x.MovieTheaterId });
                    table.ForeignKey(
                        name: "FK_FilmsMovieTheaterTable_FilmTable_FilmId",
                        column: x => x.FilmId,
                        principalTable: "FilmTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmsMovieTheaterTable_MovieTheaterTable_MovieTheaterId",
                        column: x => x.MovieTheaterId,
                        principalTable: "MovieTheaterTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmTable_GenreId",
                table: "FilmTable",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsMovieTheaterTable_MovieTheaterId",
                table: "FilmsMovieTheaterTable",
                column: "MovieTheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilmTable_GenreTable_GenreId",
                table: "FilmTable",
                column: "GenreId",
                principalTable: "GenreTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilmTable_GenreTable_GenreId",
                table: "FilmTable");

            migrationBuilder.DropTable(
                name: "FilmsMovieTheaterTable");

            migrationBuilder.DropIndex(
                name: "IX_FilmTable_GenreId",
                table: "FilmTable");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "FilmTable");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "PeopleTable",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "MovieTheaterTable",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilmGenre",
                columns: table => new
                {
                    FilmsId = table.Column<int>(type: "integer", nullable: false),
                    GenresId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmGenre", x => new { x.FilmsId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_FilmGenre_FilmTable_FilmsId",
                        column: x => x.FilmsId,
                        principalTable: "FilmTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmGenre_GenreTable_GenresId",
                        column: x => x.GenresId,
                        principalTable: "GenreTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheaterTable_FilmId",
                table: "MovieTheaterTable",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_GenresId",
                table: "FilmGenre",
                column: "GenresId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaterTable_FilmTable_FilmId",
                table: "MovieTheaterTable",
                column: "FilmId",
                principalTable: "FilmTable",
                principalColumn: "Id");
        }
    }
}
