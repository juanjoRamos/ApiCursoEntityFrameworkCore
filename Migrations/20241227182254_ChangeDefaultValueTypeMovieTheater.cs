using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiCursoEntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDefaultValueTypeMovieTheater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TypeMovieTheater",
                table: "MovieTheater",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TypeMovieTheater",
                table: "MovieTheater",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);
        }
    }
}
