


using Microsoft.AspNetCore.Mvc;

namespace WestcoastEdu.Api.Controllers;

[ApiController]
[Route("api/v1/[Controller]")]
public class CourseController : ControllerBase
{

    [HttpGet("[action]")]
    public ActionResult List()
    {
        return StatusCode(200, new { message = "Hello World!" });
    }

    [HttpGet("[action]/{id}")]
    public ActionResult GetById(int id)
    {
        return StatusCode(200, new { message = "GetById fungerar", id = id });
    }

    [HttpGet("[action]/{name}")]
    public ActionResult GetByName(string name)
    {
        return StatusCode(200, new { message = "GetByName fungerar", name = name});
    }
}