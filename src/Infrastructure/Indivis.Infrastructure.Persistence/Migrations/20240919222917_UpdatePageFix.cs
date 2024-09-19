using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePageFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PageWidget_WidgetId",
                table: "PageWidget");

            migrationBuilder.CreateIndex(
                name: "IX_PageWidget_WidgetId",
                table: "PageWidget",
                column: "WidgetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PageWidget_WidgetId",
                table: "PageWidget");

            migrationBuilder.CreateIndex(
                name: "IX_PageWidget_WidgetId",
                table: "PageWidget",
                column: "WidgetId",
                unique: true);
        }
    }
}
