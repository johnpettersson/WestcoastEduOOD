

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Api.Data;
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

    [HttpGet("list")]
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

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _context.Students
        .Include(student => student.Course)
        .Select(student => new StudentDetailedViewModel {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            PersonNumber = student.PersonNumber,
            CourseName = student.Course.Title ?? ""
        }).SingleOrDefaultAsync(student => student.Id == id);

        if(result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("email/{email}")]
    public async Task<ActionResult> GetByEmailAsync(string email)
    {
        var result = await _context.Students
        .Include(student => student.Course)
        .Select(student => new StudentDetailedViewModel {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            PersonNumber = student.PersonNumber,
            CourseName = student.Course.Title ?? ""
        }).SingleOrDefaultAsync(student => student.Email == email);

        if(result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("personnumber/{personNumber}")]
    public async Task<ActionResult> GetByPersonNumberAsync(string personNumber)
    {
        var result = await _context.Students
        .Include(student => student.Course)
        .Select(student => new StudentDetailedViewModel {
            Id = student.Id,
            FirstName = student.FirstName,
            LastName = student.LastName,
            Email = student.Email,
            PersonNumber = student.PersonNumber,
            CourseName = student.Course.Title ?? ""
        }).SingleOrDefaultAsync(student => student.PersonNumber == personNumber);

        if(result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public ActionResult CreateStudent(object model)
    {
        //TODO: Skapa en student och spara den 
        return Created("url_to_created_resource", new { message = "CreateStudent fungerar" });
    }

    [HttpPut("{id}")]
    public ActionResult UpdateStudent(int id, object model)
    {
        //TODO: Uppdatera student 
        return NoContent();
    }

    [HttpGet("{studentId}/courses")]
    public ActionResult GetCourses(int studentId)
    {
        //TODO: Hämta alla kurser som studenten har
        return NoContent();
    }


    [HttpPatch("{studentId}/courses/add/{courseId}")]
    public async Task<ActionResult> AddCourseAsync(int courseId, int studentId)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

        if(course is null)
            return NotFound();

        var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentId);

        if(student is null)
            return NotFound();


        student.Course = course;

        if(await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500, "(╯°□°)╯︵ ┻━┻");
    }
}