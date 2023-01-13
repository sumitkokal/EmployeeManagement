using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class twelvMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "SalaryMaster",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "SalaryMaster",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "SalaryMaster");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "SalaryMaster");
        }
    }
}
