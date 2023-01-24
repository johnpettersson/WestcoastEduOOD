

using Microsoft.AspNetCore.Mvc;

namespace WestcoastEdu.Api.Controllers;

[ApiController]
[Route("api/v1/teacher")]
public class TeacherController : ControllerBase
{
    [HttpGet("list")]
    public ActionResult List()
    {
        //TODO: Hämta alla lärare
        return StatusCode(200, new { message = "List fungerar" });
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        //TODO: Hämta läraren som matchar idt
        return StatusCode(200, new { message = "GetById fungerar", id });
    }

    [HttpGet("email/{email}")]
    public ActionResult GetByEmail(string email)
    {
        //TODO: Hämta läraren som matchar emailen
        return StatusCode(200, new { message = "GetByEmail fungerar", email });
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