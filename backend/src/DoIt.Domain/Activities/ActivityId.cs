using PanKunik.CleanArchitecture.BuildingBlocks;
using PanKunik.Extensions.Primitives;

namespace DoIt.Domain.Activities;

public sealed class ActivityId
    : EntityId<Guid>
{
    private ActivityId(Guid value)
        : base(value)
    {
        if (value.IsEmpty())
            throw new ArgumentException("Id of activity cannot be empty.", nameof(value));
    }

    public static ActivityId New()
        => new(Guid.NewGuid());
}