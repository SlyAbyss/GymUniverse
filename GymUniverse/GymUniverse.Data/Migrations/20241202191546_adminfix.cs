using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymUniverse.Data.Migrations
{
    /// <inheritdoc />
    public partial class adminfix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "aa3e41be-9906-431f-b2b5-92ec34e00756", "GYMADMIN", "AQAAAAIAAYagAAAAEC0rdj6ysQ3Ku0Zl8hBrysZtXHkPnjKEcHAFQ3WGLPCC7sGl8OI7Uj2Ln7s9ibuTkQ==", "gymadmin" });


            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "Administrator", "b04c7301-c0c6-4a05-a8ba-8bec078cb212" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "85753a90-d97e-418c-9865-602ce4721b42", "ADMIN", "AQAAAAIAAYagAAAAECBSmUzlbGiJcI8Ni0g45GG6Cuj2QlnqPXUI6DtMQMrGXtpKIF23/iSWrAXe6l8PQA==", "admin" });
        }
    }
}
