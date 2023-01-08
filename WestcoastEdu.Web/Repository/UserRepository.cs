

using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Web.Data;
using WestcoastEdu.Web.Interface;
using WestcoastEdu.Web.Models;

namespace WestcoastEdu.Web.Repository;


public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(WestcoastEduDBContext context) : base(context)
    {       
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await context.Users.SingleOrDefaultAsync(user => user.Email == email);
    }

}