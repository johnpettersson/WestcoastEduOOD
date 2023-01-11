

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WestcoastEdu.Web.ViewModels;

namespace WestcoastEdu.Web.Controllers;


public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    public IActionResult Register() => View("Register", new RegisterViewModel());
    

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if(!ModelState.IsValid)
            return View("Register", model);

        var user = new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email
        };

        var result = await userManager.CreateAsync(user, model.Password!);


        if(result.Succeeded) {
            return RedirectToRoute(new {Controller = "Home", Action = "Index"});
        }

        foreach(var error in result.Errors) {
            ModelState.AddModelError("Register", error.Description);
        }

        return View("Register", model);
    }

    public IActionResult Login([FromQuery]string? returnUrl)
    {
        ViewBag.returnUrl = returnUrl;
        var model = new LoginViewModel();
        return View("login", model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = "/") 
    {
        if(ModelState.IsValid)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, false, false);

            if(result.Succeeded)
                return Redirect(returnUrl);
            else if(result.IsLockedOut)
                ModelState.AddModelError("Login", "Kontot är låst");
            else if(result.IsNotAllowed)
                ModelState.AddModelError("Login", "Gick inte att logga in");
        }

        return View("Login", model);
    }


    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("index", "home");
    }
}