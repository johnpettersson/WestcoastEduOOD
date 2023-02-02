

namespace WestcoastEdu.Api.ViewModels;


public class StudentDetailedViewModel
{
    public int Id { get; set; }
    public string PersonNumber { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";

    public string CourseName { get; set; } = "";
}