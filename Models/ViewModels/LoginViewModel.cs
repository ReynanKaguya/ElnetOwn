using System.ComponentModel.DataAnnotations;

namespace HotelManagementSystem.Models.ViewModels
{
    public class LoginViewModel
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;  // Initialized

    [Required, DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;  // Initialized

    public bool RememberMe { get; set; }
}
}
