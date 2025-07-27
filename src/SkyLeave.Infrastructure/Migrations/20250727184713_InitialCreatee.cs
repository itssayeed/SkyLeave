using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyLeave.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreatee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$07Zp57XZgrrCDdpyb9qvCuGauLgEqneGwjmS0RdijLXn34DoksgD6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$aEYM02Zs1BgC4YWSwviLju6gbBrcC61S7Bshk3CTvQJC8D101uPcO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$KbP7zZRZtE2YGkpJyNfC4uMMfUqEk1CTHIwCQXLv6Ze.h/urHzluu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$RiCo4CrrlNAqYPT.MaHM/uHvRL1jBtoiMCvy.YYzFPwF6cYp5RcZ6");
        }
    }
}
