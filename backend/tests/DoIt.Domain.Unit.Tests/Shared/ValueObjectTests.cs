using DoIt.Domain.Shared;

namespace DoIt.Domain.Unit.Tests.Shared;

public class ValueObjectTests
{
    [Fact]
    public async Task Equals_WhenOtherIsNull_ShouldReturnFalse()
    {
        // Arrange
        var cut = new FakeName("name");
        
        // Act
        var result = cut.Equals(null);
        
        // Assert
        Assert.False(result);

        await Task.CompletedTask;
    }

    [Theory]
    [InlineData("first-name")]
    [InlineData("third-name")]
    public async Task Equals_WhenOtherHasDifferentValue_ShouldReturnFalse(string value)
    {
        // Arrange
        var cut = new FakeName("name");
        var other = new FakeName(value);
        
        // Act
        var result = cut.Equals(other);
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }

    [Theory]
    [InlineData("first-name", "first-name")]
    [InlineData("second-name", "second-name")]
    public async Task Equals_WhenOtherHasSameValue_ShouldReturnTrue(string value, string otherValue)
    {
        // Arrange
        var cut =  new FakeName(value);
        var other =  new FakeName(otherValue);
        
        // Act
        var result = cut.Equals(other);
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }
    
    [Fact]
    public async Task Equals_WhenOtherHasSameReference_ShouldReturnTrue()
    {
        // Arrange
        var cut = new FakeName("name");
        var other = cut;
        
        // Act
        var result = cut.Equals(other);
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }
    
    [Fact]
    public async Task EqualOperator_WhenOtherIsNull_ShouldReturnFalse()
    {
        // Arrange
        var cut = new FakeName("name");
        
        // Act
        var result = cut == null;
        
        // Assert
        Assert.False(result);

        await Task.CompletedTask;
    }

    [Theory]
    [InlineData("first-name")]
    [InlineData("third-name")]
    public async Task EqualOperator_WhenOtherHasDifferentValue_ShouldReturnFalse(string value)
    {
        // Arrange
        var cut = new FakeName("name");
        var other = new FakeName(value);
        
        // Act
        var result = cut == other;
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }
    
    [Theory]
    [InlineData("first-name", "first-name")]
    [InlineData("second-name", "second-name")]
    public async Task EqualOperator_WhenOtherHasSameValue_ShouldReturnTrue(string value, string otherValue)
    {
        // Arrange
        var cut =  new FakeName(value);
        var other =  new FakeName(otherValue);
        
        // Act
        var result = cut == other;
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }
    
    [Fact]
    public async Task EqualOperator_WhenOtherHasSameReference_ShouldReturnTrue()
    {
        // Arrange
        var cut = new FakeName("name");
        var other = cut;
        
        // Act
        var result = cut == other;
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }
    
    [Fact]
    public async Task NotEqualOperator_WhenOtherIsNull_ShouldReturnTrue()
    {
        // Arrange
        var cut = new FakeName("name");
        
        // Act
        var result = cut != null;
        
        // Assert
        Assert.True(result);

        await Task.CompletedTask;
    }
    
    [Theory]
    [InlineData("first-name", "first-name")]
    [InlineData("second-name", "second-name")]
    public async Task NotEqualOperator_WhenOtherHasSameValue_ShouldReturnFalse(string value, string otherValue)
    {
        // Arrange
        var cut =  new FakeName(value);
        var other =  new FakeName(otherValue);
        
        // Act
        var result = cut != other;
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }

    [Theory]
    [InlineData("first-name")]
    [InlineData("third-name")]
    public async Task NotEqualOperator_WhenOtherHasDifferentValue_ShouldReturnTrue(string value)
    {
        // Arrange
        var cut = new FakeName("name");
        var other = new FakeName(value);
        
        // Act
        var result = cut != other;
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }
    
    [Fact]
    public async Task NotEqualOperator_WhenOtherHasSameReference_ShouldReturnFalse()
    {
        // Arrange
        var cut = new FakeName("name");
        var other = cut;
        
        // Act
        var result = cut != other;
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }
    
    private sealed class FakeName
        : ValueObject
    {
        public string Name { get; }

        public FakeName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be empty", nameof(name));
        
            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}