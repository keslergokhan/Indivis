using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Url_UrlId",
                table: "Page");

            migrationBuilder.DropForeignKey(
                name: "FK_Url_Url_ParentUrlId",
                table: "Url");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Url_UrlId",
                table: "Page",
                column: "UrlId",
                principalTable: "Url",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Url_Url_ParentUrlId",
                table: "Url",
                column: "ParentUrlId",
                principalTable: "Url",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Page_Url_UrlId",
                table: "Page");

            migrationBuilder.DropForeignKey(
                name: "FK_Url_Url_ParentUrlId",
                table: "Url");

            migrationBuilder.AddForeignKey(
                name: "FK_Page_Url_UrlId",
                table: "Page",
                column: "UrlId",
                principalTable: "Url",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Url_Url_ParentUrlId",
                table: "Url",
                column: "ParentUrlId",
                principalTable: "Url",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
