using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models.ViewModels
{
    public class FeedbackViewModel
    {
        [Required]
        public int BookingId { get; set; }
        
        [Required(ErrorMessage = "Your name is required.")]
        public string GuestName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Your email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public string GuestEmail { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please provide your feedback.")]
        public string Comments { get; set; } = string.Empty;
        
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
    }
}
