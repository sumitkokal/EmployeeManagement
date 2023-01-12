using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class seventhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             
            migrationBuilder.DropColumn(
                name: "GrossAnnualSalary",
                table: "SalaryStructureMaster");

            migrationBuilder.DropColumn(
                name: "OverTime",
                table: "SalaryStructureMaster");

            migrationBuilder.DropColumn(
                name: "WeekendWorked",
                table: "SalaryStructureMaster");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LeaveMaster",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "ApproveRemark",
            //    table: "LeaveMaster",
            //    nullable: true);

            //migrationBuilder.AddColumn<DateTime>(
            //    name: "LeaveApprovedDate",
            //    table: "LeaveMaster",
            //    nullable: false,
            //    defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "LeaveApproveModel",
                columns: table => new
                {
                    LeaveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: true),
                    LeaveType = table.Column<string>(nullable: true),
                    LeaveDateFrom = table.Column<DateTime>(nullable: false),
                    LeaveDateTo = table.Column<DateTime>(nullable: false),
                    LeaveApprovedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    ApproveRemark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApproveModel", x => x.LeaveId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveApproveModel");

            //migrationBuilder.DropColumn(
            //    name: "ApproveRemark",
            //    table: "LeaveMaster");

            //migrationBuilder.DropColumn(
            //    name: "LeaveApprovedDate",
            //    table: "LeaveMaster");

            migrationBuilder.AddColumn<int>(
                name: "GrossAnnualSalary",
                table: "SalaryStructureMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OverTime",
                table: "SalaryStructureMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeekendWorked",
                table: "SalaryStructureMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "LeaveMaster",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            //migrationBuilder.CreateTable(
            //    name: "SalaryMaster",
            //    columns: table => new
            //    {
            //        SalaryId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        BasicPay = table.Column<int>(type: "int", nullable: false),
            //        DA = table.Column<int>(type: "int", nullable: false),
            //        EmployeeId = table.Column<int>(type: "int", nullable: false),
            //        HRA = table.Column<int>(type: "int", nullable: false),
            //        OverTime = table.Column<int>(type: "int", nullable: false),
            //        SalaryStructureId = table.Column<int>(type: "int", nullable: false),
            //        TA = table.Column<int>(type: "int", nullable: false),
            //        WeekendWorked = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SalaryMaster", x => x.SalaryId);
            //    });
        }
    }
}
