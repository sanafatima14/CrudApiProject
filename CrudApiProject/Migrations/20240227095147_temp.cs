using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudApiProject.Migrations
{
    /// <inheritdoc />
    public partial class temp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_user_id",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_user_id",
                table: "Orders",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_user_id",
                table: "Orders");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_user_id",
                table: "Orders",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
