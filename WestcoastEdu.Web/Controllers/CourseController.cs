using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Web.Models;
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

    public async Task<IActionResult> Show(int id) 
    {
        Course? course = await context.Courses.FirstOrDefaultAsync(c => c.Id == id);

        if(course is null)
            return NotFound();

        return View("Show", course);
    }
}
