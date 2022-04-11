using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RasmusLabb1.Migrations
{
    public partial class name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaveApplication_Employees_EmployeesEmloyeeId",
                table: "EmployeeLeaveApplication");

            migrationBuilder.RenameColumn(
                name: "EmloyeeId",
                table: "Employees",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeesEmloyeeId",
                table: "EmployeeLeaveApplication",
                newName: "EmployeesEmployeeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "LeaveApplications",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "LeaveApplications",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplicationCreated",
                table: "LeaveApplications",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DateTime");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaveApplication_Employees_EmployeesEmployeeId",
                table: "EmployeeLeaveApplication",
                column: "EmployeesEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLeaveApplication_Employees_EmployeesEmployeeId",
                table: "EmployeeLeaveApplication");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employees",
                newName: "EmloyeeId");

            migrationBuilder.RenameColumn(
                name: "EmployeesEmployeeId",
                table: "EmployeeLeaveApplication",
                newName: "EmployeesEmloyeeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "LeaveApplications",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "LeaveApplications",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplicationCreated",
                table: "LeaveApplications",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLeaveApplication_Employees_EmployeesEmloyeeId",
                table: "EmployeeLeaveApplication",
                column: "EmployeesEmloyeeId",
                principalTable: "Employees",
                principalColumn: "EmloyeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
