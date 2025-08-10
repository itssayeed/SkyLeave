using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkyLeave.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "EmployeeName", "EndDate", "LeaveType", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1111, "Alice Johnson", new DateTime(2025, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vacation", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 2111, "Bob Smith", new DateTime(2025, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Medical Leave", new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "$2b$12$tpAcK1BIFHMwdWYYAIAESu3IBjCRA4hhHxAVQSCmf/j2teGletTqK", "Admin", "admin" },
                    { 2, "$2b$12$FQD75CKzriTgSr/6RI8e1uuP1oE0t.GO.WUrv11E.K3waf38iBwlW", "Employee", "emp" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
