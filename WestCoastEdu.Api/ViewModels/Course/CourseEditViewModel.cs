


using System.ComponentModel.DataAnnotations;

namespace WestcoastEdu.Api.ViewModels;

public class CourseEditViewModel : CourseAddViewModel
{
    [Required(ErrorMessage = "Course id is required")]
    public int? CourseId { get; set; } 
}