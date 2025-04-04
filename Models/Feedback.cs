using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Your name is required.")]
        public string GuestName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Your email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string GuestEmail { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please provide your feedback.")]
        public string Comments { get; set; } = string.Empty;
        
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
        
        public DateTime DateSubmitted { get; set; } = DateTime.Now;
        
        // New properties to link feedback to a booking
        public int BookingId { get; set; }
        public Booking? Booking { get; set; }
    }
}
