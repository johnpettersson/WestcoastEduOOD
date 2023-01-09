using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Web.Data;
using WestcoastEdu.Web.Interface;
using WestcoastEdu.Web.Models;
using WestcoastEdu.Web.ViewModels;

namespace WestcoastEdu.Web.Controllers;

[Route("admin/users/[action]")]
public class AdminUsersController : Controller
{
    private readonly IUnitOfWork unitOfWork;

    public AdminUsersController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> List() 
    {
        var users = await unitOfWork.UserRepository.ListAllAsync();
        
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

        await unitOfWork.UserRepository.AddAsync(user);
        await unitOfWork.Complete();


        return RedirectToAction(nameof(this.List));
    }

    public async Task<IActionResult> Edit(int id) 
    {
        var user = await unitOfWork.UserRepository.FindByIdAsync(id);

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

        var userToUpdate = await unitOfWork.UserRepository.FindByIdAsync(id);

        if(userToUpdate is null)
            return NotFound();

        userToUpdate.FirstName = viewModel.FirstName;
        userToUpdate.LastName = viewModel.LastName;
        userToUpdate.Email = viewModel.Email;
        userToUpdate.PhoneNumber = viewModel.PhoneNumber;
        userToUpdate.IsTeacher = viewModel.IsTeacher;

        await unitOfWork.UserRepository.UpdateAsync(userToUpdate);
        await unitOfWork.Complete();

        return RedirectToAction(nameof(this.List));
    }

    public async Task<IActionResult> Delete(int id) 
    {
        var user = await unitOfWork.UserRepository.FindByIdAsync(id);

        if(user is null)
            return NotFound();

        return View("Delete", user);
    }

    [HttpPost, ActionName("delete"), ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var user = await unitOfWork.UserRepository.FindByIdAsync(id);

        
        if(user is null)
            return Content("Det är tyvärr så att det blev lite fel här.");
            
        await unitOfWork.UserRepository.DeleteAsync(user);
        await unitOfWork.Complete();
        return RedirectToAction(nameof(this.List));
    }
}