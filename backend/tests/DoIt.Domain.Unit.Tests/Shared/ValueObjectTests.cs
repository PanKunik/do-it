using DoIt.Domain.Shared;

namespace DoIt.Domain.Unit.Tests.Shared;

public class ValueObjectTests
{
    [Theory]
    [InlineData(null, null)]
    [InlineData("", "")]
    [InlineData("name", "name")]
    public async Task GetHashCode_WhenCalledSameValues_ShouldBeEqual(string? value, string? otherValue)
    {
        // Arrange
        var cut = new FakeName(value);
        var other = new FakeName(otherValue);

        // Act
        var cutHashCode = cut.GetHashCode();
        var otherHashCode = other.GetHashCode();

        // Assert
        Assert.Equal(cutHashCode, otherHashCode);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task GetHashCode_WhenNameIsNull_ShouldReturnDifferentHashCodeForDifferentNames()
    {
        // Arrange
        var cut = new FakeName(null);
        var other = new FakeName("name");

        // Act
        var cutHashCode = cut.GetHashCode();
        var otherHashCode = other.GetHashCode();

        // Assert
        Assert.NotEqual(cutHashCode, otherHashCode);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Equals_WhenOtherHasNullValue_ShouldReturnFalse()
    {
        // Arrange
        var cut = new FakeName("name");
        var other = new FakeName(null);

        // Act
        var result = cut.Equals(other);

        // Assert
        Assert.False(result);

        await Task.CompletedTask;
    }

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

    [Fact]
    public async Task Equals_WhenComparingEmptyValues_ShouldReturnTrue()
    {
        // Arrange
        var cut = new FakeName("");
        var other = new FakeName("");

        // Act
        var result = cut.Equals(other);

        // Assert
        Assert.True(result);

        await Task.CompletedTask;
    }

    [Fact]
    public async Task Equals_WhenOtherIsDifferentType_ShouldReturnFalse()
    {
        // Arrange
        var cut = new FakeName("name");
        var fakeClass = new FakeClass();

        // Act
        var result = cut.Equals(fakeClass);

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
    [InlineData(null, null)]
    [InlineData("first-name", "first-name")]
    [InlineData("second-name", "second-name")]
    public async Task Equals_WhenOtherHasSameValue_ShouldReturnTrue(string? value, string? otherValue)
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
    public async Task Equals_WhenOtherComplexValueObjectHasSameValues_ShouldReturnTrue()
    {
        // Arrange
        var cut = new FakeComplexComponent("FirstName", "LastName");
        var other = new FakeComplexComponent("FirstName", "LastName");

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
    public async Task Equals_WhenOtherHasDifferentTypeButSameValue_ShouldReturnFalse()
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
    [InlineData(null, null)]
    [InlineData("first-name", "first-name")]
    [InlineData("second-name", "second-name")]
    public async Task OperatorEquals_WhenOtherHasSameValue_ShouldReturnTrue(string? value, string? otherValue)
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
    [InlineData(null, null)]
    [InlineData("first-name", "first-name")]
    [InlineData("second-name", "second-name")]
    public async Task OperatorNotEquals_WhenOtherHasSameValue_ShouldReturnFalse(string? value, string? otherValue)
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
    
    private sealed class FakeName(string? name)
        : ValueObject
    {
        public string? Name { get; } = name;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name!;
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

    private sealed class FakeClass;

    private sealed class FakeComplexComponent(string FirstName, string LastName)
        : ValueObject
    {
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}