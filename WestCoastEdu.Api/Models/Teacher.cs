

using System.ComponentModel.DataAnnotations;

namespace WestcoastEdu.Api.Models;

public class Teacher
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
}