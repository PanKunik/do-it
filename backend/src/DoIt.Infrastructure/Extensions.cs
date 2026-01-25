using DoIt.Domain.Activities.Repositories;
using DoIt.Infrastructure.Activities;
using Microsoft.Extensions.DependencyInjection;

namespace DoIt.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IActivityRepository, ActivityRepository>();
        
        return services;
    }
}