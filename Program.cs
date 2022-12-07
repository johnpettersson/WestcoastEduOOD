using WestCoastEdu.BCL.Courses;
using WestCoastEdu.BCL.People;

CourseOccasion courseOccasion = new CourseOccasion 
{ 
    Course = new Course { Code = "YTOPC2", Name = "Objektorienterad programmering med C#" } , 
    StartDate = new DateOnly(2022, 10, 7), 
    EndDate = new DateOnly(2022, 12, 13) 
};
Teacher teacherJohn = new Teacher {FirstName = "John", LastName = "Doe", Email = "john.doe@mail.com" };
teacherJohn.Courses.Add(courseOccasion);
courseOccasion.Teachers.Add(teacherJohn);

Student studentJan = new Student { FirstName = "Jan", LastName = "Berg", Email="jan.berg@mail.com" };
studentJan.JoinCourse(courseOccasion);

Console.WriteLine($"Kurstillfälle: {courseOccasion.Course.Name} {courseOccasion.StartDate} - {courseOccasion.EndDate} Distans: {(courseOccasion.OnCampus ? "Nej" : "Ja")}");
Console.WriteLine($"{courseOccasion.Teachers.Count} Lärare knutna till kursen: ");
foreach(var teacher in courseOccasion.Teachers)
{
    Console.WriteLine(teacher.FirstName + " " + teacher.LastName);
}

Console.WriteLine($"{courseOccasion.Students.Count} Elev(er) knutna till kursen: ");
foreach(var student in courseOccasion.Students)
{
    Console.WriteLine(student.FirstName + " " + student.LastName);
}

Console.WriteLine();

Console.WriteLine($"Elev: {studentJan.FirstName} {studentJan.LastName}");
Console.WriteLine($"{studentJan.CurrentCourses.Count} Nuvarande kurs(er): ");
foreach(CourseOccasion occasion in studentJan.CurrentCourses)
{
    Console.WriteLine(occasion.Course.Name);
}

Console.WriteLine();

Console.WriteLine($"Lärare: {teacherJohn.FirstName} {teacherJohn.LastName}");
Console.WriteLine($"{teacherJohn.Courses.Count} Nuvarande kurs(er): ");
foreach(CourseOccasion occasion in teacherJohn.Courses)
{
    Console.WriteLine(occasion.Course.Name);
}

Console.WriteLine();

