using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using HotelManagementSystem.Models.ViewModels;
using HotelManagementSystem.Models;

public class BookingsController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ✅ Load Booking Form
    [HttpGet]
    public IActionResult Create(int roomId)
    {
        var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
        if (room == null) return NotFound();

        var model = new BookingViewModel
        {
            RoomId = roomId,
            RoomName = room.Name,
            RoomImage = room.ImageUrl,
            RoomPrice = room.PricePerNight,
            CheckinDate = DateTime.Today,
            CheckoutDate = DateTime.Today.AddDays(1),
            PaymentMethod = "Credit Card"
        };

        return View(model);
    }

    // ✅ Check-in a Guest
public async Task<IActionResult> CheckIn(int id)
{
    var booking = await _context.Bookings.FindAsync(id);
    if (booking == null) return NotFound();

    booking.IsCheckedIn = true;
    booking.Status = "Checked-in";
    await _context.SaveChangesAsync();

    return RedirectToAction("PendingBookings");
}
[HttpGet]
public IActionResult GiveFeedback(int bookingId)
{
    var booking = _context.Bookings.Find(bookingId);
    if (booking == null) return NotFound();

    var model = new FeedbackViewModel
    {
        BookingId = bookingId,
        GuestName = booking.GuestName,
        // Optionally, prepopulate GuestEmail if needed:
        GuestEmail = booking.GuestEmail
    };

    return View(model);
}
public IActionResult FeedbackSuccess()
{
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> SubmitFeedback(FeedbackViewModel model)
{
    if (!ModelState.IsValid)
        return View("GiveFeedback", model);

    var feedback = new Feedback
    {
        BookingId = model.BookingId,
        GuestName = model.GuestName,
        // Optionally, set GuestEmail if you include it in your view model:
        GuestEmail = model.GuestEmail,
        Comments = model.Comments,
        Rating = model.Rating
    };

    _context.Feedbacks.Add(feedback);
    await _context.SaveChangesAsync();

    return RedirectToAction("FeedbackSuccess");
}

// ✅ Check-out a Guest
public async Task<IActionResult> CheckOut(int id)
{
    var booking = await _context.Bookings.FindAsync(id);
    if (booking == null) return NotFound();

    booking.IsCheckedOut = true;
    booking.Status = "Checked-out";
    await _context.SaveChangesAsync();

    return RedirectToAction("PendingBookings");
}
    // ✅ Show Only the Logged-in User's Bookings
public IActionResult MyBookings()
{
    var userEmail = User.Identity.Name; // ✅ Get the logged-in user's email
    var userBookings = _context.Bookings
        .Include(b => b.Room)
        .Where(b => b.GuestEmail == userEmail)
        .ToList();

    return View(userBookings);
}
public IActionResult ViewFeedbacks()
{
    var feedbacks = _context.Feedbacks.Include(f => f.Booking).ToList();
    return View(feedbacks);
}


    // ✅ Handle Booking Submission
    // ✅ Handle Booking Submission
// ✅ Handle Booking Submission
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Book(BookingViewModel model)
{
    if (!ModelState.IsValid)
    {
        return View("Create", model);
    }

    var room = await _context.Rooms.FindAsync(model.RoomId);
    if (room == null)
    {
        return NotFound("Room not found.");
    }

    var booking = new Booking
    {
        GuestName = model.GuestName,
        GuestEmail = model.GuestEmail,
        RoomId = model.RoomId,
        CheckinDate = model.CheckinDate,
        CheckoutDate = model.CheckoutDate,
        PaymentMethod = model.PaymentMethod,
        Status = "Pending" // Set status to Pending for guest bookings
    };

    _context.Bookings.Add(booking);
    await _context.SaveChangesAsync();

    return RedirectToAction("BookingConfirmed", "Bookings", new { id = booking.Id });
}


// ✅ Show Booking Confirmation Page
public IActionResult BookingConfirmed(int id)
{
    var booking = _context.Bookings.Include(b => b.Room).FirstOrDefault(b => b.Id == id);
    if (booking == null) return NotFound("Booking not found.");

    return View(booking);
}
// ✅ Download Invoice (Placeholder)
public IActionResult DownloadInvoice(int id)
{
    var booking = _context.Bookings.Include(b => b.Room).FirstOrDefault(b => b.Id == id);
    if (booking == null) return NotFound("Booking not found.");

    var invoiceText = $"Invoice for {booking.GuestName}\n" +
                      $"Room: {booking.Room?.Name}\n" +
                      $"Check-in: {booking.CheckinDate}\n" +
                      $"Check-out: {booking.CheckoutDate}\n" +
                      $"Total Price: {booking.TotalPrice}";

    var bytes = System.Text.Encoding.UTF8.GetBytes(invoiceText);
    return File(bytes, "text/plain", "Invoice.txt"); // ✅ Download as .txt file (You can upgrade this to PDF later)
}
            // ✅ Approve a Booking
public async Task<IActionResult> Approve(int id)
{
    var booking = await _context.Bookings.FindAsync(id);
    if (booking == null) return NotFound();

    booking.Status = "Approved";
    await _context.SaveChangesAsync();
    
    return RedirectToAction("PendingBookings");
}

// ✅ Reject a Booking
public async Task<IActionResult> Reject(int id)
{
    var booking = await _context.Bookings.FindAsync(id);
    if (booking == null) return NotFound();

    booking.Status = "Rejected";
    await _context.SaveChangesAsync();
    
    return RedirectToAction("PendingBookings");
}

// ✅ View Booking Details
public async Task<IActionResult> View(int id)
{
    var booking = await _context.Bookings.Include(b => b.Room).FirstOrDefaultAsync(b => b.Id == id);
    if (booking == null) return NotFound();

    return View(booking);
}

    // ✅ Show All Bookings (Admin View)
    public IActionResult Index()
    {
        var bookings = _context.Bookings.Include(b => b.Room).ToList();
        return View(bookings);
    }

         // ✅ Show Only Pending Bookings
        public IActionResult PendingBookings()
        {
            var pendingBookings = _context.Bookings.Include(b => b.Room)
                .Where(b => b.Status == "Pending")
                .ToList();

            return View(pendingBookings); // ✅ This view must exist!
        }
}
