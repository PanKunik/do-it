using DoIt.Domain.Activities.ValueObjects;
using PanKunik.CleanArchitecture.BuildingBlocks;

namespace DoIt.Domain.Activities;

public class Activity
    : AggregateRoot<ActivityId, Guid>
{
    private Activity(
        ActivityId id,
        Title title,
        Description? description,
        Importance importance,
        Status status
    )
        : base(id)
    {
        Title = title ?? throw new ArgumentNullException(nameof(title));
        Description = description;
        Importance = importance ?? throw new ArgumentNullException(nameof(importance));
        Status = status ?? throw new ArgumentNullException(nameof(status));
    }

    public static Activity Create(
        Title title,
        Description? description = null,
        Importance? importance = null,
        Status? status = null
    )
    {
        return new Activity(
            ActivityId.New(),
            title,
            description,
            importance ?? Importance.NotImportant,
            status ?? Status.NotDone
        );
    }

    public Title Title { get; private set; }
    public Description? Description { get; private set; }
    public Importance Importance { get; private set; }
    public Status Status { get; private set; }

    public void Rename(Title title)
    {
        ArgumentNullException.ThrowIfNull(title);
        
        if (Title == title)
            return;

        Title = title;
    }

    public void ChangeDescription(Description? description)
    {
        if (Description == description)
            return;

        Description = description;
    }

    public void MarkAsImportant()
    {
        if (!Importance.IsImportant)
            Importance = Importance.Important;
    }

    public void MarkAsNotImportant()
    {
        if (Importance.IsImportant)
            Importance = Importance.NotImportant;
    }

    public void Do()
    {
        if (!Status.IsDone)
            Status = Status.Done;
    }

    public void Undo()
    {
        if (Status.IsDone)
            Status = Status.NotDone;
    }
}