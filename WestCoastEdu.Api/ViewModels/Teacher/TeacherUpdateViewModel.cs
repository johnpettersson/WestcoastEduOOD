

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestcoastEdu.Api.Models;

public class TeacherUpdateViewModel : TeacherAddViewModel
{
    [Required]
    public int? Id { get; set; }
}