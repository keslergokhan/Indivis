using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTablePageSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PageSystemId",
                table: "Page",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "PageSystem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    State = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageSystem", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Page_PageSystemId",
                table: "Page",
                column: "PageSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_PageSystem_PageSystemId",
                table: "Page",
                column: "PageSystemId",
                principalTable: "PageSystem",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_PageSystem_PageSystemId",
                table: "Page");

            migrationBuilder.DropTable(
                name: "PageSystem");

            migrationBuilder.DropIndex(
                name: "IX_Page_PageSystemId",
                table: "Page");

            migrationBuilder.DropColumn(
                name: "PageSystemId",
                table: "Page");
        }
    }
}
