
namespace WestCoastEdu.BCL.Courses;

public class Lesson
{
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public Course Course { get; set; } 
}