using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddNeedsCleaningToRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NeedsCleaning",
                table: "Rooms",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "NeedsCleaning",
                value: false);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "NeedsCleaning",
                value: false);

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ImageUrl", "Name", "NeedsCleaning", "PricePerNight", "RoomNumber", "RoomType", "Status" },
                values: new object[] { 3, "/img/room3.jpg", "Room3", false, 1800m, "103", "Standard", "Vacant" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "NeedsCleaning",
                table: "Rooms");
        }
    }
}
