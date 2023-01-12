using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class SixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryMaster",
                columns: table => new
                {
                    SalaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryStructureId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    BasicPay = table.Column<int>(nullable: false),
                    HRA = table.Column<int>(nullable: false),
                    TA = table.Column<int>(nullable: false),
                    DA = table.Column<int>(nullable: false),
                    OverTime = table.Column<int>(nullable: false),
                    WeekendWorked = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryMaster", x => x.SalaryId);
                });

            migrationBuilder.CreateTable(
                name: "SalaryStructureMaster",
                columns: table => new
                {
                    SalaryStructureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    BasicPay = table.Column<int>(nullable: false),
                    HRA = table.Column<int>(nullable: false),
                    TA = table.Column<int>(nullable: false),
                    DA = table.Column<int>(nullable: false),
                    OverTime = table.Column<int>(nullable: false),
                    WeekendWorked = table.Column<int>(nullable: false),
                    GrossSalary = table.Column<int>(nullable: false),
                    GrossAnnualSalary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryStructureMaster", x => x.SalaryStructureId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryMaster");

            migrationBuilder.DropTable(
                name: "SalaryStructureMaster");
        }
    }
}
