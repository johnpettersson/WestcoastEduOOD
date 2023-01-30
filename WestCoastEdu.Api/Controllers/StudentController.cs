

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Api.Data;

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
        var result = await _context.Students.ToListAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(int id)
    {
        var result = await _context.Students.FindAsync(id);

        if(result is null)
            return NotFound();
            
        return Ok(result);
    }

    [HttpGet("email/{email}")]
    public ActionResult GetByEmail(string email)
    {
        //TODO: HÄmta student som matchar idt
        return StatusCode(200, new { message = "GetByEmail fungerar", email });
    }

    [HttpGet("personnumber/{personNumber}")]
    public ActionResult GetByPersonNumber(string personNumber)
    {
        //TODO: HÄmta student som matchar idt
        return StatusCode(200, new { message = "GetByPersonNumber fungerar", personNumber });
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
    public ActionResult AddCourse(int courseId, int studentId)
    {
        //TODO: Lägg till kursen på studentens kurser 
        return NoContent();
    }
}