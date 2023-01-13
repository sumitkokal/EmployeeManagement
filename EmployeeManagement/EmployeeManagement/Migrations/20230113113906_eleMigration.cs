using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class eleMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryMaster",
                columns: table => new
                {
                    SalaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(nullable: true),
                    SalaryStructureId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    BasicPay = table.Column<int>(nullable: false),
                    HRA = table.Column<int>(nullable: false),
                    TA = table.Column<int>(nullable: false),
                    DA = table.Column<int>(nullable: false),
                    OverTime = table.Column<int>(nullable: false),
                    LeavesTaken = table.Column<int>(nullable: false),
                    WeekendWorked = table.Column<int>(nullable: false),
                    GrossSalary = table.Column<int>(nullable: false),
                    TDS = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryMaster", x => x.SalaryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryMaster");
        }
    }
}
