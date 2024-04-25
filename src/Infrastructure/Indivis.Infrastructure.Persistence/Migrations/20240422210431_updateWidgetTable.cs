using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateWidgetTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MethodName",
                table: "WidgetService");

            migrationBuilder.AddColumn<Guid>(
                name: "PageWidgetSettingId",
                table: "PageWidget",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PageWidget_PageWidgetSettingId",
                table: "PageWidget",
                column: "PageWidgetSettingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PageWidget_PageWidgetSetting_PageWidgetSettingId",
                table: "PageWidget",
                column: "PageWidgetSettingId",
                principalTable: "PageWidgetSetting",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageWidget_PageWidgetSetting_PageWidgetSettingId",
                table: "PageWidget");

            migrationBuilder.DropIndex(
                name: "IX_PageWidget_PageWidgetSettingId",
                table: "PageWidget");

            migrationBuilder.DropColumn(
                name: "PageWidgetSettingId",
                table: "PageWidget");

            migrationBuilder.AddColumn<string>(
                name: "MethodName",
                table: "WidgetService",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 2);
        }
    }
}
