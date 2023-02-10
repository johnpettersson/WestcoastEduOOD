

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
    public async Task<ActionResult> GetById(int id)
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
            Subjects = teacher.Subjects!.Select(subject => new SubjectSimpleViewModel{Id = subject.Id, Name = subject.Name}).ToList()
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
            Subjects = teacher.Subjects!.Select(subject => new SubjectSimpleViewModel{Id = subject.Id, Name = subject.Name}).ToList()
        }).FirstOrDefaultAsync(teacher => teacher.Email == email);


        if(result is null)
            return NotFound();


        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateTeacherAsync(TeacherAddViewModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest("Invalid body!");

        
        var exists = await _context.Teachers.SingleOrDefaultAsync(teacher => teacher.Email == model.Email);

        if (exists is not null)
            return BadRequest($"There is already a teacher with the email: {model.Email}, it has the id: {exists.Id}");

        var teacher = new Teacher
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email
        };

        await _context.Teachers.AddAsync(teacher);

        if (await _context.SaveChangesAsync() > 0)
        {
            var routeValues = new { id = teacher.Id };
            return CreatedAtAction(nameof(GetById), routeValues, null);
        }

        return StatusCode(500);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateTeacherAsync(TeacherUpdateViewModel model)
    {
        if(!ModelState.IsValid)
            return BadRequest("Invalid body!");

        Teacher? teacher = await _context.Teachers.FindAsync(model.Id);

        if(teacher is null)
            return NotFound();

        // borde aldrig bli null pga ModelState.IsValid-check ovan ^
        teacher.FirstName = model.FirstName!;
        teacher.LastName = model.LastName!;
        teacher.Email = model.Email!;

        _context.Teachers.Update(teacher);

        if(await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500);
    }

    [HttpGet("{teacherId}/courses")]
    public async Task<ActionResult> GetCoursesAsync(int teacherId)
    {
        Teacher? teacher = await _context.Teachers.Include(teacher => teacher.Courses).FirstOrDefaultAsync(teacher => teacher.Id == teacherId);

        if(teacher is null)
            return NotFound();

        var courses = teacher.Courses!.Select(course => new CourseListViewModel
        {
            Id = course.Id,
            Title = course.Title
        }).ToList();

        return Ok(courses);
    }

    [HttpPost("subjects")]
    public async Task<IActionResult> AddSubjectAsync(string subjectName)
    {
        var exists = await _context.Subjects.FirstOrDefaultAsync(subject => subject.Name.ToUpper() == subjectName.ToUpper());
        if(exists is not null)
            return BadRequest($"The subject {subjectName}, it has id {exists.Id}");

        var subject = new Subject { Name = subjectName };
        _context.Subjects.Add(subject);
        if(await _context.SaveChangesAsync() > 0)
            return NoContent(); //TODO: egentligen borde createdAt returneras här men har ingen endpoint för att se subjects just nu.

        return StatusCode(500);
    }


    [HttpPatch("{teacherId}/subjects/add/{subjectName}")]
    public async Task<ActionResult> AddSubjectToTeacherAsync(int teacherId, string subjectName)
    {
        var teacher = await _context.Teachers.Include(t => t.Subjects).FirstOrDefaultAsync(t => t.Id == teacherId);

        if (teacher is null)
            return NotFound();

        Subject? subject = await _context.Subjects.SingleOrDefaultAsync(subject => subject.Name.ToUpper() == subjectName.ToUpper());

        if(subject is null)
        {
            subject = new Subject { Name = subjectName };
            _context.Subjects.Add(subject);
        }

        teacher.Subjects!.Add(subject);

        _context.Teachers.Update(teacher);

        if(await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500);
    }

    [HttpPatch("{teacherId}/subjects/remove/{subjectName}")]
    public async Task<ActionResult> RemoveSubjectFromTeacherAsync(int teacherId, string subjectName)
    {
        var teacher = await _context.Teachers.Include(t => t.Subjects).FirstOrDefaultAsync(t => t.Id == teacherId);

        if (teacher is null)
            return NotFound();

        Subject? subject = await _context.Subjects.SingleOrDefaultAsync(subject => subject.Name.ToUpper() == subjectName.ToUpper());

        if(subject is null)
            return BadRequest("There is no subject with that name");

        var removed = teacher.Subjects!.Remove(subject);

        if(!removed)
            return BadRequest("The teacher does not have that subject added");


        _context.Teachers.Update(teacher);

        if(await _context.SaveChangesAsync() > 0)
            return NoContent();

        return StatusCode(500);
    }
}