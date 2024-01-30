using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseTableEntityUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityUrl_Url_fffId",
                table: "EntityUrl");

            migrationBuilder.DropIndex(
                name: "IX_EntityUrl_fffId",
                table: "EntityUrl");

            migrationBuilder.DropColumn(
                name: "fffId",
                table: "EntityUrl");

            migrationBuilder.AddColumn<Guid>(
                name: "UrlId",
                table: "EntityUrl",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EntityUrl_UrlId",
                table: "EntityUrl",
                column: "UrlId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityUrl_Url_UrlId",
                table: "EntityUrl",
                column: "UrlId",
                principalTable: "Url",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntityUrl_Url_UrlId",
                table: "EntityUrl");

            migrationBuilder.DropIndex(
                name: "IX_EntityUrl_UrlId",
                table: "EntityUrl");

            migrationBuilder.DropColumn(
                name: "UrlId",
                table: "EntityUrl");

            migrationBuilder.AddColumn<Guid>(
                name: "fffId",
                table: "EntityUrl",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EntityUrl_fffId",
                table: "EntityUrl",
                column: "fffId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EntityUrl_Url_fffId",
                table: "EntityUrl",
                column: "fffId",
                principalTable: "Url",
                principalColumn: "Id");
        }
    }
}
