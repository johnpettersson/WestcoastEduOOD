

namespace WestcoastEdu.Api.ViewModels;


public class CourseDetailedViewModel
{
    public int Id { get; set; }

    public string Title { get; set; } = "";
    public DateTime StartDate { get; set; }
    public bool FullyBooked { get; set; }
    public bool Completed { get; set; }
    public string? Number { get; set; }

    public ICollection<StudentListViewModel>? Students { get; set; }
}