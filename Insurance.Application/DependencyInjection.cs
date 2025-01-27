using Insurance.Application.CommandHandlers;
using Insurance.Application.Contracts;
using Insurance.Application.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Insurance.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateRequestCommandHandler).Assembly));

        services.AddScoped<IRequestQuery, RequestQuery>();

        return services;
    }
}
