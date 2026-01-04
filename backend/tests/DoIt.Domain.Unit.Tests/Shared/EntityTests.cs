using DoIt.Domain.Shared;

namespace DoIt.Domain.Unit.Tests.Shared;

public class EntityTests
{
    [Fact]
    public async Task Entity_WhenIdIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        FakeEntity CreateEntity() => new(null, new("fake-name"));

        // Act && Assert
        Assert.Throws<ArgumentNullException>((Func<FakeEntity>)CreateEntity);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Equals_WhenOtherHasSameReference_ShouldReturnTrue()
    {
        // Arrange
        var fakeEntity = new FakeEntity(new(1), new("fake-name"));
        var other = fakeEntity;
        
        // Act
        var result = fakeEntity.Equals(other);
        
        // Assert
        Assert.True(result);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Equals_WhenOtherIsNull_ShouldReturnFalse()
    {
        // Arrange
        var fakeEntity = new FakeEntity(new(1), new("fake-name"));
        FakeEntity? other = null;
        
        // Act
        var result = fakeEntity.Equals(other);
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task Equals_WhenOtherHasDifferentType_ShouldReturnFalse()
    {
        // Arrange
        var fakeEntity = new FakeEntity(new(1), new("fake-name"));
        var otherEntity = new OtherEntity(new(1),  new("fake-name"));
        
        // Act
        var result = fakeEntity.Equals(otherEntity);
        
        // Assert
        Assert.False(result);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Equals_WhenOtherHasSameIdAndType_ShouldReturnTrue()
    {
        // Arrange
        var fakeEntity = new FakeEntity(new(1), new("fake-name"));
        var otherEntity = new FakeEntity(new(1), new("fake-name2"));
        
        // Act
        var result = fakeEntity.Equals(otherEntity);
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task Equals_WhenOtherHasDifferentId_ShouldReturnFalse()
    {
        // Arrange
        var fakeEntity = new FakeEntity(new(1), new("fake-name"));
        var otherEntity = new FakeEntity(new(2), new("fake-name"));
        
        // Act
        var result = fakeEntity.Equals(otherEntity);
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task OperatorEquals_WhenBothAreNull_ShouldReturnTrue()
    {
        // Arrange
        FakeEntity? entity = null;
        FakeEntity? other = null;
        
        // Act
        var result = entity == other;
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task OperatorEquals_WhenOneIsNull_ShouldReturnFalse()
    {
        // Arrange
        var fakeEntity = new FakeEntity(new(1), new("fake-name"));
        FakeEntity? entity = null;
        
        // Act
        var result = fakeEntity == null;
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task OperatorEquals_WhenOtherHasSameIdAndType_ShouldReturnTrue()
    {
        // Arrange
        var fakeEntity = new FakeEntity(new(1), new("fake-name"));
        var otherEntity = new FakeEntity(new(1), new("fake-name"));
        
        // Act
        var result = fakeEntity == otherEntity;
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task OperatorEquals_WhenOtherHasDifferentId_ShouldReturnFalse()
    {
        // Arrange
        var fakeEntity = new FakeEntity(new(1), new("fake-name"));
        var otherEntity = new FakeEntity(new(2), new("fake-name"));
        
        // Act
        var result = otherEntity == fakeEntity;
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task OperatorNotEquals_WhenBothAreNull_ShouldReturnFalse()
    {
        // Arrange
        FakeEntity? entity = null;
        FakeEntity? other = null;
        
        // Act
        var result = entity != other;
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task OperatorNotEquals_WhenOneIsNull_ShouldReturnTrue()
    {
        // Arrange
        var fakeEntity = new FakeEntity(new(1), new("fake-name"));
        FakeEntity? entity = null;
        
        // Act
        var result = fakeEntity != null;
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task OperatorNotEquals_WhenOtherHasSameIdAndType_ShouldReturnFalse()
    {
        // Arrange
        var fakeEntity = new FakeEntity(new(1), new("fake-name"));
        var otherEntity = new FakeEntity(new(1), new("fake-name"));
        
        // Act
        var result = fakeEntity != otherEntity;
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task OperatorNotEquals_WhenOtherHasDifferentId_ShouldReturnTrue()
    {
        // Arrange
        var fakeEntity = new FakeEntity(new(1), new("fake-name"));
        var otherEntity = new FakeEntity(new(2), new("fake-name"));
        
        // Act
        var result = otherEntity != fakeEntity;
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }
    
    private sealed class FakeEntity(
        FakeEntityId id,
        FakeName name
    )
        : Entity<FakeEntityId, int>(id)
    {
        public FakeName Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    }

    private sealed class OtherEntity(
        OtherEntityId id,
        FakeName name
    )
        : Entity<OtherEntityId, int>(id)
    {
        public FakeName Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    }

    private sealed class FakeName(string value)
        : ValueObject
    {
        public string Name { get; } = value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }

    private sealed class FakeEntityId(int value)
        : EntityId<int>(value);

    private sealed class OtherEntityId(int value)
        : EntityId<int>(value);
}