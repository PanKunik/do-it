using PanKunik.CleanArchitecture.BuildingBlocks;
using PanKunik.Results;

namespace DoIt.Domain.Activities.ValueObjects;

public sealed class Title
    : ValueObject
{
    private const int MaximumNameLength = 50;
    public string Value { get; }
    
    private Title(string value)
    {
        Value = value;
    }

    public static Result<Title> Create(string value)
    {
        var trimmedValue = value?.Trim();
        
        if (string.IsNullOrWhiteSpace(trimmedValue))
            return Result<Title>.Failure(Errors.Titles.Empty);

        if (trimmedValue.Length > MaximumNameLength)
            return Result<Title>.Failure(Errors.Titles.TooLong(MaximumNameLength));

        return Result<Title>.Success(new Title(trimmedValue));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}