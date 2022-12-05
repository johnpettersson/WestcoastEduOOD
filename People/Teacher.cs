
using WestCoastEdu.BCL.Courses;

namespace WestCoastEdu.BCL.People;

public class Teacher : Person
{
    public List<CourseOccasion> Courses { get; private set; }

    public void AddLesson(CourseOccasion course, Lesson lesson)
    {
        // Schedule a new lesson to the course
        // Maybe validate the lesson somehow, ie. make sure date is within bounds of the course
        course.Lessons.Add(lesson);
    }
}