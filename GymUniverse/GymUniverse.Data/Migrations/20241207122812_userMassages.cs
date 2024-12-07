using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymUniverse.Data.Migrations
{
    /// <inheritdoc />
    public partial class userMassages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b897000-ad23-471f-832e-5a41f60b15b0", "AQAAAAIAAYagAAAAEC8zEfs2ybDBd91pYiB3mcwKlbGpMsUrb50NFFOBy7u1BqpIUCvMp6/k9kiaqZ5nyw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "aa3e41be-9906-431f-b2b5-92ec34e00756", "AQAAAAIAAYagAAAAEC0rdj6ysQ3Ku0Zl8hBrysZtXHkPnjKEcHAFQ3WGLPCC7sGl8OI7Uj2Ln7s9ibuTkQ==" });
        }
    }
}
