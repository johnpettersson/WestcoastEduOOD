
using WestCoastEdu.BCL.Courses;

namespace WestCoastEdu.BCL.People;

public class Student : Person
{
    public List<CourseOccasion> CurrentCourses { get; private set; } = new List<CourseOccasion>();
    public List<CourseOccasion> FinishedCourses { get; private set; } = new List<CourseOccasion>();

    public void JoinCourse(CourseOccasion course)
    {
        // ask course if course has room for new students 
        // register self on the passed course occasion
        // send confirmation email
        CurrentCourses.Add(course);
        course.Students.Add(this);
    }

    public override bool Find(int id)
    {
        if(base.Find(id)) //find the person data
        {
            //find the course data
        }

        return true;
    }

    public override bool Save(int id)
    {
        base.Save(id); //save person properties
        //save students properties

        return true;
    }
}