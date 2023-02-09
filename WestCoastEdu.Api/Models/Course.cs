


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestcoastEdu.Api.Models;

public class Course
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Number { get; set; } = "";
    public DateTime StartDate { get; set; }
    public bool FullyBooked { get; set; }
    public bool Completed { get; set; }

    public int? TeacherId { get; set; }

    [ForeignKey("TeacherId")]
    public Teacher? Teacher { get; set; }

    public ICollection<Student>? Students { get; set; }
}