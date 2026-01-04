using DoIt.Domain.Shared;

namespace DoIt.Domain.Unit.Tests.Shared;

public class EntityIdTests
{
    [Fact]
    public async Task Equals_WhenOtherHasSameValue_ShouldReturnTrue()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var other = new UserId(guid);
        
        // Act
        var result = cut.Equals(other);
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task Equals_WhenOtherHasDifferentValue_ShouldReturnFalse()
    {
        // Arrange
        var cut = new UserId(Guid.NewGuid());
        var other =  new UserId(Guid.NewGuid());
        
        // Act
        var result = cut.Equals(other);
        
        // Assert
        Assert.False(result);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Equals_WhenOtherValueHasSameValueButDifferentType_ShouldReturnFalse()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var  other = new ActivityId(guid);
        
        // Act
        var result = cut.Equals(other);
        
        // Assert
        Assert.False(result);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task EqualOperator_WhenOtherHasSameValue_ShouldReturnTrue()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var other = new UserId(guid);
        
        // Act
        var result = cut == other;
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task EqualOperator_WhenOtherHasDifferentValue_ShouldReturnFalse()
    {
        // Arrange
        var cut = new UserId(Guid.NewGuid());
        var other =  new UserId(Guid.NewGuid());
        
        // Act
        var result = cut == other;
        
        // Assert
        Assert.False(result);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task EqualOperator_WhenOtherValueHasSameValueButDifferentType_ShouldReturnFalse()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var  other = new ActivityId(guid);
        
        // Act
        var result = cut == other;
        
        // Assert
        Assert.False(result);

        await Task.CompletedTask;
    }
    
    [Fact]
    public async Task NotEqualOperator_WhenOtherHasSameValue_ShouldReturnFalse()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var other = new UserId(guid);
        
        // Act
        var result = cut != other;
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task NotEqualOperator_WhenOtherHasDifferentValue_ShouldReturnTrue()
    {
        // Arrange
        var cut = new UserId(Guid.NewGuid());
        var other =  new UserId(Guid.NewGuid());
        
        // Act
        var result = cut != other;
        
        // Assert
        Assert.True(result);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task NotEqualOperator_WhenOtherValueHasSameValueButDifferentType_ShouldReturnTrue()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var cut = new UserId(guid);
        var  other = new ActivityId(guid);
        
        // Act
        var result = cut != other;
        
        // Assert
        Assert.True(result);

        await Task.CompletedTask;
    }
    
    private sealed class UserId(Guid value)
        : EntityId<Guid>(value);
    
    private sealed class ActivityId(Guid value)
        : EntityId<Guid>(value);
}