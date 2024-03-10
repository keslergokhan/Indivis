using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Indivis.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityTableColmn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityDefaultProperty",
                table: "Entity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntityDefaultProperty",
                table: "Entity",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 5);
        }
    }
}
