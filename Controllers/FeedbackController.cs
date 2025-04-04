using Microsoft.AspNetCore.Mvc;
using HotelManagementSystem.Models;
using System.Threading.Tasks;
using System.Linq;


public class FeedbackController : Controller
{
    private readonly ApplicationDbContext _context;
    
    public FeedbackController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // GET: Feedback/Create
    public IActionResult Create()
    {
        return View();
    }
    
    // POST: Feedback/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Feedback feedback)
    {
        if (ModelState.IsValid)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
            return RedirectToAction("ThankYou");
        }
        return View(feedback);
    }
    
    // GET: Feedback/ThankYou
    public IActionResult ThankYou()
    {
        return View();
    }
    
    // (Optional) GET: Feedback/Index - List all feedback for admins
    public IActionResult Index()
    {
        var feedbacks = _context.Feedbacks.OrderByDescending(f => f.DateSubmitted).ToList();
        return View(feedbacks);
    }
}
