using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ApiCursoEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class CreateMovieTheater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferMovieTable_MovieTable_MovieId",
                table: "OfferMovieTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferMovieTable",
                table: "OfferMovieTable");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "MovieTable");

            migrationBuilder.RenameTable(
                name: "OfferMovieTable",
                newName: "OfferMovie");

            migrationBuilder.RenameIndex(
                name: "IX_OfferMovieTable_MovieId",
                table: "OfferMovie",
                newName: "IX_OfferMovie_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferMovie",
                table: "OfferMovie",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "MovieTheater",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric(9,2)", precision: 9, scale: 2, nullable: false),
                    MovieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTheater", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieTheater_MovieTable_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MovieTable",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTheater_MovieId",
                table: "MovieTheater",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferMovie_MovieTable_MovieId",
                table: "OfferMovie",
                column: "MovieId",
                principalTable: "MovieTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferMovie_MovieTable_MovieId",
                table: "OfferMovie");

            migrationBuilder.DropTable(
                name: "MovieTheater");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferMovie",
                table: "OfferMovie");

            migrationBuilder.RenameTable(
                name: "OfferMovie",
                newName: "OfferMovieTable");

            migrationBuilder.RenameIndex(
                name: "IX_OfferMovie_MovieId",
                table: "OfferMovieTable",
                newName: "IX_OfferMovieTable_MovieId");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "MovieTable",
                type: "numeric(9,2)",
                precision: 9,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferMovieTable",
                table: "OfferMovieTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferMovieTable_MovieTable_MovieId",
                table: "OfferMovieTable",
                column: "MovieId",
                principalTable: "MovieTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
