namespace DoIt.Application.Activities.CreateActivity;

public record CreateActivityCommand(
    string Title,
    string? Description,
    bool? Importance = null
);