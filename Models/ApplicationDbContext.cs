using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ✅ Assign different images to each room
        modelBuilder.Entity<Room>().HasData(
            new Room 
            { 
                Id = 1, 
                Name = "Room1",
                RoomNumber = "101", 
                RoomType = "Deluxe", 
                PricePerNight = 2500, 
                Status = "Vacant", 
                ImageUrl = "/img/room1.jpg" 
            },
            new Room 
            { 
                Id = 2, 
                Name = "Room2",
                RoomNumber = "102", 
                RoomType = "Suite", 
                PricePerNight = 3500, 
                Status = "Vacant", 
                ImageUrl = "/img/room2.jpg" 
            },
            new Room 
            { 
                Id = 3, 
                Name = "Room3",
                RoomNumber = "103", 
                RoomType = "Standard", 
                PricePerNight = 1800, 
                Status = "Vacant", 
                ImageUrl = "/img/room3.jpg" 
            } 
        );
    }
}
