


using System.ComponentModel.DataAnnotations;

namespace WestcoastEdu.Api.Models;

public class Subject
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";

    public ICollection<Teacher>? Teachers { get; set; }

}