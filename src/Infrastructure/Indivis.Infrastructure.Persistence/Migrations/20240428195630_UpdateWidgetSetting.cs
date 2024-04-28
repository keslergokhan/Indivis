using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateWidgetSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WidgetTemplateId",
                table: "PageWidgetSetting",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PageWidgetSetting_WidgetTemplateId",
                table: "PageWidgetSetting",
                column: "WidgetTemplateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PageWidgetSetting_WidgetTemplate_WidgetTemplateId",
                table: "PageWidgetSetting",
                column: "WidgetTemplateId",
                principalTable: "WidgetTemplate",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageWidgetSetting_WidgetTemplate_WidgetTemplateId",
                table: "PageWidgetSetting");

            migrationBuilder.DropIndex(
                name: "IX_PageWidgetSetting_WidgetTemplateId",
                table: "PageWidgetSetting");

            migrationBuilder.DropColumn(
                name: "WidgetTemplateId",
                table: "PageWidgetSetting");
        }
    }
}
