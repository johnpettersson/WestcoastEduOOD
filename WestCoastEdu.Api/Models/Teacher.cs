

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestcoastEdu.Api.Models;

public class Teacher
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";

    
    public virtual ICollection<Course>? Courses { get; set; }

    public virtual ICollection<Subject>? Subjects { get; set; }

}