
using System.ComponentModel.DataAnnotations;

namespace WestcoastEdu.Web.Models;

public class Course
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Title { get; set; } = "";
    public string Code { get; set; } = "";

    public DateTime StartDate { get; set; }


    public int LengthInWeeks { get; set; }

    //public List<Review> Reviews { get; set; } = new List<Review>();
    //public float AverageReviewValue { get => Reviews.Average(review => review.Value); }
}