using System.ComponentModel.DataAnnotations;

namespace CackoProjekt.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Email je obavezan")]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Lozinka je obavezna")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Lozinka mora imati najmanje 6 znakova")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Potvrda lozinke je obavezna")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "Lozinke se ne podudaraju")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
