using DoIt.Application.Activities.CreateActivity;
using Microsoft.AspNetCore.Mvc;

namespace DoIt.Api.Endpoints.CreateActivity;

public static class CreateActivityEndpoint
{
    public record CreateActivityRequest(string Title, string? Description, bool IsImportant);
    
    public static async Task<IResult> Create(
        [FromServices] CreateActivityCommandHandler handler,
        CreateActivityRequest request,
        CancellationToken cancellationToken = default
    )
    {
        var (title, description, important) = request;
        var command = new  CreateActivityCommand(title, description, important);
        var result = await handler.Handle(command, cancellationToken);
        
        return result.IsFailure
            ? Results.BadRequest(result.Error!)
            : Results.Ok(result.Value!);
    }
}