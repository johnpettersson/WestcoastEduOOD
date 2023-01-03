using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.BCL.Courses;
using WestcoastEdu.Web.Data;
using WestcoastEdu.Web.Models;

namespace WestcoastEdu.Web.Controllers;

[Route("admin/users/[action]")]
public class AdminUsersController : Controller
{
    private readonly WestcoastEduDBContext context;

    public AdminUsersController(WestcoastEduDBContext context)
    {
        this.context = context;
    }

    public async Task<IActionResult> List() 
    {
        var users = await context.Users.ToListAsync();

        return View("Index", users);
    }

    public IActionResult New()
    {
        User user = new();
        return View("New", user);
    }

    [HttpPost]
    public async Task<IActionResult> New(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(this.List));
    }

    public async Task<IActionResult> Edit(int id) 
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Id == id);

        if(user is not null)
            return View("Edit", user);

        return Content("Det är tyvärr så att det blev lite fel här.");
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, User user) 
    {
        var userToUpdate = await context.Users.FirstOrDefaultAsync(course => course.Id == id);

        if(userToUpdate is null)
            return Content("Det är tyvärr så att det blev lite fel här.");

        userToUpdate.FirstName = user.FirstName;
        userToUpdate.LastName = user.LastName;
        userToUpdate.Email = user.Email;
        userToUpdate.PhoneNumber = user.PhoneNumber;
        userToUpdate.IsTeacher = user.IsTeacher;

        context.Users.Update(userToUpdate);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(this.List));
    }

    public async Task<IActionResult> Delete(int id) 
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Id == id);

        if(user is not null)
            return View("Delete", user);

        return Content("Det är tyvärr så att det blev lite fel här.");
    }

    [HttpPost, ActionName("delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var userInSet = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        
        if(userInSet is null)
            return Content("Det är tyvärr så att det blev lite fel här.");

        context.Users.Remove(userInSet);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(this.List));
    }
}