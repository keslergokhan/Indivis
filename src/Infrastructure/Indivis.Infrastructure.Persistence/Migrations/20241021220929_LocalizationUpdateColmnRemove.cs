using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LocalizationUpdateColmnRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localization_PageWidget_PageWidgetId",
                table: "Localization");

            migrationBuilder.DropIndex(
                name: "IX_Localization_PageWidgetId",
                table: "Localization");

            migrationBuilder.DropColumn(
                name: "PageWidgetId",
                table: "Localization");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PageWidgetId",
                table: "Localization",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Localization_PageWidgetId",
                table: "Localization",
                column: "PageWidgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Localization_PageWidget_PageWidgetId",
                table: "Localization",
                column: "PageWidgetId",
                principalTable: "PageWidget",
                principalColumn: "Id");
        }
    }
}
