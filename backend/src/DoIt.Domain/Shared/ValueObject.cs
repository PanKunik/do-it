namespace DoIt.Domain.Shared;

public abstract class ValueObject
    : IEquatable<ValueObject>
{
    protected abstract IEnumerable<object> GetEqualityComponents();

    public bool Equals(ValueObject? other)
    {
        if (other is null)
            return false;

        if (ReferenceEquals(this, other))
            return true;
        
        if (other.GetType() != GetType())
            return false;
        
        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }
    
    public override bool Equals(object? obj)
        => Equals(obj as ValueObject);

    public override int GetHashCode()
    {
        var hash = new HashCode();

        foreach (var component in GetEqualityComponents())
            hash.Add(component);
        
        return hash.ToHashCode();
    }

    public static bool operator ==(ValueObject? one, ValueObject? two)
        => Equals(one, two);

    public static bool operator !=(ValueObject? one, ValueObject? two)
        => !Equals(one, two);
}