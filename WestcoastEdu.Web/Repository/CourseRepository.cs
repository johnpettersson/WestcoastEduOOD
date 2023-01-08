
using WestcoastEdu.Web.Interface;
using WestcoastEdu.Web.Models;
using WestcoastEdu.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace WestcoastEdu.Web.Repository;



public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(WestcoastEduDBContext context) : base(context)
    {
    }

    public async Task<Course?> FindByCourseNameAsync(string name)
    {
        return await context.Courses.SingleOrDefaultAsync(course => course.Name == name);
    }
}