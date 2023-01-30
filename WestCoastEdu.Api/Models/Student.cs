

using System.ComponentModel.DataAnnotations;

namespace WestcoastEdu.Api.Models;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string PersonNumber { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
}