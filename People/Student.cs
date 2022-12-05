
using WestCoastEdu.BCL.Courses;

namespace WestCoastEdu.BCL.People;

public class Student : Person
{
    public List<CourseOccasion> CurrentCourses { get; private set; }
    public List<CourseOccasion> FinishedCourses { get; private set; } 

    public void JoinCourse(CourseOccasion course)
    {
        // ask course if course has room for new students 
        // register self on the passed course occasion
        // send confirmation email
    }
}