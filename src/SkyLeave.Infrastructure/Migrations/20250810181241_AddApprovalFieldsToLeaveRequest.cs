using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyLeave.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddApprovalFieldsToLeaveRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApprovedBy",
                table: "LeaveRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedOn",
                table: "LeaveRequests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1111,
                columns: new[] { "ApprovedBy", "ApprovedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2111,
                columns: new[] { "ApprovedBy", "ApprovedOn" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedBy",
                table: "LeaveRequests");

            migrationBuilder.DropColumn(
                name: "ApprovedOn",
                table: "LeaveRequests");
        }
    }
}
