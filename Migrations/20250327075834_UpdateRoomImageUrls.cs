using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRoomImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Rooms SET ImageUrl = '/img/room1.jpg' WHERE Id = 1");
             migrationBuilder.Sql("UPDATE Rooms SET ImageUrl = '/img/room2.jpg' WHERE Id = 2");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
