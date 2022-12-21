
namespace WestcoastEdu.BCL.Courses;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }

    public List<Review> Reviews { get; set; } = new List<Review>();
    public float AverageReviewValue { get => Reviews.Average(review => review.Value); }
}