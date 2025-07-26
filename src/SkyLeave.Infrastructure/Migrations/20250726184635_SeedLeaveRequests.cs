using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkyLeave.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedLeaveRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "Days", "EmployeeId", "EmployeeName", "EndDate", "LeaveType", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, 0, "", "Alice Johnson", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Local), "Vacation", new DateTime(2025, 7, 29, 0, 0, 0, 0, DateTimeKind.Local), "Pending" },
                    { 2, 0, "", "Bob Smith", new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Local), "Medical Leave", new DateTime(2025, 7, 30, 0, 0, 0, 0, DateTimeKind.Local), "Approved" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
