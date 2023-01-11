using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WestcoastEdu.Web.Models;

namespace WestcoastEdu.Web.Data;

public class WestcoastEduDBContext : IdentityDbContext
{
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<User> Users => Set<User>();

    public WestcoastEduDBContext(DbContextOptions options) : base(options)
    {
    }

}