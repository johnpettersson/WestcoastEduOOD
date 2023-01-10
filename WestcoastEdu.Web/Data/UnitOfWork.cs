
using WestcoastEdu.Web.Interface;
using WestcoastEdu.Web.Repository;

namespace WestcoastEdu.Web.Data;


public class UnitOfWork : IUnitOfWork
{
    private readonly WestcoastEduDBContext context;
    private readonly CourseRepository courseRepository;
    private readonly UserRepository userRepository;

    public UnitOfWork(WestcoastEduDBContext context)
    {
        this.context = context;
        this.courseRepository = new CourseRepository(context);
        this.userRepository = new UserRepository(context);
    }

    public ICourseRepository CourseRepository => this.courseRepository;

    public IUserRepository UserRepository => this.userRepository;

    public async Task<bool> Complete()
    {
        return (await context.SaveChangesAsync()) > 0;
    }
}