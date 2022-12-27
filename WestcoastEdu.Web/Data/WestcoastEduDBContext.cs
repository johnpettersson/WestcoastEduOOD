using Microsoft.EntityFrameworkCore;
using WestcoastEdu.BCL.Courses;

namespace WestcoastEdu.Web.Data;

public class WestcoastEduDBContext : DbContext
{
    public DbSet<Course> Courses => Set<Course>();

    public WestcoastEduDBContext(DbContextOptions options) : base(options)
    {
    }

}