using Insurance.Application.Contracts;
using Insurance.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Insurance.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<InsuranceDbContext>(option =>
        option.UseSqlServer(connectionString));

        services.AddScoped<IInsuranceDbContext, InsuranceDbContext>();

        //ToDo
        //
        return services;
    }
}
