using System.ComponentModel.DataAnnotations;

namespace WestcoastEdu.Web.ViewModels;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string? ConfirmPassword { get; set; }
}