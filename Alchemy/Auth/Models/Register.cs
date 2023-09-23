#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace Alchemy.Auth.Models;

public class RegisterUserModel
{
    [Required(ErrorMessage = "The Username field is required.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Username must contain 3 to 100 characters.")]
    public string Username { get; set; }

    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "The Password field is required.")]
    [MinLength(8, ErrorMessage = "The password must contain at least 8 characters.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$%^&+=]).* $", ErrorMessage = "The password must contain at least one uppercase letter, one lowercase letter, one number and one special character.")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "The Confirm Password field is required.")]
    [Compare("Password", ErrorMessage = "Password and password confirmation do not match.")]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; }
}
