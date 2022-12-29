using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.BCL.Courses;
using WestcoastEdu.Web.Data;

namespace WestcoastEdu.Web.Controllers;


public class AdminCourses : Controller
{
    private readonly WestcoastEduDBContext context;

    public AdminCourses(WestcoastEduDBContext context)
    {
        this.context = context;
    }

    public async Task<IActionResult> List() 
    {
        var courses = await context.Courses.ToListAsync();

        return View("Index", courses);
    }

    public IActionResult New()
    {
        Course course = new();
        return View("New", course);
    }

    [HttpPost]
    public async Task<IActionResult> New(Course course)
    {
        await context.Courses.AddAsync(course);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(this.List));
    }

    public async Task<IActionResult> Edit(int id) 
    {
        var course = await context.Courses.FirstOrDefaultAsync(course => course.Id == id);

        return View("Edit", course);
    }
}