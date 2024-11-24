using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymUniverse.Data.Migrations
{
    /// <inheritdoc />
    public partial class Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b04c7301-c0c6-4a05-a8ba-8bec078cb212", 0, "54054690-f58f-4451-8cea-65f31ad57b3b", "test-user@test.com", false, false, null, null, "TEST-USER", "AQAAAAIAAYagAAAAEAI8y3mdLu0hxFIRUsWng/41KYWFKLeGi2mBDDCsyCoXIaCTj/OU5BTBMkrMHSsUpg==", null, false, "SecurityStampTest01", false, "test-user" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "Administrator", "b04c7301-c0c6-4a05-a8ba-8bec078cb212" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Administrator", "b04c7301-c0c6-4a05-a8ba-8bec078cb212" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212");
        }
    }
}
