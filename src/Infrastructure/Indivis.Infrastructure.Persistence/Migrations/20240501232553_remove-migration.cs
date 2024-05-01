using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Page_UrlId",
                table: "Page");

            migrationBuilder.CreateIndex(
                name: "IX_Page_UrlId",
                table: "Page",
                column: "UrlId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Page_UrlId",
                table: "Page");

            migrationBuilder.CreateIndex(
                name: "IX_Page_UrlId",
                table: "Page",
                column: "UrlId",
                unique: true);
        }
    }
}
