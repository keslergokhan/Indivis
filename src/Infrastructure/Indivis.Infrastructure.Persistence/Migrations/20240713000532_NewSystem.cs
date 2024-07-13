using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrlSystemType_Entity_EntityId",
                table: "UrlSystemType");

            migrationBuilder.DropTable(
                name: "Url_UrlSystemType");

            migrationBuilder.DropIndex(
                name: "IX_UrlSystemType_EntityId",
                table: "UrlSystemType");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "UrlSystemType");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "UrlSystemType");

            migrationBuilder.AddColumn<Guid>(
                name: "UrlSystemTypeId",
                table: "Url",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Url_UrlSystemTypeId",
                table: "Url",
                column: "UrlSystemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_UrlSystemType_UrlSystemTypeId",
                table: "Url",
                column: "UrlSystemTypeId",
                principalTable: "UrlSystemType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Url_UrlSystemType_UrlSystemTypeId",
                table: "Url");

            migrationBuilder.DropIndex(
                name: "IX_Url_UrlSystemTypeId",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "UrlSystemTypeId",
                table: "Url");

            migrationBuilder.AddColumn<Guid>(
                name: "EntityId",
                table: "UrlSystemType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "UrlSystemType",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_UrlSystemType_EntityId",
                table: "UrlSystemType",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Url_UrlSystemType_UrlSystemTypeId",
                table: "Url_UrlSystemType",
                column: "UrlSystemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_UrlSystemType_Entity_EntityId",
                table: "UrlSystemType",
                column: "EntityId",
                principalTable: "Entity",
                principalColumn: "Id");
        }
    }
}
