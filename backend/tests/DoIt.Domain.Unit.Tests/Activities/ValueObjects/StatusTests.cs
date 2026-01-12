using DoIt.Domain.Activities.ValueObjects;

namespace DoIt.Domain.Unit.Tests.Activities.ValueObjects;

public class StatusTests
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void ActivityStatus_WhenPassedValue_ShouldCreateExpectedActivityStatus(bool value)
    {
        // Act
        var activityStatus = value ? Status.Done : Status.NotDone;
        
        // Assert
        Assert.NotNull(activityStatus);
        Assert.Equal(value, activityStatus.Value);
        Assert.Equal(value, activityStatus.IsDone);
    }
}