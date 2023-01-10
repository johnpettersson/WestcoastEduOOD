

using System.ComponentModel.DataAnnotations;

namespace WestcoastEdu.Web.ViewModels;

public class UserEditViewModel
{
    public int Id { get; set; }
    
    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string FirstName { get; set; } = "";

    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string LastName { get; set; } = "";

    [EmailAddress]
    public string Email { get; set; } = "";

    [Phone]
    public string PhoneNumber { get; set; } = "";
    
    public bool IsTeacher { get; set; }
}