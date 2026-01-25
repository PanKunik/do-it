using DoIt.Domain.Activities;
using DoIt.Domain.Unit.Tests.Utilities.Activities;

namespace DoIt.Domain.Unit.Tests.Activities;

public class ActivityInvariantTests
{
    [Fact]
    public void Activity_ShouldNeverHaveNullTitle()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => Activity.Create(null!));
    }

    [Fact]
    public void Aggregate_ShouldNeverHaveNullImportance()
    {
        // Act
        var activityResult = Activity.Create(
            ActivityTestData.ValidTitle(),
            importance: null
        );
        
        var activity = activityResult.Value!;
        
        // Assert
        Assert.NotNull(activity.Importance);
    }

    [Fact]
    public void Aggregate_ShouldNeverHaveNullStatus()
    {
        // Act
        var activityResult = Activity.Create(
            ActivityTestData.ValidTitle(),
            status: null
        );
        
        var activity = activityResult.Value!;
        
        // Assert
        Assert.NotNull(activity.Status);
    }
}