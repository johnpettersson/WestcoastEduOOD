using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Web.Data;
using WestcoastEdu.Web.Models;
using WestcoastEdu.Web.ViewModels;

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
        var viewModel = new UserCreateViewModel();
        return View("New", viewModel);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> New(UserCreateViewModel viewModel)
    {
        if(!ModelState.IsValid)
            return View("New", viewModel);

        User user = new User
        {
            FirstName = viewModel.FirstName,
            LastName = viewModel.LastName,
            Email = viewModel.Email,
            PhoneNumber = viewModel.PhoneNumber,
            IsTeacher = viewModel.IsTeacher
        };

        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();

        return RedirectToAction(nameof(this.List));
    }

    public async Task<IActionResult> Edit(int id) 
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Id == id);

        if(user is null)
            return NotFound();

        UserEditViewModel viewModel = new UserEditViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            IsTeacher = user.IsTeacher
        };

        return View("Edit", user);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UserEditViewModel viewModel) 
    {
        if(!ModelState.IsValid)
            return View("New", viewModel);

        var userToUpdate = await context.Users.FirstOrDefaultAsync(course => course.Id == id);

        if(userToUpdate is null)
            return NotFound();

        userToUpdate.FirstName = viewModel.FirstName;
        userToUpdate.LastName = viewModel.LastName;
        userToUpdate.Email = viewModel.Email;
        userToUpdate.PhoneNumber = viewModel.PhoneNumber;
        userToUpdate.IsTeacher = viewModel.IsTeacher;

        context.Users.Update(userToUpdate);
        await context.SaveChangesAsync();
        return RedirectToAction(nameof(this.List));
    }

    public async Task<IActionResult> Delete(int id) 
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Id == id);

        if(user is null)
            return NotFound();

        return View("Delete", user);
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