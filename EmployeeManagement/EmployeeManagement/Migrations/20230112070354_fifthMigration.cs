using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Migrations
{
    public partial class fifthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_LeaveMaster_EmployeeMaster_EmployeeId",
            //    table: "LeaveMaster");

            //migrationBuilder.DropTable(
            //    name: "RoleMaster");

            //migrationBuilder.DropIndex(
            //    name: "IX_LeaveMaster_EmployeeId",
            //    table: "LeaveMaster");

            //migrationBuilder.AlterColumn<string>(
            //    name: "MobileNo",
            //    table: "EmployeeMaster",
            //    maxLength: 10,
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(10)",
            //    oldMaxLength: 10);

            //migrationBuilder.AlterColumn<string>(
            //    name: "LastName",
            //    table: "EmployeeMaster",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "FirstName",
            //    table: "EmployeeMaster",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<string>(
            //    name: "EmailId",
            //    table: "EmployeeMaster",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_LeaveMaster",
            //    table: "LeaveMaster",
            //    column: "LeaveId");

            migrationBuilder.CreateTable(
                name: "InvestmentMaster",
                columns: table => new
                {
                    InvestmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(nullable: false),
                    InvestmentType = table.Column<string>(nullable: true),
                    InvestmentName = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentMaster", x => x.InvestmentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvestmentMaster");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_LeaveMaster",
            //    table: "LeaveMaster");

            //migrationBuilder.AlterColumn<string>(
            //    name: "MobileNo",
            //    table: "EmployeeMaster",
            //    type: "nvarchar(10)",
            //    maxLength: 10,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldMaxLength: 10,
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "LastName",
            //    table: "EmployeeMaster",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "FirstName",
            //    table: "EmployeeMaster",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<string>(
            //    name: "EmailId",
            //    table: "EmployeeMaster",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldNullable: true);

            //migrationBuilder.CreateTable(
            //    name: "RoleMaster",
            //    columns: table => new
            //    {
            //        RoleId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EmployeeId = table.Column<int>(type: "int", nullable: false),
            //        RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_RoleMaster", x => x.RoleId);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_LeaveMaster_EmployeeId",
            //    table: "LeaveMaster",
            //    column: "EmployeeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_LeaveMaster_EmployeeMaster_EmployeeId",
            //    table: "LeaveMaster",
            //    column: "EmployeeId",
            //    principalTable: "EmployeeMaster",
            //    principalColumn: "EmployeeId",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
