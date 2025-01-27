using Insurance.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Application.Tools;

public static class PaginatedList
{
    public static async Task<IEnumerable<TEntity>> ToPagination<TEntity>(this IQueryable<TEntity> source,
        PaginationModel paging,
        CancellationToken ct)
    {
        var count = await source.CountAsync();
        var items =
            await source
            .Skip((paging.PageNumber - 1) * paging.PageSize)
            .Take(paging.PageSize)
            .ToListAsync(ct);

        return items;
    }
}
