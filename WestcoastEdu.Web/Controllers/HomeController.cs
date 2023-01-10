using Microsoft.AspNetCore.Mvc;

namespace WestcoastEdu.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
