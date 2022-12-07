
using WestCoastEdu.BCL.Courses;

namespace WestCoastEdu.BCL.People;

public class Admin : Person
{
    
    public Teacher CreateTeacher(string firstName, string lastName, string email)
    {
        if(!_authenticated)
            throw new Exception("Must be authenticated to create a teacher");

        //Add a teacher to the system, save it in a database etc
        return new Teacher {FirstName = firstName, LastName = lastName, Email = email };
    }

    public Course CreateCourse(/* params... */)
    {
        if(!_authenticated)
            throw new Exception("Must be authenticated to create a course");

        return new Course();
    }

    public CourseOccasion ScheduleCourse(/* params... */)
    {
        if(!_authenticated)
            throw new Exception("Must be authenticated to schedule a course");

        return new CourseOccasion();
    }

    public void CancelCourse(CourseOccasion occasion)
    {
        if(!_authenticated)
            throw new Exception("Must be authenticated to cancel a course");
        
        //notify the teacher and the students
        //remove the course
    }
}