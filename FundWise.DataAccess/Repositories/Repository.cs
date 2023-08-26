using FundWise.Data.DbContexts;
using FundWise.DataAccess.IRepositories;
using FundWise.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FundWise.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly DbSet<T> dbSet;
    private readonly AppDbContext appDbContext;

    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        dbSet = appDbContext.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        entity.UpdateAt = DateTime.UtcNow;
        dbSet.Entry(entity).State = EntityState.Modified;
    }

    public async Task DeleteAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await dbSet.FirstOrDefaultAsync(expression);
        if (entity != null)
            entity.IsDeleted = true;
    }

    public async Task DestroyAsync(Expression<Func<T, bool>> expression)
    {
        var entity = await dbSet.FirstOrDefaultAsync(expression);
        if (entity != null)
            dbSet.Remove(entity);
    }

    public async Task<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null!)
    {
        var query = expression is null ? dbSet : dbSet.Where(expression);

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        var result = await query.FirstOrDefaultAsync(expression!);
        return result!;
    }

    public IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null!, bool asNoTracking = true, string[] includes = null!)
    {
        var query = expression is null ? dbSet : dbSet.Where(expression);
        query = asNoTracking ? query.AsNoTracking() : query;

        if (includes is not null)
            foreach (var include in includes)
                query = query.Include(include);

        return query;
    }

    public async Task SaveAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}
