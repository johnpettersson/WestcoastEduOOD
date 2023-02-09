

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Api.Data;
using WestcoastEdu.Api.Models;
using WestcoastEdu.Api.ViewModels;

namespace WestcoastEdu.Api.Controllers;

[ApiController]
[Route("api/v1/teacher")]
public class TeacherController : ControllerBase
{
    private readonly WestcoastEduContext _context;

    public TeacherController(WestcoastEduContext context)
    {
        _context = context;
    }

    [HttpGet("listall")]
    public async Task<ActionResult> ListAsync()
    {
        var result = await _context.Teachers.Select(teacher => new TeacherListViewModel
        {
            Id = teacher.Id,
            Email = teacher.Email,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
        }).ToListAsync();

        return Ok(result);
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        var result = await _context.Teachers
        .Include(t => t.Courses)
        .Include(t => t.Subjects)
        .Select(teacher => new TeacherDetailedViewModel
        {
            Id = teacher.Id,
            Email = teacher.Email,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Courses = teacher.Courses!.Select(course => new CourseListViewModel
            {
                Id = course.Id,
                Title = course.Title!,
            }).ToList(),
            Subjects = teacher.Subjects
        }).FirstOrDefaultAsync(teacher => teacher.Id == id);


        if(result is null)
            return NotFound();


        return Ok(result);
    }

    [HttpGet("email/{email}")]
    public async Task<ActionResult> GetByEmailAsync(string email)
    {
        var result = await _context.Teachers
        .Include(t => t.Courses)
        .Include(t => t.Subjects)
        .Select(teacher => new TeacherDetailedViewModel
        {
            Id = teacher.Id,
            Email = teacher.Email,
            FirstName = teacher.FirstName,
            LastName = teacher.LastName,
            Courses = teacher.Courses!.Select(course => new CourseListViewModel
            {
                Id = course.Id,
                Title = course.Title!,
            }).ToList(),
            Subjects = teacher.Subjects
        }).FirstOrDefaultAsync(teacher => teacher.Email == email);


        if(result is null)
            return NotFound();


        return Ok(result);
    }

    [HttpPost]
    public ActionResult CreateTeacher(object model)
    {
        //TODO: Skapa en lärare och spara den 
        return Created("url_to_created_resource", new { message = "CreateTeacher fungerar", model });
    }

    [HttpPut("{id}")]
    public ActionResult UpdateTeacher(int id, object model)
    {
        //TODO: Uppdatera lärare 
        return NoContent();
    }

    [HttpGet("{teacherId}/courses")]
    public ActionResult GetCourses(int teacherId)
    {
        //TODO: Hämta alla kurser som läraren har
        return StatusCode(200, new { message = "GetCourses fungerar", teacherId });
    }



    [HttpPatch("{teacherId}/subjects/add/{subjectName}")]
    public async Task<ActionResult> AddCourseAsync(int teacherId, string subjectName)
    {


        var teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Id == teacherId);

        if (teacher is null)
            return NotFound();

        var subject = new Subject { Name = subjectName ?? "" };

        _context.Subjects.Add(subject);

        if(teacher.Subjects is null)
            teacher.Subjects = new List<Subject>();

        teacher.Subjects.Add(subject);

        _context.Teachers.Update(teacher);

        if(await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500, "(╯°□°)╯︵ ┻━┻");
    }
}