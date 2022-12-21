using WestcoastEdu.BCL.People;
using WestcoastEdu.BCL.Courses;

namespace WestcoastEdu.Tests;

public class StudentTests
{
    [Fact]
    public void Test_StudentJoinCourse_ThrowsException_IfNotAuthenticated()
    {
        // arrenge
        Student student = new Student();
        //student.Authenticate(""); //authenticate never called = user not authenticated

        // act
        Action act = () => student.JoinCourse(new CourseOccasion());

        // assert
        Assert.Throws<Exception>(act);
    }

    [Fact]
    public void Test_StudentNameNullOnCreation()
    {
        //arrenge
        //act
        Student student = new Student();

        //assert
        Assert.Null(student.FirstName);
        Assert.Null(student.LastName);
    }
}