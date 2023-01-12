using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class eighthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "LeaveApproveModel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LeaveApprovedDate",
                table: "LeaveMaster",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "LeaveApprovedDate",
                table: "LeaveMaster",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            //migrationBuilder.CreateTable(
            //    name: "LeaveApproveModel",
            //    columns: table => new
            //    {
            //        LeaveId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ApproveRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        EmployeeId = table.Column<int>(type: "int", nullable: false),
            //        EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        LeaveApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        LeaveDateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        LeaveDateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LeaveApproveModel", x => x.LeaveId);
            //    });
        }
    }
}
