using FundWise.Domain.Configurations;

namespace FundWise.Service.Extensions;

public static class CollectionExtension
{
    public static IQueryable<T> ToPaginate<T>(this IQueryable<T> values, PaginationParams @params)
        => values.Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize);
}
