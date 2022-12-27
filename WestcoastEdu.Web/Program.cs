using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<WestcoastEduDBContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlite"));
});

var app = builder.Build();

//Seed database with dummy from json
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<WestcoastEduDBContext>();
    await context.Database.MigrateAsync();
    await SeedData.LoadCourses(context);
}
catch (Exception ex)
{
    Console.WriteLine("{0} - {1} "  + ex.Message, ex.InnerException!.Message);
    throw ex;
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
