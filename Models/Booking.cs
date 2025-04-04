using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagementSystem.Models // ✅ Ensured correct namespace
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string GuestName { get; set; } = string.Empty; 

        [Required, EmailAddress]
        public string GuestEmail { get; set; } = string.Empty; 

        [Required]
        public DateTime CheckinDate { get; set; }

        [Required]
        public DateTime CheckoutDate { get; set; }

        public string Status { get; set; } = "Pending"; 

        [ForeignKey("RoomId")]
        public int RoomId { get; set; }

        public Room? Room { get; set; } 

        public bool IsCheckedIn { get; set; } = false;  // ✅ Tracks if the guest has checked in
        
        public bool IsCheckedOut { get; set; } = false; // ✅ Tracks if the guest has checked out


        [Required]
        public string PaymentMethod { get; set; } = "Credit Card"; 

        [NotMapped]
        public decimal TotalPrice 
        {
            get
            {
                if (Room == null) return 0;
                int totalNights = (CheckoutDate - CheckinDate).Days;
                return totalNights * Room.PricePerNight;
            }
        }
    }
}