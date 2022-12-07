using WestCoastEdu.BCL.People;

namespace WestCoastEdu.BCL.Courses;

public class CourseOccasion
{
    public int Id { get; set; }
    public Course Course { get; set; }  //medvetet val att välja komposition över arv här, pga en kurs kan vara bunden till flera kurstillfällen
    public DateOnly StartDate { get; set; } 
    public DateOnly EndDate { get; set; }

    public bool OnCampus { get; set; }

    public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    public List<Student> Students { get; set; } = new List<Student>();
}