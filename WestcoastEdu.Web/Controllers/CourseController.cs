using Microsoft.AspNetCore.Mvc;
using WestcoastEdu.Web.Models;
using WestcoastEdu.Web.Interface;

namespace WestcoastEdu.Web.Controllers;

public class CourseController : Controller
{
    private readonly IUnitOfWork unitOfWork;

    public CourseController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> ListAsync()
    {
        var courses = await unitOfWork.CourseRepository.ListAllAsync();

        return View(courses);
    }

    public async Task<IActionResult> Show(int id) 
    {
        Course? course = await unitOfWork.CourseRepository.FindByIdAsync(id);

        if(course is null)
            return NotFound();

        return View("Show", course);
    }
}
