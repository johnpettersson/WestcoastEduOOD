
using System.Text.Json;
using WestcoastEdu.BCL.Courses;

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
}