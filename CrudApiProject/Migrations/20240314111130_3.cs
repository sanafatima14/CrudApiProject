using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudApiProject.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "status_id",
                table: "status",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "roles",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "status",
                newName: "status_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "roles",
                newName: "role_id");

            migrationBuilder.AlterColumn<string>(
                name: "username",
                table: "users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
