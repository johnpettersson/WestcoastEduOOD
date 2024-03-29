using Microsoft.AspNetCore.Mvc;
using WestcoastEdu.Web.Models;
using WestcoastEdu.Web.ViewModels;
using WestcoastEdu.Web.Interface;

namespace WestcoastEdu.Web.Controllers;


[Route("admin/courses/[action]")]
public class AdminCoursesController : Controller
{
    private readonly IUnitOfWork unitOfWork;

    public AdminCoursesController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> List() 
    {
        var courses = await unitOfWork.CourseRepository.ListAllAsync();
        return View("Index", courses);
    }

    public IActionResult New()
    {
        CourseCreateViewModel model = new();
        return View("New", model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> New(CourseCreateViewModel viewModel)
    {
        if(viewModel is null)
            return NotFound();

        if(!ModelState.IsValid)
            return View("New", viewModel);


        Course course = new Course
        {
            Code = viewModel.Code,
            Name = viewModel.Name,
            Title = viewModel.Title,
            StartDate = viewModel.StartDate,
            LengthInWeeks = viewModel.LengthInWeeks
        };

        await unitOfWork.CourseRepository.AddAsync(course);
        await unitOfWork.Complete();

        return RedirectToAction(nameof(this.List));
    }

    public async Task<IActionResult> Edit(int id) 
    {
        var course = await unitOfWork.CourseRepository.FindByIdAsync(id);

        if(course is null)
            return NotFound();

        var viewModel = new CourseEditViewModel
        {
            Id = course.Id,
            Name = course.Name,
            Title = course.Title,
            Code = course.Code,
            StartDate = course.StartDate,
            LengthInWeeks = course.LengthInWeeks
        };

        return View("Edit", viewModel);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CourseEditViewModel viewModel) 
    {
        if(!ModelState.IsValid)
            return View("Edit", viewModel);

        var course = await unitOfWork.CourseRepository.FindByIdAsync(id);

        if(course is null)
            return NotFound();

        course.Name = viewModel.Name;
        course.Title = viewModel.Title;
        course.Code = viewModel.Code;
        course.StartDate = viewModel.StartDate;
        course.LengthInWeeks = viewModel.LengthInWeeks;

        await unitOfWork.CourseRepository.UpdateAsync(course);
        await unitOfWork.Complete();


        return RedirectToAction(nameof(this.List));
    }

    public async Task<IActionResult> Delete(int id) 
    {
        var course = await unitOfWork.CourseRepository.FindByIdAsync(id);

        if(course is null)
            return NotFound();

        return View("Delete", course);
    }

    [HttpPost, ActionName("delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var course = await unitOfWork.CourseRepository.FindByIdAsync(id);

        if(course is null)
            return NotFound();

        await unitOfWork.CourseRepository.DeleteAsync(course);
        await unitOfWork.Complete();

        return RedirectToAction(nameof(this.List));
    }
}