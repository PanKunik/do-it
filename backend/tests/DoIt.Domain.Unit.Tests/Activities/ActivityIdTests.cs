using DoIt.Domain.Activities;

namespace DoIt.Domain.Unit.Tests.Activities;

public class ActivityIdTests
{
    [Fact]
    public void New_ShouldReturnActivityId()
    {
        // Act
        var activityId = ActivityId.New();
        
        // Assert
        Assert.NotNull(activityId);
        Assert.NotEqual(Guid.Empty, activityId.Value);
    }
}