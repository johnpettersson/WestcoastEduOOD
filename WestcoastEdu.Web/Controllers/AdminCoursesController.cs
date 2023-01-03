using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.BCL.Courses;
using WestcoastEdu.Web.Data;

namespace WestcoastEdu.Web.Controllers;


[Route("admin/courses/[action]")]
public class AdminCoursesController : Controller
{
    private readonly WestcoastEduDBContext context;

    public AdminCoursesController(WestcoastEduDBContext context)
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

        if(course is not null)
            return View("Edit", course);

        return Content("Det är tyvärr så att det blev lite fel här.");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Course course) 
    {
        var courseToUpdate = await context.Courses.FirstOrDefaultAsync(course => course.Id == id);
        if(courseToUpdate is null)
            return Content("Det är tyvärr så att det blev lite fel här.");

        courseToUpdate.Name = course.Name;
        courseToUpdate.Code = course.Code;
        context.Courses.Update(courseToUpdate);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(this.List));
    }

    public async Task<IActionResult> Delete(int id) 
    {
        var course = await context.Courses.FirstOrDefaultAsync(course => course.Id == id);

        if(course is not null)
            return View("Delete", course);

        return Content("Det är tyvärr så att det blev lite fel här.");
    }

    [HttpPost, ActionName("delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var course = await context.Courses.FirstOrDefaultAsync(course => course.Id == id);
        if(course is null)
            return Content("Det är tyvärr så att det blev lite fel här.");

        context.Courses.Remove(course);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(this.List));
    }
}