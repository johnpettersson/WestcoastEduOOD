


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestcoastEdu.Api.ViewModels;

public class StudentAddViewModel
{
    [Required(ErrorMessage = "Student firstname is required")]
    [MinLength(2), MaxLength(30)]
    public string? FirstName { get; set; } 

    [Required(ErrorMessage = "Student firstname is required")]
    [MinLength(2), MaxLength(30)]
    public string? LastName { get; set; } 

    [Required(ErrorMessage = "Student personnumber is required")]
    [MinLength(10), MaxLength(10)]
    public string? PersonNumber { get; set; } 

    [Required(ErrorMessage = "Student email is required")]
    [EmailAddress]
    public string? Email { get; set; } 
}