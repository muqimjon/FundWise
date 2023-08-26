using FundWise.Domain.Configurations;

namespace FundWise.Service.Interfaces.Commons;

public interface IServiceInterface<TCreate, TUpdate, TResult>
{
    Task<TResult> AddAsync(TCreate dto);
    Task<TResult> ModifyAsync(TUpdate dto);
    Task<bool> RemoveByIdAsync(long id);
    Task<TResult> RetrieveByIdAsync(long id);
    Task<IEnumerable<TResult>> RetrieveAllAsync(PaginationParams @params);
}
