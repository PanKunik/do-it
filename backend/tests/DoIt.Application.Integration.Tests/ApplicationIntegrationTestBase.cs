using DoIt.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace DoIt.Application.Integration.Tests;

public class ApplicationIntegrationTestBase
    : IAsyncLifetime
{
    protected readonly IServiceProvider ServiceProvider;
    protected readonly IServiceScope Scope;

    protected ApplicationIntegrationTestBase()
    {
        var root = new ServiceCollection()
            .AddInfrastructure()
            .BuildServiceProvider();
        
        Scope = root.CreateScope();
        ServiceProvider = Scope.ServiceProvider;
    }
    
    public Task InitializeAsync()
    {
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        Scope.Dispose();
        return Task.CompletedTask;
    }
}