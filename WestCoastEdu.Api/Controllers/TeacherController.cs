

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Api.Data;
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

    [HttpGet("list")]
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

    [HttpGet("{id}")]
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


    [HttpPatch("{teacherId}/courses/add/{courseId}")]
    public ActionResult AddCourse(int teacherId, int courseId)
    {
        //TODO: Lägg till kursen på lärarens kurser 
        return NoContent();
    }
}