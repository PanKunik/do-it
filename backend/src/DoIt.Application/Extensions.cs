using DoIt.Application.Activities.CreateActivity;
using Microsoft.Extensions.DependencyInjection;

namespace DoIt.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateActivityCommandHandler>();
        
        return services;
    }
}