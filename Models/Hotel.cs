using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models // ✅ Corrected namespace
{
public class Hotel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty; // ✅ Default value

    [Required]
    public string Location { get; set; } = string.Empty; // ✅ Default value

    public string Description { get; set; } = string.Empty; // ✅ Default value

    public string ImageUrl { get; set; } = "default-hotel.jpg"; // ✅ Default value

    public List<Room> Rooms { get; set; } = new List<Room>(); // ✅ Default value
}
}