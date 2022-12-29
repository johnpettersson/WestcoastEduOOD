using Microsoft.AspNetCore.Mvc;

namespace WestcoastEdu.Web.Controllers;


public class AdminController : Controller
{
    public IActionResult Index() 
    {
        return View("Index");
    }
}