


using System.ComponentModel.DataAnnotations;

namespace WestcoastEdu.Api.Models;

public class Course
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; } 
    public string? Number { get; set; }
    public DateTime StartDate { get; set; }
    public bool FullyBooked { get; set; }
    public bool Completed { get; set; }

}