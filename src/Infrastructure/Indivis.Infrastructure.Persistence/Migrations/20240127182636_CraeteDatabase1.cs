using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CraeteDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Culture = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FLag = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Sort = table.Column<byte>(type: "tinyint", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
