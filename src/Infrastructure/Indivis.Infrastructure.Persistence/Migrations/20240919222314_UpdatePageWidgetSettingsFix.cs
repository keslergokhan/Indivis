using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePageWidgetSettingsFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PageWidgetSetting_WidgetTemplateId",
                table: "PageWidgetSetting");

            migrationBuilder.CreateIndex(
                name: "IX_PageWidgetSetting_WidgetTemplateId",
                table: "PageWidgetSetting",
                column: "WidgetTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PageWidgetSetting_WidgetTemplateId",
                table: "PageWidgetSetting");

            migrationBuilder.CreateIndex(
                name: "IX_PageWidgetSetting_WidgetTemplateId",
                table: "PageWidgetSetting",
                column: "WidgetTemplateId",
                unique: true);
        }
    }
}
