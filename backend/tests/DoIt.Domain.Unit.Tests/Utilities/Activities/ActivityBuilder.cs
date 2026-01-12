using DoIt.Domain.Activities;
using DoIt.Domain.Activities.ValueObjects;

namespace DoIt.Domain.Unit.Tests.Utilities.Activities;

internal sealed class ActivityBuilder
{
    private Title _title = ActivityTestData.ValidTitle();
    private Description? _description;
    private Importance _importance = Importance.NotImportant;
    private Status _status = Status.NotDone;

    public static ActivityBuilder Default()
    {
        return new ActivityBuilder();
    }
    
    public ActivityBuilder WithTitle(Title title)
    {
        _title = title;
        return this;
    }

    public ActivityBuilder WithDescription(Description? description)
    {
        _description = description;
        return this;
    }

    public ActivityBuilder WithImportance(Importance importance)
    {
        _importance = importance;
        return this;
    }

    public ActivityBuilder WithoutImportance()
    {
        _importance = null;
        return this;
    }

    public ActivityBuilder WithStatus(Status status)
    {
        _status = status;
        return this;
    }

    public ActivityBuilder WithoutStatus()
    {
        _status = null;
        return this;
    }

    public Activity Build()
    {
        return Activity.Create(
            _title,
            _description,
            _importance,
            _status
        );
    }
}