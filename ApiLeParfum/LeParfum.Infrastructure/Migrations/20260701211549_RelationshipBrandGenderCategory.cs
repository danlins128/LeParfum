using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeParfum.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipBrandGenderCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "product",
                newName: "GenderId");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "product",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "brand",
                table: "product",
                newName: "BrandId");

            migrationBuilder.RenameIndex(
                name: "IX_product_gender",
                table: "product",
                newName: "IX_product_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_product_category",
                table: "product",
                newName: "IX_product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_product_brand",
                table: "product",
                newName: "IX_product_BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_brand_BrandId",
                table: "product",
                column: "BrandId",
                principalTable: "brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_CategoryId",
                table: "product",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_gender_GenderId",
                table: "product",
                column: "GenderId",
                principalTable: "gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_brand_BrandId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_CategoryId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_gender_GenderId",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "product",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "product",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "product",
                newName: "brand");

            migrationBuilder.RenameIndex(
                name: "IX_product_GenderId",
                table: "product",
                newName: "IX_product_gender");

            migrationBuilder.RenameIndex(
                name: "IX_product_CategoryId",
                table: "product",
                newName: "IX_product_category");

            migrationBuilder.RenameIndex(
                name: "IX_product_BrandId",
                table: "product",
                newName: "IX_product_brand");

            migrationBuilder.CreateIndex(
                name: "IX_stock_product",
                table: "stock",
                column: "product");

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
    }
}
