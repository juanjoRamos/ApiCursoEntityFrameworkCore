using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCursoEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameTableGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GenrePeople",
                table: "GenrePeople");

            migrationBuilder.RenameTable(
                name: "GenrePeople",
                newName: "GenreTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreTable",
                table: "GenreTable",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreTable",
                table: "GenreTable");

            migrationBuilder.RenameTable(
                name: "GenreTable",
                newName: "GenrePeople");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenrePeople",
                table: "GenrePeople",
                column: "Id");
        }
    }
}
