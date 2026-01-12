using PanKunik.CleanArchitecture.BuildingBlocks;

namespace DoIt.Domain.Activities.ValueObjects;

public sealed class Importance
    : ValueObject
{
    public bool Value { get; }

    private Importance(bool value) => Value = value;

    public static Importance Important => new(true);
    public static Importance NotImportant => new(false);
    
    public bool IsImportant => Value;
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}