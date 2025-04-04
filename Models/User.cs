using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


public class User : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    public string Role { get; set; } = "Guest"; // Admin, FrontDesk, Housekeeping, Guest
}
