


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

    [HttpGet("listall")]
    public async Task<ActionResult> ListAsync()
    {
        var result = await _context.Courses
        .Select(c => new CourseListViewModel
        {
            Id = c.Id,
            Title = c.Title ?? ""
        }).ToListAsync();

        return Ok(result);
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        Course? model = await _context.Courses
        .Include(c => c.Students)
        .Include(c => c.Teacher)
        .FirstOrDefaultAsync(c => c.Id == id);

        if (model is null)
            return NotFound();

        CourseDetailedViewModel viewModel = CreateCourseDetailedViewModel(model);

        return Ok(viewModel);
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

        if (result is null)
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

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("startdate/{date}")]
    public async Task<ActionResult> GetByStartDateAsync(DateTime date)
    {
        var result = await _context.Courses
        .Where(c => c.StartDate.Date == date)
        .Select(c => new CourseListViewModel
        {
            Id = c.Id,
            Title = c.Title ?? ""
        }).ToListAsync();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCourseAsync(CourseAddViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid body!");

        var exists = await _context.Courses.SingleOrDefaultAsync(c => c.Title == model.Title);

        if (exists is not null)
            return BadRequest($"There is already a course with the title: {model.Title}, it has the id: {exists.Id}");

        var course = new Course
        {
            Title = model.Title!, //! pga modelstate.isvalid
            Number = model.Number!,
            StartDate = model.StartDate ?? DateTime.MinValue
        };

        await _context.Courses.AddAsync(course);

        if (await _context.SaveChangesAsync() > 0)
        {
            var routeValues = new { id = course.Id };
            return CreatedAtAction(nameof(GetById), routeValues, null); //skickar med null bara för att nå den överlagrade varianten av CreatedAtAction med routevalues... (╯°□°)╯︵ ┻━┻ 
        }

        return StatusCode(500);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateCourseAsync(CourseUpdateViewModel model)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid body");

        Course? course = await _context.Courses.SingleOrDefaultAsync(c => c.Id == model.CourseId);

        if(course is null)
            return NotFound();


        var exists = await _context.Courses.SingleOrDefaultAsync(c => c.Title == model.Title);

        if (exists is not null && exists.Id != model.CourseId) //den nye titeln finns redan på ett annat id än det vi försöker uppdatera
            return BadRequest($"There is already a course with the title: {model.Title}, it has the id: {exists.Id}");

        // borde aldrig vara null pga ModelState.IsValid-check ovan ^
        course.Title = model.Title!; 
        course.Number = model.Number!;
        course.StartDate = model.StartDate ?? DateTime.MinValue;

        _context.Courses.Update(course);

        if(await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500);
    }

    [HttpPatch("fullybooked/{id}")]
    public async Task<ActionResult> ToggleCourseFullyBookedAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course is null)
            return NotFound();


        course.FullyBooked = !course.FullyBooked;

        _context.Courses.Update(course);

        if (await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500);
    }


    [HttpPatch("complete/{id}")]
    public async Task<ActionResult> ToggleCourseCompletedAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course is null)
            return NotFound();

        course.Completed = !course.Completed;
        _context.Courses.Update(course);

        if (await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500);
    }


    [HttpPatch("{courseId}/teacher/{teacherId}")]
    public async Task<ActionResult> SetTeacherAsync(int courseId, int teacherId)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);

        if (course is null)
            return NotFound();

        var teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Id == teacherId);

        if (teacher is null)
            return NotFound();


        course.Teacher = teacher;

        _context.Courses.Update(course);

        if (await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500, "(╯°□°)╯︵ ┻━┻");
    }

    private CourseDetailedViewModel CreateCourseDetailedViewModel(Course model)
    {
        var viewModel =  new CourseDetailedViewModel
        {
            Id = model.Id,
            Completed = model.Completed,
            FullyBooked = model.FullyBooked,
            StartDate = model.StartDate,
            Title = model.Title,
            Number = model.Number,
        };

        if(model.Students is not null)
        {
            viewModel.Students = model.Students.Select(student => new StudentListViewModel
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName
            }).ToList();
        }

        if(model.Teacher is not null)
        {
            viewModel.TeacherId = model.TeacherId;
            viewModel.TeacherName = $"{model.Teacher.FirstName} {model.Teacher.LastName}";
        }

        return viewModel;
    }
}