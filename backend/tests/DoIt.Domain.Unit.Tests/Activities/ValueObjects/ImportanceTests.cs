using DoIt.Domain.Activities.ValueObjects;

namespace DoIt.Domain.Unit.Tests.Activities.ValueObjects;

public class ImportanceTests
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Importance_WhenPassedValue_ShouldReturnExpectedValueObject(bool value)
    {
        // Act
        var importance = value ? Importance.Important : Importance.NotImportant;
        
        // Assert
        Assert.NotNull(importance);
        Assert.Equal(value, importance.Value);
        Assert.Equal(value, importance.IsImportant);
    }
}