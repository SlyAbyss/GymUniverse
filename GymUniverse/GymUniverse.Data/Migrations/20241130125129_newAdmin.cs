using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymUniverse.Data.Migrations
{
    /// <inheritdoc />
    public partial class newAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_LocationId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Locations_LocationId",
                table: "Trainers");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Trainers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "782e3cbd-f971-4cb9-b6ec-c5d90d8b0907", "gymadmin@gymuniverse.com", "GYMADMIN@GYMUNIVERSE.COM", "ADMIN", "AQAAAAIAAYagAAAAEC4KLeMr/yKwluA/taci5Ym7G96DaWX5KKrkxCg3VpkMxIehJiALCkeugInT8nMmzg==", "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_LocationId",
                table: "Rooms",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Locations_LocationId",
                table: "Trainers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Locations_LocationId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainers_Locations_LocationId",
                table: "Trainers");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Trainers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Rooms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "54054690-f58f-4451-8cea-65f31ad57b3b", "test-user@test.com", null, "TEST-USER", "AQAAAAIAAYagAAAAEAI8y3mdLu0hxFIRUsWng/41KYWFKLeGi2mBDDCsyCoXIaCTj/OU5BTBMkrMHSsUpg==", "test-user" });

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Locations_LocationId",
                table: "Rooms",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainers_Locations_LocationId",
                table: "Trainers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
