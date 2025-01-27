using Insurance.Application.Contracts;
using Insurance.Application.Models;
using Insurance.Application.Tools;
using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Application.Queries;
public class RequestQuery(IInsuranceDbContext context) : IRequestQuery
{
    private readonly IInsuranceDbContext _context = context;

    public async Task<IEnumerable<GetRequestModel>> GetAll(PaginationModel paging, CancellationToken ct)
    {
        return await _context.Requests.AsNoTracking()
            .Include(rc=>rc.Coverages)
            .Select(i => new GetRequestModel
            {
                Id = i.Id,
                Coverages = i.Coverages,
                Created = i.Created,
                LastModified = i.LastModified,
                Title = i.Title,
                TotalPremium = i.TotalPremium,
            })
            .ToPagination<GetRequestModel>(paging, ct);
    }
}
