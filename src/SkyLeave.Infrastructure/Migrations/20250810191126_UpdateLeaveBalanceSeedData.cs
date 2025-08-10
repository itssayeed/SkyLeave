using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyLeave.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLeaveBalanceSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1111);

            migrationBuilder.UpdateData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 2111);

            migrationBuilder.UpdateData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 2113);

            migrationBuilder.UpdateData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 2119);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "LeaveBalances",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: 2);
        }
    }
}
