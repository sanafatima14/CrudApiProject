using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudApiProject.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "report",
                newName: "Report");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Report",
                newName: "report");
        }
    }
}
