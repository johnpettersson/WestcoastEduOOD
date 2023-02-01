

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestcoastEdu.Api.Models;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string PersonNumber { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";

    public int CourseId { get; set; }

    [ForeignKey("CourseId")]
    public Course Course { get; set; }
}