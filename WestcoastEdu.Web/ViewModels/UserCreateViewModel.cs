

namespace WestcoastEdu.Web.ViewModels;

public class UserCreateViewModel
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public bool IsTeacher { get; set; }
}