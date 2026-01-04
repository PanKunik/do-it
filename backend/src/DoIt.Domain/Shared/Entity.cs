namespace DoIt.Domain.Shared;

public abstract class Entity<TId, TValue>
    where TId : EntityId<TValue>
    where TValue : notnull
{
    public TId Id { get; }

    protected Entity(TId id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
    
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;

        if (ReferenceEquals(this, obj))
            return true;
        
        var other = (Entity<TId, TValue>)obj;
        return Id.Equals(other.Id);
    }

    public static bool operator ==(Entity<TId, TValue>? one, Entity<TId, TValue>? two)
    {
        if (one is null && two is null)
            return true;

        if (one is null ^ two is null)
            return false;
        
        return one!.Equals(two);
    }

    public static bool operator !=(Entity<TId, TValue>? one, Entity<TId, TValue>? two)
        => !(one == two);

    public override int GetHashCode()
        => HashCode.Combine(GetType(), Id);
}