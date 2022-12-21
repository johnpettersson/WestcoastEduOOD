
using WestcoastEdu.BCL.Courses;

namespace WestcoastEdu.BCL.People;

public class Teacher : Person
{
    public List<CourseOccasion> Courses { get; private set; } = new List<CourseOccasion>();

    public void AddLesson(CourseOccasion course, Lesson lesson)
    {
        CheckAuthentication();
        // Schedule a new lesson to the course
        // Maybe validate the lesson somehow, ie. make sure date is within bounds of the course
        course.Lessons.Add(lesson);
    }

    public override bool Find(int id)
    {
        if(base.Find(id)) //find the person data
        {
            //find the Courses data
        }

        return true;
    }

    public override bool Save()
    {
        if(!base.Save())
            return false;

        //save teacher properties
        return true;
    }
}