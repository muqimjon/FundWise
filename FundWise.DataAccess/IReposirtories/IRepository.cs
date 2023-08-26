using FundWise.Domain;
using System.Linq.Expressions;

namespace FundWise.DataAccess.IRepositories;

public interface IRepository<T> where T : Auditable
{
    Task CreateAsync(T entity);
    void Update(T entity);
    Task DeleteAsync(Expression<Func<T, bool>> expression);
    Task DestroyAsync(Expression<Func<T, bool>> expression);
    Task<T> SelectAsync(Expression<Func<T, bool>> expression, string[] includes = null!);
    IQueryable<T> SelectAll(Expression<Func<T, bool>> expression = null!, bool asNoTracking = true, string[] includes = null!);
    Task SaveAsync();
}
