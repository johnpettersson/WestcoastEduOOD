

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WestcoastEdu.Api.Models;

namespace WestcoastEdu.Api.ViewModels;

public class TeacherListViewModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";

}