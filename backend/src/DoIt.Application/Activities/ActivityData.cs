using DoIt.Domain.Activities.ValueObjects;

namespace DoIt.Application.Activities;

public class ActivityData
{
    public Title? Title { get; private set; }
    public Description? Description { get; private set; }
    public Importance? Importance { get; private set; }
    
    public ActivityData WithTitle(Title title)
    {
        Title = title;
        return this;
    }

    public ActivityData WithDescription(Description? description)
    {
        if (description is null)
            return this;
        
        Description = description;
        return this;
    }

    public ActivityData WithImportance(Importance? importance)
    {
        if (importance is null)
            return this;

        Importance =  importance;
        return this;
    }
}