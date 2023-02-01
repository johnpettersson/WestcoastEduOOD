
using Microsoft.EntityFrameworkCore;

using WestcoastEdu.Api.Models;

namespace WestcoastEdu.Api.Data;

public class WestcoastEduContext : DbContext
{
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Teacher> Teachers => Set<Teacher>();
    public DbSet<Subject> Subjects => Set<Subject>();
    
    public WestcoastEduContext(DbContextOptions options) : base(options)
    {
    }
}