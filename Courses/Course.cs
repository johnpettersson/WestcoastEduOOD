
namespace WestCoastEdu.BCL.Courses;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public List<CourseReview> Reviews { get; set; } = new List<CourseReview>();
    public float AverageReviewValue { get => Reviews.Average((review) => review.Value); }
}