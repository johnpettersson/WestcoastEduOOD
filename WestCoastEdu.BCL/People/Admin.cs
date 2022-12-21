
using WestcoastEdu.BCL.Courses;

namespace WestcoastEdu.BCL.People;

public class Admin : Person
{
    
    public Teacher CreateTeacher(string firstName, string lastName, string email)
    {
        CheckAuthentication();

        //Add a teacher to the system, save it in a database etc
        return new Teacher {FirstName = firstName, LastName = lastName, Email = email };
    }

    public Course CreateCourse(/* params... */)
    {
        CheckAuthentication();

        return new Course();
    }

    public CourseOccasion ScheduleCourse(/* params... */)
    {
        CheckAuthentication();

        return new CourseOccasion();
    }

    public void CancelCourse(CourseOccasion occasion)
    {
        CheckAuthentication();

        //notify the teacher and the students
        //remove the course
    }

    
}