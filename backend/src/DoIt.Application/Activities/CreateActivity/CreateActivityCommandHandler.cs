using DoIt.Domain.Activities;
using DoIt.Domain.Activities.Repositories;
using DoIt.Domain.Activities.ValueObjects;
using PanKunik.Extensions.Primitives;
using PanKunik.Results;
using PanKunik.Results.Rop;

namespace DoIt.Application.Activities.CreateActivity;

public sealed class CreateActivityCommandHandler(IActivityRepository repository)
{
    public async Task<Result<Activity>> Handle(
        CreateActivityCommand command,
        CancellationToken cancellationToken
    )
    {
        return await Result<ActivityData>.Success(new ActivityData())
            .Bind(b => Title.Create(command.Title).Map(b.WithTitle))
            .BindIf(
                command.Description.IsNotNull(),
                b => Description.Create(command.Description).Map(b.WithDescription)
            )
            .BindIf(
                command.Importance.HasValue,
                b => Result<Importance>.Success(
                    command.Importance!.Value
                        ? Importance.Important
                        : Importance.NotImportant
                    ).Map(b.WithImportance)
            )
            .Bind(b => Activity.Create(b.Title!, b.Description, b.Importance))
            .TapAsync(activity => repository.Add(activity, cancellationToken));
    }
}