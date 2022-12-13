
namespace WestCoastEdu.BCL.Courses;

public class Lesson
{
    public DateTime DateTime { get; set; }
    public TimeSpan Duration { get; set; }
    public string Location { get; set; }
    public Course Course { get; set; } 
    public string Title { get; set; }
}