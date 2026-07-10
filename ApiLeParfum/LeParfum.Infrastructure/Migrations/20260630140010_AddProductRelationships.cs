using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeParfum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProductRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_stock_product",
                table: "stock",
                column: "product");

            migrationBuilder.CreateIndex(
                name: "IX_product_brand",
                table: "product",
                column: "brand");

            migrationBuilder.CreateIndex(
                name: "IX_product_category",
                table: "product",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_product_gender",
                table: "product",
                column: "gender");

            migrationBuilder.AddForeignKey(
                name: "FK_product_brand_brand",
                table: "product",
                column: "brand",
                principalTable: "brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_category",
                table: "product",
                column: "category",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_gender_gender",
                table: "product",
                column: "gender",
                principalTable: "gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_stock_product_product",
                table: "stock",
                column: "product",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_brand_brand",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_category",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_gender_gender",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_stock_product_product",
                table: "stock");

            migrationBuilder.DropIndex(
                name: "IX_stock_product",
                table: "stock");

            migrationBuilder.DropIndex(
                name: "IX_product_brand",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_category",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_gender",
                table: "product");
        }
    }
}
