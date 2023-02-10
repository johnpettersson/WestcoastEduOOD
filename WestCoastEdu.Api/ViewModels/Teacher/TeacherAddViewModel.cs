

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestcoastEdu.Api.Models;

public class TeacherAddViewModel
{
    [Required, MinLength(2), MaxLength(30)]
    public string FirstName { get; set; } = "";

    [Required, MinLength(2), MaxLength(30)]
    public string LastName { get; set; } = "";

    [Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; } = "";

}