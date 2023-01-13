using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class tenthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "SalaryStructureMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "SalaryStructureMaster");
        }
    }
}
