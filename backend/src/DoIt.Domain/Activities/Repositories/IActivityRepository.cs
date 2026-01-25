namespace DoIt.Domain.Activities.Repositories;

public interface IActivityRepository
{
    Task<Activity?> GetById(ActivityId id, CancellationToken cancellationToken);
    Task Add(Activity activity, CancellationToken cancellationToken);
}