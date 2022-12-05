namespace WestCoastEduBCL.Courses;

public class CourseOccasion
{
    public int Id { get; set; }
    public Course Course { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}