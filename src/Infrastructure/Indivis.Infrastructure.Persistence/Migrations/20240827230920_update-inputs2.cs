using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateinputs2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WidgetForm_WidgetFormInput",
                table: "WidgetForm_WidgetFormInput");

            migrationBuilder.DropIndex(
                name: "IX_WidgetForm_WidgetFormInput_WidgetFormId",
                table: "WidgetForm_WidgetFormInput");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WidgetForm_WidgetFormInput",
                table: "WidgetForm_WidgetFormInput",
                columns: new[] { "WidgetFormId", "WidgetFormInputId" });

            migrationBuilder.CreateIndex(
                name: "IX_WidgetForm_WidgetFormInput_WidgetFormInputId",
                table: "WidgetForm_WidgetFormInput",
                column: "WidgetFormInputId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WidgetForm_WidgetFormInput",
                table: "WidgetForm_WidgetFormInput");

            migrationBuilder.DropIndex(
                name: "IX_WidgetForm_WidgetFormInput_WidgetFormInputId",
                table: "WidgetForm_WidgetFormInput");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WidgetForm_WidgetFormInput",
                table: "WidgetForm_WidgetFormInput",
                columns: new[] { "WidgetFormInputId", "WidgetFormId" });

            migrationBuilder.CreateIndex(
                name: "IX_WidgetForm_WidgetFormInput_WidgetFormId",
                table: "WidgetForm_WidgetFormInput",
                column: "WidgetFormId");
        }
    }
}
