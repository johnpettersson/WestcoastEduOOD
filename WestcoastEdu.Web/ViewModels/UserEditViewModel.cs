

namespace WestcoastEdu.Web.ViewModels;

public class UserEditViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public bool IsTeacher { get; set; }
}