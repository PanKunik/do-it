using DoIt.Api.Endpoints.CreateActivity;

namespace DoIt.Api.Endpoints;

public static class WebApplicationExtensions
{
    public static WebApplication RegisterActivityEndpoints(this WebApplication app)
    {
        app.MapPost("/api/activity", CreateActivityEndpoint.Create);
        
        return app;
    }
}