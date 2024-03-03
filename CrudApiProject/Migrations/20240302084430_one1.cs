using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudApiProject.Migrations
{
    /// <inheritdoc />
    public partial class one1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Product_quantity",
                table: "orderProducts",
                newName: "product_quantity");

            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "orderProducts",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "Order_id",
                table: "orderProducts",
                newName: "order_id");

            migrationBuilder.AlterColumn<float>(
                name: "selling_price",
                table: "products",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "actual_price",
                table: "products",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<float>(
                name: "total_cost",
                table: "Orders",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "product_quantity",
                table: "orderProducts",
                newName: "Product_quantity");

            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "orderProducts",
                newName: "Product_id");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "orderProducts",
                newName: "Order_id");

            migrationBuilder.AlterColumn<int>(
                name: "selling_price",
                table: "products",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "actual_price",
                table: "products",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "total_cost",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
