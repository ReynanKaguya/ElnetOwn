using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelManagementSystem.Models;
using HotelManagementSystem.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers
{
    public class FrontDeskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FrontDeskController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult CleaningTasks()
            {
                var dirtyRooms = _context.Rooms.Where(r => r.NeedsCleaning).ToList();
                return View(dirtyRooms);
            }
            [HttpPost]
            public async Task<IActionResult> MarkCleaned(int id)
            {
                var room = await _context.Rooms.FindAsync(id);
                if (room == null) return NotFound();

                room.NeedsCleaning = false;
                await _context.SaveChangesAsync();

                return RedirectToAction("CleaningTasks");
            }

        public IActionResult Dashboard()
        {
            var today = DateTime.Today;

            var checkinsToday = _context.Bookings
                .Include(b => b.Room)
                .Where(b => b.CheckinDate == today && b.Status == "Approved")
                .ToList();

            var currentlyCheckedIn = _context.Bookings
                .Include(b => b.Room)
                .Where(b => b.Status == "Checked-in")
                .ToList();

            var model = new FrontDeskDashboardViewModel
            {
                CheckInsToday = checkinsToday,
                CurrentlyCheckedIn = currentlyCheckedIn
            };

            return View(model);
        }
    }
}
