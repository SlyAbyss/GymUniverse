using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymUniverse.Data.Migrations
{
    /// <inheritdoc />
    public partial class RoomEquipments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Rooms_RoomId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_RoomId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Equipment");

            migrationBuilder.CreateTable(
                name: "RoomsEquipments",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsEquipments", x => new { x.RoomId, x.EquipmentId });
                    table.ForeignKey(
                        name: "FK_RoomsEquipments_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomsEquipments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0fe7a753-cc38-40cb-ae94-14e1e0c00071", "AQAAAAIAAYagAAAAEANNoujrYba2EtYBNHF3dvB1xmcBeqfPW1Ur1BITavF/iHCi/H9U7sdauHOVlietVA==" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomsEquipments_EquipmentId",
                table: "RoomsEquipments",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomsEquipments");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Equipment",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c7301-c0c6-4a05-a8ba-8bec078cb212",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "782e3cbd-f971-4cb9-b6ec-c5d90d8b0907", "AQAAAAIAAYagAAAAEC4KLeMr/yKwluA/taci5Ym7G96DaWX5KKrkxCg3VpkMxIehJiALCkeugInT8nMmzg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RoomId",
                table: "Equipment",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Rooms_RoomId",
                table: "Equipment",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id");
        }
    }
}
