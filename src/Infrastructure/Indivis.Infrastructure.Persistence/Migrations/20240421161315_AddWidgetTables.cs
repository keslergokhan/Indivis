using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddWidgetTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageWidgetSetting",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClassCustom = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Grid = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, defaultValue: "col-12"),
                    IsAsync = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsShow = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Order = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageWidgetSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageZone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageZone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageZone_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageZone_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Widget",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Widget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Widget_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WidgetService",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WidgetServiceClassName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageWidget",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageZoneId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WidgetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageWidget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageWidget_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PageWidget_PageZone_PageZoneId",
                        column: x => x.PageZoneId,
                        principalTable: "PageZone",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PageWidget_Widget_WidgetId",
                        column: x => x.WidgetId,
                        principalTable: "Widget",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WidgetTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Template = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WidgetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WidgetServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WidgetTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WidgetTemplate_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WidgetTemplate_WidgetService_WidgetServiceId",
                        column: x => x.WidgetServiceId,
                        principalTable: "WidgetService",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WidgetTemplate_Widget_WidgetId",
                        column: x => x.WidgetId,
                        principalTable: "Widget",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PageWidget_LanguageId",
                table: "PageWidget",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageWidget_PageZoneId",
                table: "PageWidget",
                column: "PageZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_PageWidget_WidgetId",
                table: "PageWidget",
                column: "WidgetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PageZone_LanguageId",
                table: "PageZone",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_PageZone_PageId",
                table: "PageZone",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Widget_LanguageId",
                table: "Widget",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetTemplate_LanguageId",
                table: "WidgetTemplate",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetTemplate_WidgetId",
                table: "WidgetTemplate",
                column: "WidgetId");

            migrationBuilder.CreateIndex(
                name: "IX_WidgetTemplate_WidgetServiceId",
                table: "WidgetTemplate",
                column: "WidgetServiceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageWidget");

            migrationBuilder.DropTable(
                name: "PageWidgetSetting");

            migrationBuilder.DropTable(
                name: "WidgetTemplate");

            migrationBuilder.DropTable(
                name: "PageZone");

            migrationBuilder.DropTable(
                name: "WidgetService");

            migrationBuilder.DropTable(
                name: "Widget");
        }
    }
}
