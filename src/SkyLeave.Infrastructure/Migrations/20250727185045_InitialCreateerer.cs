using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkyLeave.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateerer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2b$12$tpAcK1BIFHMwdWYYAIAESu3IBjCRA4hhHxAVQSCmf/j2teGletTqK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2b$12$FQD75CKzriTgSr/6RI8e1uuP1oE0t.GO.WUrv11E.K3waf38iBwlW");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
