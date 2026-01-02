namespace DoIt.Domain.Shared;

public abstract class ValueObject
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject)obj;

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Select(x => x.GetHashCode())
            .Aggregate((x, y) => x ^ y);
    }

    public static bool operator ==(
        ValueObject one,
        ValueObject two
    )
    {
        return EqualOperator(one, two);
    }

    public static bool operator !=(
        ValueObject one,
        ValueObject two
    )
    {
        return NotEqualOperator(one, two);
    }
    
    private static bool EqualOperator(
        ValueObject left,
        ValueObject right
    )
    {
        if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            return false;
        
        return ReferenceEquals(left, right) || left!.Equals(right);
    }

    private static bool NotEqualOperator(
        ValueObject left,
        ValueObject right
    )
    {
        return !EqualOperator(left, right);
    }
}