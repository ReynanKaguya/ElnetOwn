using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;

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
        var totalGuests = _context.Bookings.Select(b => b.GuestEmail).Distinct().Count();
        var totalRevenue = _context.Bookings
            .Where(b => b.Status == "Checked-out")
            .Include(b => b.Room)
            .Sum(b => b.Room.PricePerNight *
                    EF.Functions.DateDiffDay(b.CheckinDate, b.CheckoutDate));

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
