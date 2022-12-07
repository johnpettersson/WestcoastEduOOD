
using WestCoastEdu.BCL.Courses;

namespace WestCoastEdu.BCL.People;

public class Admin : Person
{
    
    public Teacher CreateTeacher(string firstName, string lastName, string email)
    {
        //Add a teacher to the system, save it in a database etc
        if(!_authenticated)
            throw new Exception("Must be authenticated to create a teacher");

        return new Teacher {FirstName = firstName, LastName = lastName, Email = email };
    }

    public Course CreateCourse(/* params... */)
    {
        if(!_authenticated)
            throw new Exception("Must be authenticated to create a course");

        return new Course();
    }

    public void CancelCourse(CourseOccasion occasion)
    {
        if(!_authenticated)
            throw new Exception("Must be authenticated to cancel a course");
        
        //notify the teacher and the students
        //remove the course
    }
}