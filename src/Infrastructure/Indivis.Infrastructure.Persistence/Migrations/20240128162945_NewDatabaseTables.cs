using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LanguageId",
                table: "Language",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Url",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FullPath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ParentUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Url", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Url_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Url_Url_ParentUrlId",
                        column: x => x.ParentUrlId,
                        principalTable: "Url",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UrlSystemType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false),
                    InterfaceType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrlSystemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Url_UrlSystemType",
                columns: table => new
                {
                    UrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UrlSystemTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Url_UrlSystemType", x => new { x.UrlId, x.UrlSystemTypeId });
                    table.ForeignKey(
                        name: "FK_Url_UrlSystemType_UrlSystemType_UrlSystemTypeId",
                        column: x => x.UrlSystemTypeId,
                        principalTable: "UrlSystemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Url_UrlSystemType_Url_UrlId",
                        column: x => x.UrlId,
                        principalTable: "Url",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Url_LanguageId",
                table: "Url",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Url_ParentUrlId",
                table: "Url",
                column: "ParentUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_Url_UrlSystemType_UrlSystemTypeId",
                table: "Url_UrlSystemType",
                column: "UrlSystemTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Url_UrlSystemType");

            migrationBuilder.DropTable(
                name: "UrlSystemType");

            migrationBuilder.DropTable(
                name: "Url");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "Language");
        }
    }
}
