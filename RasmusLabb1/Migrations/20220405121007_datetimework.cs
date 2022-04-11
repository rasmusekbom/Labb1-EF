using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RasmusLabb1.Migrations
{
    public partial class datetimework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "LeaveApplications",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "LeaveApplications",
                type: "DateTime",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "StartDate",
                table: "LeaveApplications",
                type: "float",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "EndDate",
                table: "LeaveApplications",
                type: "float",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
