using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudApiProject.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_status_user_id",
                table: "orders");

            migrationBuilder.CreateIndex(
                name: "IX_orders_status_id",
                table: "orders",
                column: "status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_status_status_id",
                table: "orders",
                column: "status_id",
                principalTable: "status",
                principalColumn: "status_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_status_status_id",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_status_id",
                table: "orders");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_status_user_id",
                table: "orders",
                column: "user_id",
                principalTable: "status",
                principalColumn: "status_id");
        }
    }
}
