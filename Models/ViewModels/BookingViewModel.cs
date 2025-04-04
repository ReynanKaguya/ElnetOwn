using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models.ViewModels
{
    public class BookingViewModel
    {
        public int RoomId { get; set; }  

        // ✅ New Fields for Room Display
        public string RoomName { get; set; } = string.Empty;  
        public string RoomImage { get; set; } = string.Empty;  
        public decimal RoomPrice { get; set; }  

        // ✅ Guest Details
        [Required(ErrorMessage = "Please enter your full name.")]
        public string GuestName { get; set; } = string.Empty;  

        [Required(ErrorMessage = "Please enter a valid email.")]
        [EmailAddress]
        public string GuestEmail { get; set; } = string.Empty;  

        // ✅ Booking Dates
        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckinDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckoutDate { get; set; }

        // ✅ Payment Method
        [Required]
        public string PaymentMethod { get; set; } = "Credit Card";
    }
}