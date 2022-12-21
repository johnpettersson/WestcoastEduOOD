using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WestcoastEdu.BCL.Courses;

namespace WestcoastEdu.Web.Controllers;

public class CourseController : Controller
{

    public IActionResult List()
    {
        List<Course> courses = new List<Course>
        {
            new Course{Code="12-ABC3", Name="LINQ 101", Id=1},
            new Course{Code="13-ABD2", Name="Data och algoritmer", Id=2},
            new Course{Code="14-RCT1", Name="React för nybörjare", Id=3},
            new Course{Code="14-RCT2", Name="React fortsättningskurs", Id=4},
            new Course{Code="14-RCT3", Name="React och mobila enheter", Id=5},
            new Course{Code="15-CSS1", Name="CSS Introduktionskurs", Id=6},
            new Course{Code="15-CSS2", Name="CSS ramverk", Id=7},
            new Course{Code="15-CSS3", Name="Är CSS konst(igt)?", Id=8},
            new Course{Code="16-ETH1", Name="Databaser 101", Id=9},
            new Course{Code="16-ETH2", Name="Databaser 201", Id=10},
            new Course{Code="17-CAT", Name="Egyptologi för nybörjare", Id=11}
        };
        
        return View(courses);
    }

}
