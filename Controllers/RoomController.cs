using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class RoomsController : Controller
{
    private readonly ApplicationDbContext _context;

    public RoomsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> SearchRooms(DateTime checkin, DateTime checkout, int adults, int children)
    {
        var rooms = await _context.Rooms.ToListAsync();
        return View("Index", rooms); // Dummy data, displays all rooms
    }
}
