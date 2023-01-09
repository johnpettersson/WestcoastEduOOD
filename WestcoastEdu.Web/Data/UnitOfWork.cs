
using WestcoastEdu.Web.Interface;
using WestcoastEdu.Web.Repository;

namespace WestcoastEdu.Web.Data;


public class UnitOfWork : IUnitOfWork
{
    private readonly WestcoastEduDBContext context;

    public UnitOfWork(WestcoastEduDBContext context)
    {
        this.context = context;
    }

    public ICourseRepository CourseRepository => new CourseRepository(context);

    public IUserRepository UserRepository => new UserRepository(context);

    public async Task<bool> Complete()
    {
        return (await context.SaveChangesAsync()) > 0;
    }
}