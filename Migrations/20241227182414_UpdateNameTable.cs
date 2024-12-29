using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCursoEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheater_MovieTable_MovieId",
                table: "MovieTheater");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferMovie_MovieTable_MovieId",
                table: "OfferMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferMovie",
                table: "OfferMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTheater",
                table: "MovieTheater");

            migrationBuilder.RenameTable(
                name: "OfferMovie",
                newName: "OfferMovieTable");

            migrationBuilder.RenameTable(
                name: "MovieTheater",
                newName: "MovieTheaterTable");

            migrationBuilder.RenameIndex(
                name: "IX_OfferMovie_MovieId",
                table: "OfferMovieTable",
                newName: "IX_OfferMovieTable_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieTheater_MovieId",
                table: "MovieTheaterTable",
                newName: "IX_MovieTheaterTable_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferMovieTable",
                table: "OfferMovieTable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTheaterTable",
                table: "MovieTheaterTable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheaterTable_MovieTable_MovieId",
                table: "MovieTheaterTable",
                column: "MovieId",
                principalTable: "MovieTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferMovieTable_MovieTable_MovieId",
                table: "OfferMovieTable",
                column: "MovieId",
                principalTable: "MovieTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieTheaterTable_MovieTable_MovieId",
                table: "MovieTheaterTable");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferMovieTable_MovieTable_MovieId",
                table: "OfferMovieTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OfferMovieTable",
                table: "OfferMovieTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieTheaterTable",
                table: "MovieTheaterTable");

            migrationBuilder.RenameTable(
                name: "OfferMovieTable",
                newName: "OfferMovie");

            migrationBuilder.RenameTable(
                name: "MovieTheaterTable",
                newName: "MovieTheater");

            migrationBuilder.RenameIndex(
                name: "IX_OfferMovieTable_MovieId",
                table: "OfferMovie",
                newName: "IX_OfferMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieTheaterTable_MovieId",
                table: "MovieTheater",
                newName: "IX_MovieTheater_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OfferMovie",
                table: "OfferMovie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieTheater",
                table: "MovieTheater",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieTheater_MovieTable_MovieId",
                table: "MovieTheater",
                column: "MovieId",
                principalTable: "MovieTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferMovie_MovieTable_MovieId",
                table: "OfferMovie",
                column: "MovieId",
                principalTable: "MovieTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
