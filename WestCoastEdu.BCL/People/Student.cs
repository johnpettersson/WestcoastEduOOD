
using WestCoastEdu.BCL.Courses;

namespace WestCoastEdu.BCL.People;

public class Student : Person
{
    /// <summary>
    /// A list of course occasions the student is currently enrolled into
    /// </summary>
    public List<CourseOccasion> CurrentCourses { get; private set; } = new List<CourseOccasion>();

    /// <summary>
    /// A list of the courses the student has finished.
    /// </summary>
    public List<CourseOccasion> FinishedCourses { get; private set; } = new List<CourseOccasion>();


    /// <summary>
    /// Tracks if the student is enrolled in the monthly subscription package
    /// </summary>
    public bool IsSubscribed { get; set; }

    /// <summary>
    /// A list of on-demand courses the student has bought
    /// </summary>
    public List<Course> PurchasedCourses { get; private set; } = new List<Course>();


    public void JoinCourse(CourseOccasion course)
    {
        CheckAuthentication();
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
            //find the course data and other student properties
        }

        return true;
    }

    public override bool Save()
    {
        if(!base.Save())
            return false;

        //save person properties
        //save students properties
        return true;
    }
}