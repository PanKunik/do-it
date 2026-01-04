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
    public async Task Equals_WhenOtherHasDifferentType_ShouldReturnFalse()
    {
        // Arrange
        var cut = new FakeName("name");
        var other = new FakeDescription("name");
        
        // Act
        var result = cut.Equals(other);
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }
    
    [Fact]
    public async Task OperatorEquals_WhenOtherIsNull_ShouldReturnFalse()
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
    public async Task OperatorEquals_WhenOtherHasDifferentValue_ShouldReturnFalse(string value)
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
    public async Task OperatorEquals_WhenOtherHasSameValue_ShouldReturnTrue(string value, string otherValue)
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
    public async Task OperatorEquals_WhenOtherHasSameReference_ShouldReturnTrue()
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
    public async Task OperatorEquals_WhenOtherHasDifferentType_ShouldReturnFalse()
    {
        // Arrange
        var cut = new FakeName("name");
        var other = new FakeDescription("name");
        
        // Act
        var result = cut == other;
        
        // Assert
        Assert.False(result);
        
        await Task.CompletedTask;
    }
    
    [Fact]
    public async Task OperatorNotEquals_WhenOtherIsNull_ShouldReturnTrue()
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
    public async Task OperatorNotEquals_WhenOtherHasSameValue_ShouldReturnFalse(string value, string otherValue)
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
    public async Task OperatorNotEquals_WhenOtherHasDifferentValue_ShouldReturnTrue(string value)
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
    public async Task OperatorNotEquals_WhenOtherHasSameReference_ShouldReturnFalse()
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

    [Fact]
    public async Task OperatorNotEquals_WhenOtherHasDifferentType_ShouldReturnTrue()
    {
        // Arrange
        var cut = new FakeName("name");
        var other = new FakeDescription("name");
        
        // Act
        var result = cut != other;
        
        // Assert
        Assert.True(result);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task GetHashCode_WhenOtherIsTheSame_ShouldBeEqual()
    {
        // Arrange
        var cut = new FakeName("name");
        var other = new FakeName("name");
        
        // Act
        var cutHashCode =  cut.GetHashCode();
        var otherHashCode =  other.GetHashCode();
        
        // Assert
        Assert.Equal(cutHashCode, otherHashCode);
        
        await Task.CompletedTask;
    }

    [Fact]
    public async Task GetHashCode_WhenOtherIsTheSame_ShouldBeNotEqual()
    {
        // Arrange
        var cut = new FakeName("name1");
        var other = new FakeName("name2");
        
        // Act
        var cutHashCode =  cut.GetHashCode();
        var otherHashCode =  other.GetHashCode();
        
        // Assert
        Assert.NotEqual(cutHashCode, otherHashCode);
        
        await Task.CompletedTask;
    }
    
    private sealed class FakeName(string name)
        : ValueObject
    {
        public string Name { get; } = name;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }

    private sealed class FakeDescription(string description)
        : ValueObject
    {
        public string Description { get; } = description;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Description;
        }
    }
}