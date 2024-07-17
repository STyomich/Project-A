using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedVoiceCastPinEditedRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Episodes_VoiceCasts_VoiceCastId",
                table: "Episodes");

            migrationBuilder.DropIndex(
                name: "IX_Episodes_VoiceCastId",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Episodes");

            migrationBuilder.DropColumn(
                name: "VoiceCastId",
                table: "Episodes");

            migrationBuilder.CreateTable(
                name: "VoiceCastPins",
                columns: table => new
                {
                    EpisodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoiceCastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoiceCastPins", x => new { x.EpisodeId, x.VoiceCastId });
                    table.ForeignKey(
                        name: "FK_VoiceCastPins_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoiceCastPins_VoiceCasts_VoiceCastId",
                        column: x => x.VoiceCastId,
                        principalTable: "VoiceCasts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VoiceCastPins_VoiceCastId",
                table: "VoiceCastPins",
                column: "VoiceCastId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VoiceCastPins");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Episodes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "VoiceCastId",
                table: "Episodes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
    }
}
