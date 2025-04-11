using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;


[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
{
    var totalBookings = _context.Bookings.Count();

    var totalGuests = _context.Bookings
        .Select(b => b.GuestEmail)
        .Distinct()
        .Count();

    var checkedOutBookings = _context.Bookings
        .Where(b => b.Status == "Checked-out")
        .Include(b => b.Room)
        .ToList();

    decimal totalRevenue = 0;

    foreach (var booking in checkedOutBookings)
    {
        var days = (booking.CheckoutDate - booking.CheckinDate).Days;

        if (days <= 0)
            days = 1; // Safeguard to avoid zero or negative days

        totalRevenue += booking.Room.PricePerNight * days;
    }

    var averageRating = _context.Feedbacks.Any()
        ? _context.Feedbacks.Average(f => f.Rating)
        : 0;

    ViewBag.TotalBookings = totalBookings;
    ViewBag.TotalGuests = totalGuests;
    ViewBag.TotalRevenue = totalRevenue;
    ViewBag.AverageRating = Math.Round(averageRating, 1);

    return View();
}

}
