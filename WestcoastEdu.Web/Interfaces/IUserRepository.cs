
using WestcoastEdu.Web.Models;

namespace WestcoastEdu.Web.Interface;

public interface IUserRepository : IRepository<User>
{
    Task<User?> FindByEmailAsync(string email);
}