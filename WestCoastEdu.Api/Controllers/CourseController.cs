


using Microsoft.AspNetCore.Mvc;

namespace WestcoastEdu.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
public class CourseController : ControllerBase
{

    [HttpGet("list")]
    public ActionResult List()
    {
        return StatusCode(200, new { message = "Hello World!" });
    }

    [HttpGet("id/{id}")]
    public ActionResult GetById(int id)
    {
        return StatusCode(200, new { message = "GetById fungerar", id});
    }

    [HttpGet("number/{courseNumber}")]
    public ActionResult GetByCourseNumber(string courseNumber)
    {
        return StatusCode(200, new { message = "GetByCourseNumber fungerar", courseNumber});
    }   

    [HttpGet("title/{title}")]
    public ActionResult GetByCourseTitle(string title)
    {
        return StatusCode(200, new { message = "GetByCourseTitle fungerar", title});
    }

    [HttpGet("startdate/{date}")]
    public ActionResult GetByStartDate(DateTime date)
    {
        return StatusCode(200, new { message = "GetByStartDate fungerar", date});
    }

    [HttpPost]
    public ActionResult CreateCourse()
    {
        return Created("uri123", new { message = "CreateCourse fungerar"});
    }

    [HttpPut]
    public ActionResult UpdateCourse()
    {
        return NoContent();
    }

    [HttpPatch("markfullybooked/{courseId}")]
    public ActionResult MarkCourseFullyBooked(int courseId)
    {
        return NoContent();
    }


    [HttpPatch("markcomplete/{courseId}")]
    public ActionResult MarkCourseCompleted(int courseId)
    {
        return NoContent();
    }

}