using PanKunik.CleanArchitecture.BuildingBlocks;

namespace DoIt.Domain.Activities.ValueObjects;

public sealed class Status
    : ValueObject
{
    public bool Value { get; }

    private Status(bool value) => Value = value;

    public static Status NotDone => new(false);
    public static Status Done => new(true);
    
    public bool IsDone => Value;
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}