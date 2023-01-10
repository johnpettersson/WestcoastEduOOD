
using System.ComponentModel.DataAnnotations;

namespace WestcoastEdu.Web.ViewModels;

public class CourseCreateViewModel
{
    [Required]
    [MinLength(10)]
    [StringLength(40)]
    public string Name { get; set; } = "";

    [Required(AllowEmptyStrings = true)]
    [DisplayFormat(ConvertEmptyStringToNull = false)]
    [StringLength(40)]
    public string Title { get; set; } = "";

    [Required]
    [StringLength(10)]
    public string Code { get; set; } = "";

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
    public DateTime StartDate { get; set; } = DateTime.Today;

    [Range(1, Int32.MaxValue)]
    public int LengthInWeeks { get; set; }
}