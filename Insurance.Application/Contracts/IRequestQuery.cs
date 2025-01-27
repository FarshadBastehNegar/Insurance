using Insurance.Application.Models;

namespace Insurance.Application.Contracts;

public interface IRequestQuery
{
    Task<IEnumerable<GetRequestModel>> GetAll(PaginationModel paging, CancellationToken ct);
}
