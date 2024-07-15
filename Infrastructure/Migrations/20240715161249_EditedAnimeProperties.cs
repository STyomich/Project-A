using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditedAnimeProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitleOnUkrainian",
                table: "Animes",
                newName: "TitleInUkrainian");

            migrationBuilder.RenameColumn(
                name: "TitleOnRussian",
                table: "Animes",
                newName: "TitleInRussian");

            migrationBuilder.RenameColumn(
                name: "TitleOnEnglish",
                table: "Animes",
                newName: "TitleInEnglish");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TitleInUkrainian",
                table: "Animes",
                newName: "TitleOnUkrainian");

            migrationBuilder.RenameColumn(
                name: "TitleInRussian",
                table: "Animes",
                newName: "TitleOnRussian");

            migrationBuilder.RenameColumn(
                name: "TitleInEnglish",
                table: "Animes",
                newName: "TitleOnEnglish");
        }
    }
}
