using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UrlSystemFixData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsEntity",
                table: "Url",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsEntity",
                table: "PageSystem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UrlSystemTypeId",
                table: "PageSystem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UrlSystemType_EntityId",
                table: "UrlSystemType",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PageSystem_UrlSystemTypeId",
                table: "PageSystem",
                column: "UrlSystemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PageSystem_UrlSystemType_UrlSystemTypeId",
                table: "PageSystem",
                column: "UrlSystemTypeId",
                principalTable: "UrlSystemType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UrlSystemType_Entity_EntityId",
                table: "UrlSystemType",
                column: "EntityId",
                principalTable: "Entity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageSystem_UrlSystemType_UrlSystemTypeId",
                table: "PageSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_UrlSystemType_Entity_EntityId",
                table: "UrlSystemType");

            migrationBuilder.DropIndex(
                name: "IX_UrlSystemType_EntityId",
                table: "UrlSystemType");

            migrationBuilder.DropIndex(
                name: "IX_PageSystem_UrlSystemTypeId",
                table: "PageSystem");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "UrlSystemType");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "UrlSystemType");

            migrationBuilder.DropColumn(
                name: "IsEntity",
                table: "Url");

            migrationBuilder.DropColumn(
                name: "IsEntity",
                table: "PageSystem");

            migrationBuilder.DropColumn(
                name: "UrlSystemTypeId",
                table: "PageSystem");
        }
    }
}
