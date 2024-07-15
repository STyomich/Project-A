using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AnimeAdditionalProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Animes",
                newName: "TitleOnUkrainian");

            migrationBuilder.AddColumn<string>(
                name: "TitleOnEnglish",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleOnRussian",
                table: "Animes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TitleOnEnglish",
                table: "Animes");

            migrationBuilder.DropColumn(
                name: "TitleOnRussian",
                table: "Animes");

            migrationBuilder.RenameColumn(
                name: "TitleOnUkrainian",
                table: "Animes",
                newName: "Title");
        }
    }
}
