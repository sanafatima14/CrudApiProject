using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudApiProject.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderid",
                table: "orderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "productid",
                table: "orderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orderProducts_orderid",
                table: "orderProducts",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "IX_orderProducts_productid",
                table: "orderProducts",
                column: "productid");

            migrationBuilder.AddForeignKey(
                name: "FK_orderProducts_Orders_orderid",
                table: "orderProducts",
                column: "orderid",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderProducts_products_productid",
                table: "orderProducts",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderProducts_Orders_orderid",
                table: "orderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_orderProducts_products_productid",
                table: "orderProducts");

            migrationBuilder.DropIndex(
                name: "IX_orderProducts_orderid",
                table: "orderProducts");

            migrationBuilder.DropIndex(
                name: "IX_orderProducts_productid",
                table: "orderProducts");

            migrationBuilder.DropColumn(
                name: "orderid",
                table: "orderProducts");

            migrationBuilder.DropColumn(
                name: "productid",
                table: "orderProducts");
        }
    }
}
