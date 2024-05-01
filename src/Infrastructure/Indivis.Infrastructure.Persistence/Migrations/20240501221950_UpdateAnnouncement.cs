using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Announcement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeoBreadcrumbTitle",
                table: "Announcement",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AddColumn<string>(
                name: "SeoDescription",
                table: "Announcement",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SeoTitle",
                table: "Announcement",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AddColumn<bool>(
                name: "SitemapNoWrite",
                table: "Announcement",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UrlId",
                table: "Announcement",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "sitemapNoIndex",
                table: "Announcement",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "SeoBreadcrumbTitle",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "SeoDescription",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "SeoTitle",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "SitemapNoWrite",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "UrlId",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "sitemapNoIndex",
                table: "Announcement");
        }
    }
}
