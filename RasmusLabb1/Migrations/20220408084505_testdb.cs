using Microsoft.EntityFrameworkCore.Migrations;

namespace RasmusLabb1.Migrations
{
    public partial class testdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeLeaveApplication");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_EmployeeId",
                table: "LeaveApplications",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveApplications_Employees_EmployeeId",
                table: "LeaveApplications",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveApplications_Employees_EmployeeId",
                table: "LeaveApplications");

            migrationBuilder.DropIndex(
                name: "IX_LeaveApplications_EmployeeId",
                table: "LeaveApplications");

            migrationBuilder.CreateTable(
                name: "EmployeeLeaveApplication",
                columns: table => new
                {
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false),
                    LeaveApplicationsLeaveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLeaveApplication", x => new { x.EmployeesEmployeeId, x.LeaveApplicationsLeaveId });
                    table.ForeignKey(
                        name: "FK_EmployeeLeaveApplication_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLeaveApplication_LeaveApplications_LeaveApplicationsLeaveId",
                        column: x => x.LeaveApplicationsLeaveId,
                        principalTable: "LeaveApplications",
                        principalColumn: "LeaveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLeaveApplication_LeaveApplicationsLeaveId",
                table: "EmployeeLeaveApplication",
                column: "LeaveApplicationsLeaveId");
        }
    }
}
