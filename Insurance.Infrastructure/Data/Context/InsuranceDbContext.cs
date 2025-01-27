using Insurance.Application.Contracts;
using Insurance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Insurance.Infrastructure.Data.Context;

public class InsuranceDbContext : DbContext, IInsuranceDbContext
{
    public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options)
        : base(options) 
    {
    
    }

    public DbSet<Request> Requests { get; set; }
    public DbSet<Coverage> Coverages { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
