

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Api.Data;
using WestcoastEdu.Api.Models;
using WestcoastEdu.Api.ViewModels;

namespace WestcoastEdu.Api.Controllers;

[ApiController]
[Route("api/v1/student")]
public class StudentController : ControllerBase
{
    private readonly WestcoastEduContext _context;

    public StudentController(WestcoastEduContext context)
    {
        _context = context;
    }

    [HttpGet("listall")]
    public async Task<ActionResult> List()
    {
        var result = await _context.Students
        .Select(s => new StudentListViewModel {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
        }).ToListAsync();
        return Ok(result);
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        Student? model = await _context.Students.Include(s => s.Courses).SingleOrDefaultAsync(student => student.Id == id);

        if(model is null)
            return NotFound();

        StudentDetailedViewModel viewModel = CreateStudentDetailedViewModel(model);

        return Ok(viewModel);
    }

    [HttpGet("email/{email}")]
    public async Task<ActionResult> GetByEmailAsync(string email)
    {
        Student? model = await _context.Students.Include(s => s.Courses).SingleOrDefaultAsync(student => student.Email == email);

        if(model is null)
            return NotFound();

        StudentDetailedViewModel viewModel = CreateStudentDetailedViewModel(model);

        return Ok(viewModel);
    }

    [HttpGet("personnumber/{personNumber}")]
    public async Task<ActionResult> GetByPersonNumberAsync(string personNumber)
    {

        Student? model = await _context.Students.Include(s => s.Courses).SingleOrDefaultAsync(student => student.PersonNumber == personNumber);

        if(model is null)
            return NotFound();

        StudentDetailedViewModel viewModel = CreateStudentDetailedViewModel(model);

        return Ok(viewModel);
    }

    [HttpPost]
    public async Task<ActionResult> CreateStudentAsync(StudentAddViewModel viewModel)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid body");

        Student student = new Student
        {
            FirstName = viewModel.FirstName!,
            LastName = viewModel.LastName!,
            PersonNumber = viewModel.PersonNumber!,
            Email = viewModel.Email!,
        };

        await _context.Students.AddAsync(student);

        if(await _context.SaveChangesAsync() > 0)
        {
            return CreatedAtAction(nameof(GetById), new { id = student.Id }, null);
        }

        return StatusCode(500);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateStudentAsync(StudentUpdateViewModel viewModel)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid body!");

        Student? student = await _context.Students.SingleOrDefaultAsync(s => s.Id == viewModel.StudentId);

        if(student is null)
            return NotFound();

        // borde aldrig bli null pga ModelState.IsValid-check ovan ^
        student.FirstName = viewModel.FirstName!;
        student.LastName = viewModel.LastName!;
        student.Email = viewModel.Email!;
        student.PersonNumber = viewModel.PersonNumber!;

        _context.Students.Update(student);

        if(await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500);
    }

    [HttpPatch("{studentId}/courses/add/{courseId}")]
    public async Task<ActionResult> AddCourseAsync(int studentId, int courseId)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

        if(course is null)
            return NotFound();

        var student = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == studentId);

        if(student is null)
            return NotFound();

        if(student.Courses!.Contains(course))
            return BadRequest("Student is already added to that course.");

        student.Courses!.Add(course);

        _context.Students.Update(student);

        if(await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500);
    }

    [HttpPatch("{studentId}/courses/remove/{courseId}")]
    public async Task<ActionResult> RemoveCourseAsync(int studentId, int courseId)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

        if(course is null)
            return NotFound();

        var student = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(s => s.Id == studentId);

        if(student is null)
            return NotFound();

        if(!student.Courses!.Contains(course))
            return BadRequest("Student has not been added to that course.");

        student.Courses.Remove(course);
        _context.Students.Update(student);

        if(await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500);
    }

    private StudentDetailedViewModel CreateStudentDetailedViewModel(Student model)
    {
        var viewmodel = new StudentDetailedViewModel
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            PersonNumber = model.PersonNumber,
            Email = model.Email
        };

        if(model.Courses is not null)
        {
            viewmodel.Courses = model.Courses.Select(course => new CourseListViewModel{Id = course.Id, Title = course.Title}).ToList();
        }

        return viewmodel;
    }
 
}