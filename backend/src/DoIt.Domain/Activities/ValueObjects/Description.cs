using PanKunik.CleanArchitecture.BuildingBlocks;
using PanKunik.Results;

namespace DoIt.Domain.Activities.ValueObjects;

public sealed class Description
    : ValueObject
{
    private const int MaximumDescriptionLength = 250;
    
    public string? Value { get; }

    private Description(string? value) => Value = value;
    
    public static Result<Description> Create(string? value)
    {
        var trimmedValue = value?.Trim();
        
        if (trimmedValue?.Length > MaximumDescriptionLength)
            return Result<Description>.Failure(Errors.Descriptions.TooLong(MaximumDescriptionLength));

        return Result<Description>.Success(new Description(trimmedValue));
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value!;
    }
}