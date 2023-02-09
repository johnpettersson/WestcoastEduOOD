


using System.ComponentModel.DataAnnotations;

namespace WestcoastEdu.Api.ViewModels;

public class CourseUpdateViewModel : CourseAddViewModel
{
    [Required(ErrorMessage = "Course id is required")]
    public int? CourseId { get; set; } 
}