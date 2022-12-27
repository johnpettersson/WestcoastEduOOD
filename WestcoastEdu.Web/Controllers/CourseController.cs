using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.BCL.Courses;
using WestcoastEdu.Web.Data;

namespace WestcoastEdu.Web.Controllers;

public class CourseController : Controller
{
    private readonly WestcoastEduDBContext context;

    public CourseController(WestcoastEduDBContext context)
    {
        this.context = context;
    }

    public async Task<IActionResult> ListAsync()
    {
        List<Course> courses = await context.Courses.ToListAsync();

        return View(courses);
    }
}
