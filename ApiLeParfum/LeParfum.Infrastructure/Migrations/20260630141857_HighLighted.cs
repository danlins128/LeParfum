using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeParfum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HighLighted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHighlighted",
                table: "product",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHighlighted",
                table: "product");
        }
    }
}
