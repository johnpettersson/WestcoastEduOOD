
using System.Text.Json;
using WestcoastEdu.Web.Models;

namespace WestcoastEdu.Web.Data;


public static class SeedData
{

    public static async Task LoadCourses(WestcoastEduDBContext context)
    {
        if(context.Courses.Any())
            return;

        var options = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        };

        var json = File.ReadAllText("Data/json/courses.json");
        var courses = JsonSerializer.Deserialize<List<Course>>(json, options);

        if(courses is not null && courses.Count > 0)
        {
            await context.Courses.AddRangeAsync(courses);
            await context.SaveChangesAsync();
        }
    }

    public static async Task LoadUsers(WestcoastEduDBContext context)
    {
        if(context.Users.Any())
            return;

        var options = new JsonSerializerOptions {
            PropertyNameCaseInsensitive = true
        };

        var json = File.ReadAllText("Data/json/users.json");
        var users = JsonSerializer.Deserialize<List<User>>(json, options);

        if(users is not null && users.Count > 0)
        {
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}