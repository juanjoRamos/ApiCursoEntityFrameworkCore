using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCursoEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class FilmsActors2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "MovieTheaterTable",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "GenreTable",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilmsActorsTable",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "integer", nullable: false),
                    ActorId = table.Column<int>(type: "integer", nullable: false),
                    Character = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmsActorsTable", x => new { x.FilmId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_FilmsActorsTable_ActorTable_ActorId",
                        column: x => x.ActorId,
                        principalTable: "ActorTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmsActorsTable_FilmTable_FilmId",
                        column: x => x.FilmId,
                        principalTable: "FilmTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheaterTable_FilmId",
                table: "MovieTheaterTable",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreTable_FilmId",
                table: "GenreTable",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_FilmsActorsTable_ActorId",
                table: "FilmsActorsTable",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreTable_FilmTable_FilmId",
                table: "GenreTable",
                column: "FilmId",
                principalTable: "FilmTable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaterTable_FilmTable_FilmId",
                table: "MovieTheaterTable",
                column: "FilmId",
                principalTable: "FilmTable",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GenreTable_FilmTable_FilmId",
                table: "GenreTable");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaterTable_FilmTable_FilmId",
                table: "MovieTheaterTable");

            migrationBuilder.DropTable(
                name: "FilmsActorsTable");

            migrationBuilder.DropIndex(
                name: "IX_MovieTheaterTable_FilmId",
                table: "MovieTheaterTable");

            migrationBuilder.DropIndex(
                name: "IX_GenreTable_FilmId",
                table: "GenreTable");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "MovieTheaterTable");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "GenreTable");
        }
    }
}
