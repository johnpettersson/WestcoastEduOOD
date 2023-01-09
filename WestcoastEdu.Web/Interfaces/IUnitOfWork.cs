namespace WestcoastEdu.Web.Interface;

public interface IUnitOfWork
{
    ICourseRepository CourseRepository { get; }
    IUserRepository UserRepository { get; }

    Task<bool> Complete();
}