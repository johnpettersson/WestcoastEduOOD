using WestCoastEdu.BCL.People;

namespace WestCoastEdu.BCL.Courses;

public class CourseOccasion
{
    public int Id { get; set; }
    public Course Course { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }

    public List<Lesson> Lessons { get; set; }
    public List<Teacher> Teachers { get; set; }
    public List<Student> Students { get; set; }
}