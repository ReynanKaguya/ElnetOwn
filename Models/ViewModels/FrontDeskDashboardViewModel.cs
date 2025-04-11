using HotelManagementSystem.Models; // ✅ This allows access to the Booking model

namespace HotelManagementSystem.ViewModels
{
    public class FrontDeskDashboardViewModel
    {
        public List<Booking> CheckInsToday { get; set; }
        public List<Booking> CurrentlyCheckedIn { get; set; }
    }
}
