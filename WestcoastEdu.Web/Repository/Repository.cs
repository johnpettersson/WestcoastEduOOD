
using Microsoft.EntityFrameworkCore;
using WestcoastEdu.Web.Data;
using WestcoastEdu.Web.Interface;

namespace WestcoastEdu.Web.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly WestcoastEduDBContext context;
    protected readonly DbSet<T> set;

    public Repository(WestcoastEduDBContext context)
    {
        this.context = context;
        this.set = context.Set<T>();
    }

    public async Task<bool> AddAsync(T entity)
    {
        try {
            await this.set.AddAsync(entity);
            return true;
        }
        catch {
            return false;
        }
    }

    public Task<bool> DeleteAsync(T entity)
    {
        try
        {
            this.set.Remove(entity);
            return Task.FromResult(true);
        }
        catch
        {
            return Task.FromResult(false);
        }
    }

    public async Task<T?> FindByIdAsync(int id)
    {
        return await this.set.FindAsync(id);
    }

    public async Task<IList<T>> ListAllAsync()
    {
        return await this.set.ToListAsync();
    }

    public Task<bool> UpdateAsync(T entity)
    {
        this.set.Update(entity);
        return Task.FromResult(true);  
    }
}