using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LocalizationUpdateColmn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWidget",
                table: "Localization",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localization_PageWidget_PageWidgetId",
                table: "Localization");

            migrationBuilder.DropIndex(
                name: "IX_Localization_PageWidgetId",
                table: "Localization");

            migrationBuilder.DropColumn(
                name: "IsWidget",
                table: "Localization");

            migrationBuilder.DropColumn(
                name: "PageWidgetId",
                table: "Localization");
        }
    }
}
