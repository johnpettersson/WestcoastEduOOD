using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WestcoastEdu.Web.Controllers;

public class CourseController : Controller
{

    public IActionResult List()
    {
        return View();
    }

}
