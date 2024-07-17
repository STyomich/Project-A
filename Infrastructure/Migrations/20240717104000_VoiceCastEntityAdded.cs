using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class VoiceCastEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VoiceCastId",
                table: "Episodes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "VoiceCasts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceCasts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Episodes_VoiceCastId",
                table: "Episodes",
                column: "VoiceCastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Episodes_VoiceCasts_VoiceCastId",
                table: "Episodes",
                column: "VoiceCastId",
                principalTable: "VoiceCasts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_VoiceCasts_VoiceCastId",
                table: "Episodes");

            migrationBuilder.DropTable(
                name: "VoiceCasts");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_VoiceCastId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "VoiceCastId",
                table: "Episodes");
        }
    }
}
