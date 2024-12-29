using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCursoEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class TypeMovieTheater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeMovieTheater",
                table: "MovieTheater",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeMovieTheater",
                table: "MovieTheater");
        }
    }
}
