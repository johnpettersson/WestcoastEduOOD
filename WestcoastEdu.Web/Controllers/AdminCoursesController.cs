using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Web.Models;
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

        if(course is null)
            return NotFound();

        return View("Edit", course);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Course course) 
    {
        var courseToUpdate = await context.Courses.FirstOrDefaultAsync(course => course.Id == id);
        if(courseToUpdate is null)
            return NotFound();

        courseToUpdate.Name = course.Name;
        courseToUpdate.Title = course.Title;
        courseToUpdate.Code = course.Code;
        courseToUpdate.StartDate = course.StartDate;
        courseToUpdate.LengthInWeeks = course.LengthInWeeks;

        context.Courses.Update(courseToUpdate);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(this.List));
    }

    public async Task<IActionResult> Delete(int id) 
    {
        var course = await context.Courses.FirstOrDefaultAsync(course => course.Id == id);

        if(course is null)
            return NotFound();

        return View("Delete", course);
    }

    [HttpPost, ActionName("delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var course = await context.Courses.FirstOrDefaultAsync(course => course.Id == id);
        if(course is null)
            return NotFound();

        context.Courses.Remove(course);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(this.List));
    }
}