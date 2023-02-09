


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestcoastEdu.Api.ViewModels;

public class StudentUpdateViewModel : StudentAddViewModel
{
    [Required(ErrorMessage = "Student id is required")]
    public int? StudentId { get; set; } 
}