using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCursoEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class FilmsGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreTable_FilmTable_FilmId",
                table: "GenreTable");

            migrationBuilder.DropIndex(
                name: "IX_GenreTable_FilmId",
                table: "GenreTable");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "GenreTable");

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

            migrationBuilder.CreateTable(
                name: "FilmsGenreTable",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsGenreTable", x => new { x.FilmId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_FilmsGenreTable_FilmTable_FilmId",
                        column: x => x.FilmId,
                        principalTable: "FilmTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmsGenreTable_GenreTable_GenreId",
                        column: x => x.GenreId,
                        principalTable: "GenreTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmGenre_GenresId",
                table: "FilmGenre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsGenreTable_GenreId",
                table: "FilmsGenreTable",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmGenre");

            migrationBuilder.DropTable(
                name: "FilmsGenreTable");

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "GenreTable",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GenreTable_FilmId",
                table: "GenreTable",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreTable_FilmTable_FilmId",
                table: "GenreTable",
                column: "FilmId",
                principalTable: "FilmTable",
                principalColumn: "Id");
        }
    }
}
