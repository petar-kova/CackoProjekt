using System.ComponentModel.DataAnnotations;

namespace CackoProjekt.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email je obavezan")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Lozinka je obavezna")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
}
