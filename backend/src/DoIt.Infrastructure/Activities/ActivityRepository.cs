using DoIt.Domain.Activities;
using DoIt.Domain.Activities.Repositories;

namespace DoIt.Infrastructure.Activities;

public sealed class ActivityRepository
    : IActivityRepository
{
    private readonly List<Activity> _activities = [];
    
    public Task<Activity?> GetById(ActivityId id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_activities.FirstOrDefault(a => a.Id == id));
    }

    public Task Add(Activity activity, CancellationToken cancellationToken)
    {
        _activities.Add(activity);
        return Task.CompletedTask;
    }
}