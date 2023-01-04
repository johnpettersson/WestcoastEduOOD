using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Web.Models;

namespace WestcoastEdu.Web.Data;

public class WestcoastEduDBContext : DbContext
{
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<User> Users => Set<User>();

    public WestcoastEduDBContext(DbContextOptions options) : base(options)
    {
    }

}