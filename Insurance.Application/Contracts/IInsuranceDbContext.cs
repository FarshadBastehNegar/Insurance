using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Insurance.Application.Contracts;

public interface IInsuranceDbContext
{
    DbSet<Request> Requests { get; set; }
    DbSet<Coverage> Coverages { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
