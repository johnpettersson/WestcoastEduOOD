


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestcoastEdu.Api.ViewModels;

public class CourseAddViewModel
{
    [Required(ErrorMessage = "Course title is required")]
    [MinLength(5), MaxLength(20)]
    public string? Title { get; set; } 

    [Required(ErrorMessage = "Course number is required")]
    [StringLength(6)]
    public string? Number { get; set; }

    [Required(ErrorMessage = "Course startdate is required")]
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }

}