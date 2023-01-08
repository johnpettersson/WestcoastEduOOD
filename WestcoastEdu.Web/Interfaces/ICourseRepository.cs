
using WestcoastEdu.Web.Models;

namespace WestcoastEdu.Web.Interface;

public interface ICourseRepository : IRepository<Course>
{
    Task<Course?> FindByCourseNameAsync(string name);
}