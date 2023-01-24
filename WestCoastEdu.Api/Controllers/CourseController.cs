


using Microsoft.AspNetCore.Mvc;

namespace WestcoastEdu.Api.Controllers;

[ApiController]
[Route("api/v1/course")]
public class CourseController : ControllerBase
{
    [HttpGet("list")]
    public ActionResult List()
    {
        //TODO: Hämta alla kurser
        return StatusCode(200, new { message = "Hello World!" });
    }

    [HttpGet("{id}")]
    public ActionResult GetById(int id)
    {
        //TODO: HÄmta kursen som matchar idt
        return StatusCode(200, new { message = "GetById fungerar", id});
    }

    [HttpGet("number/{courseNumber}")]
    public ActionResult GetByCourseNumber(string courseNumber)
    {
        //TODO: Hämta kursen som matchar kursnumret.
        return StatusCode(200, new { message = "GetByCourseNumber fungerar", courseNumber});
    }   

    [HttpGet("title/{title}")]
    public ActionResult GetByCourseTitle(string title)
    {
        //TODO: Hämta kursen som matchar titeln 
        return StatusCode(200, new { message = "GetByCourseTitle fungerar", title});
    }

    [HttpGet("startdate/{date}")]
    public ActionResult GetByStartDate(DateTime date)
    {
        //TODO: Hämta kurser som matchar datumet 
        return StatusCode(200, new { message = "GetByStartDate fungerar", date});
    }

    [HttpPost]
    public ActionResult CreateCourse(object model)
    {
        //TODO: Skapa en kurs och spara den 
        return Created("url_to_created_resource", new { message = "CreateCourse fungerar", model});
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