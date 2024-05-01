using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnnouncement2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Announcement_UrlId",
                table: "Announcement",
                column: "UrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_Url_UrlId",
                table: "Announcement",
                column: "UrlId",
                principalTable: "Url",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_Url_UrlId",
                table: "Announcement");

            migrationBuilder.DropIndex(
                name: "IX_Announcement_UrlId",
                table: "Announcement");
        }
    }
}
