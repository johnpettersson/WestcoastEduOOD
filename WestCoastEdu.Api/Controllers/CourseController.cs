


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Api.Data;
using WestcoastEdu.Api.Models;
using WestcoastEdu.Api.ViewModels;

namespace WestcoastEdu.Api.Controllers;

[ApiController]
[Route("api/v1/course")]
public class CourseController : ControllerBase
{
    private readonly WestcoastEduContext _context;

    public CourseController(WestcoastEduContext context)
    {
        _context = context;
    }

    [HttpGet("list")]
    public async Task<ActionResult> ListAsync()
    {
        var result = await _context.Courses
        .Select(c => new CourseListViewModel{
            Id = c.Id,
            Title = c.Title ?? ""
        }).ToListAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetByIdAsync(int id)
    {
        var result = await _context.Courses
        .Include(c => c.Students)
        .Include(c => c.Teacher)
        .Select(c => new CourseDetailedViewModel
        {
            Id = c.Id,
            Completed = c.Completed,
            FullyBooked = c.FullyBooked,
            StartDate = c.StartDate,
            Title = c.Title ?? "",
            Number = c.Number,
            Students = c.Students.Select(student => new StudentListViewModel{
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
            }).ToList()
        }).FirstOrDefaultAsync(c => c.Id == id);

        if(result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("number/{courseNumber}")]
    public async Task<ActionResult> GetByCourseNumberAsync(string courseNumber)
    {
        var result = await _context.Courses
        .Include(c => c.Students)
        .Include(c => c.Teacher)
        .Select(c => new CourseDetailedViewModel
        {
            
            Id = c.Id,
            Completed = c.Completed,
            FullyBooked = c.FullyBooked,
            StartDate = c.StartDate,
            Title = c.Title ?? "",
            Number = c.Number
        }).FirstOrDefaultAsync(c => c.Number == courseNumber);

        if(result is null)
            return NotFound();

        return Ok(result);
    }   

    [HttpGet("title/{title}")]
    public async Task<ActionResult> GetByCourseTitleAsync(string title)
    {
        var result = await _context.Courses
        .Include(c => c.Students)
        .Include(c => c.Teacher)
        .Select(c => new CourseDetailedViewModel
        {
            
            Id = c.Id,
            Completed = c.Completed,
            FullyBooked = c.FullyBooked,
            StartDate = c.StartDate,
            Title = c.Title ?? "",
            Number = c.Number
        }).FirstOrDefaultAsync(c => c.Title == title);

        if(result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("startdate/{date}")]
    public async Task<ActionResult> GetByStartDateAsync(DateTime date)
    {
        //TODO: DEBUGGA DETTA
        var result = await _context.Courses
        .Where(c => c.StartDate.Date == date)
        .Select(c => new CourseListViewModel{
            Id = c.Id,
            Title = c.Title ?? ""
        }).ToListAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCourseAsync(CourseAddViewModel model)
    {
        if(!ModelState.IsValid)
            return BadRequest("Info saknas");

        var exists = await _context.Courses.SingleOrDefaultAsync(c => c.Title == model.Title);

        if(exists is not null)
            return BadRequest($"Det finns redan en kurs med titeln {model.Title}");


        var course = new Course
        {
            Title = model.Title,
            Number = model.Number,
            StartDate = model.StartDate ?? DateTime.MinValue
        };

        await _context.Courses.AddAsync(course);

        if(await _context.SaveChangesAsync() > 0) 
            return Created(nameof(GetByIdAsync), new { id = course.Id });

        return StatusCode(500, "(╯°□°)╯︵ ┻━┻");
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCourse(int id, object model)
    {
        //TODO: Uppdatera kursen 
        return NoContent();
    }

    [HttpPatch("fullybooked/{courseId}")]
    public ActionResult MarkCourseFullyBooked(int courseId)
    {
        //TODO: Updatera kursens isFullyBooked-fält 
        return NoContent();
    }


    [HttpPatch("complete/{courseId}")]
    public ActionResult MarkCourseCompleted(int courseId)
    {
        //TODO: Updatera kursens isCompleted-fält 
        return NoContent();
    }
}